using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SearchEnemy
{
    public class EnemyInfoView : MonoBehaviour
    {
        [SerializeField]
        private Image _avatar;

        [SerializeField]
        private TMP_Text _name;

        public void SetAvatar(Sprite sprite) => _avatar.sprite = sprite;

        public void SetName(string name) => _name.text = name;
    }
}