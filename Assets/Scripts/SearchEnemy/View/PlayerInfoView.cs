using TMPro;
using UnityEngine;

namespace SearchEnemy
{
    public class PlayerInfoView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _playerName;

        [SerializeField]
        private TMP_Text _playerCoinValue;
        
        public void SetPlayerName(string name) => _playerName.text = name;

        public void SetPlayerCoinValue(int value) => _playerCoinValue.text = value.ToString();

    }
}