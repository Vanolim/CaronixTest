using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleResult
{
    public class BattleResultView : MonoBehaviour
    {
        [field: SerializeField] 
        public Button Next { get; private set; }

        [SerializeField]
        private TMP_Text _reward;

        public void SetReward(int value) => _reward.text = value.ToString();
    }
}