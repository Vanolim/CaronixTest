using Core;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class Battle : IInitializable,
        ILateDisposable
    {
        private readonly Enemy _enemy;
        private readonly SceneLoader _sceneLoader;
        private readonly SessionProgressService _sessionProgressService;
        private readonly EnemyData _enemyData;
        private readonly BattleFinishView _battleFinishView;
        private readonly PlayerNameService _playerNameService;

        private const float _delayLoadScene = 2f;

        public Battle(Enemy enemy, SceneLoader sceneLoader, SessionProgressService sessionProgressService, 
            EnemyData enemyData, BattleFinishView battleFinishView, PlayerNameService playerNameService)
        {
            _enemy = enemy;
            _sceneLoader = sceneLoader;
            _sessionProgressService = sessionProgressService;
            _enemyData = enemyData;
            _battleFinishView = battleFinishView;
            _playerNameService = playerNameService;
        }

        private void LoadNextScene()
        {
            ActivateFinishView();
            SaveRewardValue();
            _sceneLoader.Load(LoadableScene.BattleResult, _delayLoadScene);
        }

        private void SaveRewardValue() => 
            _sessionProgressService.TemporaryData.RewardValue = GetRandomRewardValue();

        private int GetRandomRewardValue() =>
            Random.Range((int)_enemyData.MinMaxReward.x, (int)_enemyData.MinMaxReward.y);

        private void ActivateFinishView()
        {
            _battleFinishView.SetPlayerName(_playerNameService.GetName());
            _battleFinishView.Activate();
        }

        public void Initialize()
        {
            _enemy.Health.OnEmpty += LoadNextScene;
        }

        public void LateDispose()
        {
            _enemy.Health.OnEmpty -= LoadNextScene;
        }
    }
}