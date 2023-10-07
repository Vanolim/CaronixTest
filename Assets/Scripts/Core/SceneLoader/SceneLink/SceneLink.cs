using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class SceneLink
    {
        [SerializeField]
        private LoadableScene _loadableScene;
        
        [SerializeField]
        private string _name;

        public LoadableScene LoadableScene => _loadableScene;
        public string Name => _name;
    }
}