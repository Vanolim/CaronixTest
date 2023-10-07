using UnityEngine;

namespace Core
{
    public class SaveLoadService
    {
        private const string _encryptKey = "ABCD" + "EFGHABCDEF" + "GHAB" + "C" + "D" + "EFGHABCDEFGH";
        private const string _encryptIV = "A" + "B" + "CDE" + "FGHAB" + "CD" + "EFGH";
        private const string _progressPartPath = "/Progress.gd";

        private readonly SaveLoadSerializer _saveLoadSerializer = new();
        
        private string _progressPath;

        public GameData GameData;

        public SaveLoadService()
        {
            LoadGame();
        }

        private void LoadGame()
        {
            _progressPath = Application.persistentDataPath + _progressPartPath;
            
#if UNITY_EDITOR
            Debug.Log(_progressPath);
#endif            
            
            GameData = _saveLoadSerializer.Load<GameData>(_encryptKey, _encryptIV, _progressPath);

            if (GameData == null)
                ResetProgress();
        }

        public void ResetProgress()
        {
            GameData = new GameData();
            SaveProgress();
        }
        
        public void SaveProgress() => 
            _saveLoadSerializer.Save(GameData, _encryptKey, _encryptIV, _progressPath);
    }
}