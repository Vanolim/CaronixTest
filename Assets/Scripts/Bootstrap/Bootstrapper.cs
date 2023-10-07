using Core;
using Zenject;

namespace Main
{
    public class Bootstrapper : IInitializable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly PlayerNameService _playerNameService;

        private const float _delay = 2f;

        public Bootstrapper(SceneLoader sceneLoader, PlayerNameService playerNameService)
        {
            _sceneLoader = sceneLoader;
            _playerNameService = playerNameService;
        }

        private void LoadNextScene()
        {
            LoadableScene nextScene = GetNextScene();
            _sceneLoader.Load(nextScene, _delay);
        }

        private LoadableScene GetNextScene()
        {
            if (_playerNameService.IsNameEmpty())
                return LoadableScene.Identification;

            return LoadableScene.SearchEnemy;
        }

        public void Initialize()
        {
            LoadNextScene();
        }
    }
}