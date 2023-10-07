namespace Core
{
    public class CoinService
    {
        private readonly SessionProgressService _sessionProgressService;

        public CoinService(SessionProgressService sessionProgressService)
        {
            _sessionProgressService = sessionProgressService;
        }

        private void SaveValue(int value)
        {
            GameData gameData = _sessionProgressService.GameData;
            gameData.CoinsCount = value;
            _sessionProgressService.GameData = gameData;
        }

        public int GetValue() => _sessionProgressService.GameData.CoinsCount;
        
        public void AddValue(int value)
        {
            if (value > 0)
            {
                int saveCoinCount = GetValue() + value;
                SaveValue(saveCoinCount);
            }
        }
    }
}