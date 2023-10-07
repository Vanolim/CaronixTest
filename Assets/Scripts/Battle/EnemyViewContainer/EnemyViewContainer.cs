using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Battle/EnemyViewContainer")]
    public class EnemyViewContainer : ScriptableObject
    {
        [field: SerializeField] 
        public EnemyView[] EnemyViews { get; private set; }
    }
}