using System;
using System.Collections.Generic;
using Zenject;

namespace Core
{
    public class SceneLinks : IInitializable
    {
        private readonly SceneLinksData _sceneLinksData;
        private Dictionary<LoadableScene, string> _loadableSceneName;

        public SceneLinks(SceneLinksData sceneLinksData)
        {
            _sceneLinksData = sceneLinksData;
        }
        
        public string GetSceneName(LoadableScene loadableScene)
        {
            if(_loadableSceneName.ContainsKey(loadableScene) == false)
            {
                throw new NullReferenceException($"Dont found scene {loadableScene}");
            }
            
            return _loadableSceneName[loadableScene];
        }

        public void Initialize()
        {
            _loadableSceneName = new Dictionary<LoadableScene, string>();
            foreach (var sceneLink in _sceneLinksData.SceneLinks)
            {
                _loadableSceneName.Add(sceneLink.LoadableScene, sceneLink.Name);
            }
        }
    }
}