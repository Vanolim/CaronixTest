using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class EnemyBarView : MonoBehaviour
    {
        [SerializeField]
        private EnemyHealthBarView _enemyHealthBarView;

        [SerializeField]
        private Image _avatar;

        [SerializeField]
        private TMP_Text _name;

        public EnemyHealthBarView EnemyHealthBarView => _enemyHealthBarView;

        public void SetAvatar(Sprite avatar) => _avatar.sprite = avatar;
        
        public void SetName(string name) => _name.text = name;
    }
}