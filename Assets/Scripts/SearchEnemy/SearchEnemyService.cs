using Core;
using Zenject;

namespace SearchEnemy
{
    public class SearchEnemyService : IInitializable,
        ILateDisposable
    {
        private readonly EnemyLoader _enemyLoader;
        private readonly EnemyInfoView _enemyInfoView;
        private readonly SearchEnemyView _searchEnemyView;
        private readonly SceneLoader _sceneLoader;
        private readonly SessionProgressService _sessionProgressService;

        private EnemyInfo _enemyInfo;

        public SearchEnemyService(EnemyLoader enemyLoader, EnemyInfoView enemyInfoView, 
            SearchEnemyView searchEnemyView, SceneLoader sceneLoader, SessionProgressService sessionProgressService)
        {
            _enemyLoader = enemyLoader;
            _enemyInfoView = enemyInfoView;
            _searchEnemyView = searchEnemyView;
            _sceneLoader = sceneLoader;
            _sessionProgressService = sessionProgressService;
        }

        private async void SetEnemyInfo()
        {
            EnemyInfo enemyInfo = await _enemyLoader.GetEnemy();
            _enemyInfo = enemyInfo;
            _enemyInfoView.SetAvatar(enemyInfo.Avatar);
            _enemyInfoView.SetName(enemyInfo.Name);
        }

        private void LoadNextScene()
        {
            _sessionProgressService.TemporaryData.EnemyInfo = _enemyInfo;
            _sceneLoader.Load(LoadableScene.Battle);
        }

        public void Initialize()
        {
            SetEnemyInfo();
            _searchEnemyView._search.onClick.AddListener(SetEnemyInfo);
            _searchEnemyView._next.onClick.AddListener(LoadNextScene);
        }

        public void LateDispose()
        {
            _searchEnemyView._search.onClick.RemoveListener(SetEnemyInfo);
            _searchEnemyView._next.onClick.RemoveListener(LoadNextScene);
        }
    }
}