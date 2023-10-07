using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Battle/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField]
        public Vector2 MinMaxHealthValue { get; private set; }
        
        [field: SerializeField]
        public Vector2 MinMaxReward { get; private set; }
    }
}