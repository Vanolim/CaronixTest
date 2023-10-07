using Core;
using Zenject;

namespace SearchEnemy
{
    public class PlayerInfoViewMediator : IInitializable
    {
        private readonly PlayerInfoView _playerInfoView;
        private readonly PlayerNameService _playerNameService;
        private readonly CoinService _coinService;

        public PlayerInfoViewMediator(CoinService coinService, PlayerNameService playerNameService,
            PlayerInfoView playerInfoView)
        {
            _coinService = coinService;
            _playerNameService = playerNameService;
            _playerInfoView = playerInfoView;
        }

        private void SetPlayerInfoView()
        {
            _playerInfoView.SetPlayerCoinValue(_coinService.GetValue());
            _playerInfoView.SetPlayerName(_playerNameService.GetName());
        }

        public void Initialize()
        {
            SetPlayerInfoView();
        }
    }
}