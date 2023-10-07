using System;
using UnityEngine;

namespace SearchEnemy
{
    [Serializable]
    public class EnemyInfo
    {
        private readonly string _name;
        private readonly Sprite _avatar;

        public string Name => _name;
        public Sprite Avatar => _avatar;

        public EnemyInfo(string name, Sprite avatar)
        {
            _name = name;
            _avatar = avatar;
        }
    }
}