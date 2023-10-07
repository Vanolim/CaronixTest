using Core;
using TMPro;
using UnityEngine;

namespace Battle
{
    public class BattleFinishView : MonoBehaviour, 
        IActivable
    {
        [SerializeField]
        private TMP_Text _text;

        private const string _finishText = "победил!";

        public void SetPlayerName(string name) => _text.text = $"{name} {_finishText}";
        
        public void Activate() => gameObject.SetActive(true);

        public void Deactivate() => gameObject.SetActive(false);
    }
}