namespace Core
{
    public class PlayerNameService
    {
        private readonly SessionProgressService _sessionProgressService;

        public PlayerNameService(SessionProgressService sessionProgressService)
        {
            _sessionProgressService = sessionProgressService;
        }

        public string GetName() => _sessionProgressService.GameData.PlayerName;
        public bool IsNameEmpty() => GetName() == default;

        public void SaveName(string newName)
        {
            GameData gameData = _sessionProgressService.GameData;
            gameData.PlayerName = newName;
            _sessionProgressService.GameData = gameData;
        }
    }
}