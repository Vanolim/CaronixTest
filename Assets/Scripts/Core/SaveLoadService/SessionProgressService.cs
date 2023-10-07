namespace Core
{
    public class SessionProgressService
    {
        private readonly SaveLoadService _saveLoadService;

        public TemporaryData TemporaryData { get; }

        public SessionProgressService(SaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            TemporaryData = new TemporaryData();
        }

        public GameData GameData
        {
            get => _saveLoadService.GameData;
            set
            {
                _saveLoadService.GameData = value;
                _saveLoadService.SaveProgress();
            }
        }
    }
}