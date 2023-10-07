using Core;
using UnityEngine;

namespace SearchEnemy
{
    public class SearchEnemyLoadView : MonoBehaviour,
        IActivable
    {
        public void Activate() => gameObject.SetActive(true);

        public void Deactivate() => gameObject.SetActive(false);
    }
}