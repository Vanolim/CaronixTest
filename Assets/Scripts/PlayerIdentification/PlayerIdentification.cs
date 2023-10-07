using Core;
using Zenject;

namespace Identification
{
    public class PlayerIdentification : IInitializable,
        ILateDisposable
    {
        private readonly IdentificationView _identificationView;
        private readonly SceneLoader _sceneLoader;
        private readonly PlayerNameService _playerNameService;

        private string _initViewInput;

        public PlayerIdentification(IdentificationView identificationView, SceneLoader sceneLoader,
            PlayerNameService playerNameService)
        {
            _identificationView = identificationView;
            _sceneLoader = sceneLoader;
            _playerNameService = playerNameService;
        }

        private void LoadNextScene()
        {
            if (TrySavePlayerName())
            {
                _sceneLoader.Load(LoadableScene.SearchEnemy);
            }
        }

        private bool TrySavePlayerName()
        {
            string inputName = _identificationView.Input.text;
            if (inputName == _initViewInput)
                return false;

            _playerNameService.SaveName(inputName);
            return true;
        }
        
        public void Initialize()
        {
            _initViewInput = _identificationView.Input.text;
            _identificationView.Next.onClick.AddListener(LoadNextScene);
        }

        public void LateDispose()
        {
            _identificationView.Next.onClick.RemoveListener(LoadNextScene);
        }
    }
}