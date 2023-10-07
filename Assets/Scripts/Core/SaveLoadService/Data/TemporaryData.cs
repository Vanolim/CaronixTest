using System;
using SearchEnemy;

namespace Core
{
    [Serializable]
    public class TemporaryData
    {
        public EnemyInfo EnemyInfo { get; set; }
        public int RewardValue { get; set; }
    }
}