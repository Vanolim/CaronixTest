using Zenject;

namespace Main
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Bootstrapper>().AsSingle().NonLazy();
        }
    }
}