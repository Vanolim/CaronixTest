using UnityEngine;

namespace SearchEnemy
{
    public class Deserializer
    {
        public bool TryDeserializeNameAndPicture(string data, out EnemyDataFullName name, out EnemyDataPicturesURL picturesURL)
        {
            var separations = data.Split('{', '}');
            string fullName = default;
            string fullPicturesURL = default;

            for (int i = 0; i < separations.Length; i++)
            {
                if (separations[i].StartsWith('"' + "title"))
                {
                    fullName = separations[i];
                }

                if (separations[i].StartsWith('"' + "large"))
                {
                    fullPicturesURL = separations[i];
                }
            }

            if (fullName != default && fullPicturesURL != default)
            {
                EnemyDataFullName enemyDataFullName = JsonUtility.FromJson<EnemyDataFullName>("{" + fullName + "}");
                EnemyDataPicturesURL enemyDataPicturesURL = JsonUtility.FromJson<EnemyDataPicturesURL>("{" + fullPicturesURL + "}");
                
                name = enemyDataFullName;
                picturesURL = enemyDataPicturesURL;
                return true;
            }
            

            name = default;
            picturesURL = default;
            return false;
        }
    }
}