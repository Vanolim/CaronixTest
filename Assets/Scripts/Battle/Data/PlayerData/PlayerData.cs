using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Battle/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField]
        public Vector2 MinMaxDamage { get; private set; }
    }
}