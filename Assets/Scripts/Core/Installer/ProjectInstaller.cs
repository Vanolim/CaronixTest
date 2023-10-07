using UnityEngine;
using Zenject;

namespace Core
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField]
        private SceneLoaderView _sceneLoaderView;

        [SerializeField]
        private SceneLinksData _sceneLinksData;

        public override void InstallBindings()
        {
            this.BindPrefab(Container, _sceneLoaderView);
            Container.Bind<SaveLoadService>().AsSingle();
            Container.Bind<SessionProgressService>().AsSingle();
            Container.BindInstance(_sceneLinksData);
            Container.BindInterfacesAndSelfTo<SceneLinks>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            Container.Bind<PlayerNameService>().AsSingle();
            Container.Bind<CoinService>().AsSingle();
            Container.BindInstance(new CoroutineService(this)).AsSingle();
        }
    }
}