using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class EnemyHealthBarView : MonoBehaviour
    {
        [SerializeField]
        private Scrollbar _scrollbar;

        public void SetDelta(float value) => _scrollbar.size = value;
    }
}