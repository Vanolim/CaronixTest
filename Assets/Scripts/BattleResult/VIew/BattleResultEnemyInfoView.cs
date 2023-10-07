using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleResult
{
    public class BattleResultEnemyInfoView : MonoBehaviour
    {
        [SerializeField]
        private Image _avatar;
        
        [SerializeField]
        private TMP_Text _name;

        private const string _battleText = "Бой с ";

        public void SetAvatar(Sprite sprite) => _avatar.sprite = sprite;
        
        public void SetName(string name) => _name.text = _battleText + name;
    }
}