using Core;
using UnityEngine;
using Zenject;

namespace BattleResult
{
    public class BattleResultInstaller : MonoInstaller
    {
        [SerializeField]
        private BattleResultEnemyInfoView _battleResultEnemyInfoView;

        [SerializeField]
        private BattleResultView _battleResultView;
        
        public override void InstallBindings()
        {
            this.BindPrefab(Container, _battleResultEnemyInfoView);
            this.BindPrefab(Container, _battleResultView);
            Container.BindInterfacesTo<BattleResult>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemyInfoService>().AsSingle().NonLazy();
        }
    }
}