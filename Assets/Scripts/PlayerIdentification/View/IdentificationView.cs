using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Identification
{
    public class IdentificationView : MonoBehaviour
    {
        [field: SerializeField]
        public TMP_Text Input { get; private set; }

        [field: SerializeField]
        public Button Next { get; private set; }
    }
}