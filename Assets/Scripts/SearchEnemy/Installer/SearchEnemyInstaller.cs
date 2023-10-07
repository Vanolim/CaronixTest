using Core;
using UnityEngine;
using Zenject;

namespace SearchEnemy
{
    public class SearchEnemyInstaller : MonoInstaller
    {
        [SerializeField]
        private EnemyInfoView _enemyInfoView;

        [SerializeField]
        private SearchEnemyView _searchEnemyView;

        [SerializeField]
        private SearchEnemyLoadView _searchEnemyLoadView;

        [SerializeField]
        private PlayerInfoView _playerInfoView;
        
        public override void InstallBindings()
        {
            this.BindPrefab(Container, _searchEnemyLoadView);
            this.BindPrefab(Container, _enemyInfoView);
            this.BindPrefab(Container, _searchEnemyView);
            this.BindPrefab(Container, _playerInfoView);
            Container.BindInterfacesAndSelfTo<EnemyLoader>().AsSingle();
            Container.BindInterfacesTo<SearchEnemyService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PlayerInfoViewMediator>().AsSingle().NonLazy();
        }
    }
}