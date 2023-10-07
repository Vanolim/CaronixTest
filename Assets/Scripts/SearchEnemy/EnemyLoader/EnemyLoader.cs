using System;
using Core;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace SearchEnemy
{
    public class EnemyLoader
    {
        private readonly SearchEnemyLoadView _searchEnemyLoadView;
        private readonly Deserializer _deserializer;

        private const string _dataURL = "https://randomuser.me/api/";

        public EnemyLoader(SearchEnemyLoadView searchEnemyLoadView)
        {
            _searchEnemyLoadView = searchEnemyLoadView;
            _deserializer = new Deserializer();
        }

        public async UniTask<EnemyInfo> GetEnemy()
        {
            _searchEnemyLoadView.Activate();
            
            while (true)
            {
                string data = await LoadData(_dataURL);
                if(data == default)
                    continue;

                if (_deserializer.TryDeserializeNameAndPicture(data,
                        out EnemyDataFullName fullName, out EnemyDataPicturesURL pictureURL))
                {
                    Texture2D avatar = await LoadImage(pictureURL.large);
                    if (avatar != null)
                    {
                        _searchEnemyLoadView.Deactivate();
                        return GetEnemyInfo(fullName, avatar);
                    }
                }
            }
        }

        private async UniTask<string> LoadData(string url)
        {
            UnityWebRequest data;
            try
            {
                data = await UnityWebRequest.Get(url).SendWebRequest();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return default;
            }
            
            if (data.result == UnityWebRequest.Result.Success)
            {
                return data.downloadHandler.text;
            }

            return default;
        }
        
        private async UniTask<Texture2D> LoadImage(string url)
        {
            UnityWebRequest uwr = await UnityWebRequestTexture.GetTexture(url).SendWebRequest();
            return DownloadHandlerTexture.GetContent(uwr);
        }

        private EnemyInfo GetEnemyInfo(EnemyDataFullName fullName, Texture2D avatarTexture)
        {
            string name = $"{fullName.title} {fullName.first} {fullName.last}";
            Sprite avatar = avatarTexture.ConvertToSprite();
            return new EnemyInfo(name, avatar);
        }
    }
}