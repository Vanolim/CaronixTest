using UnityEditor;

#if UNITY_EDITOR

namespace Core
{
    public static class ResetProgress
    {
        private static SaveLoadService _saveLoadService;

        [InitializeOnLoadMethod]
        private static void InitService() => _saveLoadService = new SaveLoadService();

        [MenuItem("Tools/ClearProgress")]
        public static void ClearProgress() => _saveLoadService.ResetProgress();
    }
}

#endif