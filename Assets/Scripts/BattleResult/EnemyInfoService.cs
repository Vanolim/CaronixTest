using Core;
using SearchEnemy;
using Zenject;

namespace BattleResult
{
    public class EnemyInfoService : IInitializable
    {
        private readonly SessionProgressService _sessionProgressService;
        private readonly BattleResultEnemyInfoView _battleResultEnemyInfoView;

        public EnemyInfoService(SessionProgressService sessionProgressService, BattleResultEnemyInfoView battleResultEnemyInfoView)
        {
            _sessionProgressService = sessionProgressService;
            _battleResultEnemyInfoView = battleResultEnemyInfoView;
        }

        public void Initialize()
        {
            EnemyInfo enemyInfo = _sessionProgressService.TemporaryData.EnemyInfo;
            _battleResultEnemyInfoView.SetAvatar(enemyInfo.Avatar);
            _battleResultEnemyInfoView.SetName(enemyInfo.Name);
        }
    }
}