using Core;
using UnityEngine;
using Zenject;

namespace Identification
{
    public class PlayerIdentificationInstaller : MonoInstaller
    {
        [SerializeField]
        private IdentificationView _identificationView;
        
        public override void InstallBindings()
        {
            this.BindPrefab(Container, _identificationView);
            Container.BindInterfacesTo<PlayerIdentification>().AsSingle().NonLazy();
        }
    }
}