using Core;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class BattleInstaller : MonoInstaller
    {
        [SerializeField]
        private EnemyBarView _enemyBarView;

        [SerializeField]
        private BattleFinishView _battleFinishView;

        [SerializeField]
        private Background _background;

        [SerializeField]
        private EnemyData _enemyData;

        [SerializeField]
        private EnemyViewContainer _enemyViewContainer;

        [SerializeField]
        private Transform _enemyContainer;
        
        [SerializeField]
        private PlayerData _playerData;
        
        public override void InstallBindings()
        {
            this.BindPrefab(Container, _background);
            this.BindPrefab(Container, _battleFinishView);
            Container.BindInstance(GetEnemy()).AsSingle();
            Container.BindInstance(_playerData).AsSingle();
            Container.BindInstance(_enemyData).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
            Container.BindInterfacesTo<PlayerDamage>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemyHealthViewMediator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<Battle>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemyMovement>().AsSingle().NonLazy();
        }

        private Enemy GetEnemy()
        {
            EnemyFactory enemyFactory = new EnemyFactory();
            SessionProgressService sessionProgressService =
                Container.Resolve<SessionProgressService>();
            
            return enemyFactory.GetEnemy(_enemyViewContainer, _enemyBarView, _enemyData, _enemyContainer,
                sessionProgressService.TemporaryData.EnemyInfo);
        }
    }
}