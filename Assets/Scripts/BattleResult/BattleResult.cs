using Core;
using Zenject;

namespace BattleResult
{
    public class BattleResult : IInitializable,
        ILateDisposable
    {
        private readonly BattleResultView _battleResultView;
        private readonly SceneLoader _sceneLoader;
        private readonly CoinService _coinService;
        private readonly SessionProgressService _sessionProgressService;

        public BattleResult(BattleResultView battleResultView, SceneLoader sceneLoader, 
            CoinService coinService, SessionProgressService sessionProgressService)
        {
            _battleResultView = battleResultView;
            _sceneLoader = sceneLoader;
            _coinService = coinService;
            _sessionProgressService = sessionProgressService;
        }

        private void AddReward()
        {
            int reward = _sessionProgressService.TemporaryData.RewardValue;
            _coinService.AddValue(reward);
            _battleResultView.SetReward(reward);
        }

        private void LoadNext() => _sceneLoader.Load(LoadableScene.SearchEnemy);

        public void Initialize()
        {
            AddReward();
            _battleResultView.Next.onClick.AddListener(LoadNext);
        }

        public void LateDispose()
        {
            _battleResultView.Next.onClick.RemoveListener(LoadNext);
        }
    }
}