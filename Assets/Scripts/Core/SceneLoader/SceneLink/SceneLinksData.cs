using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "SceneLinksData", menuName = "Data/Core/SceneLinksData")]
    public class SceneLinksData : ScriptableObject
    {
        [SerializeField]
        private SceneLink[] _sceneLinks;

        public IReadOnlyList<SceneLink> SceneLinks => _sceneLinks;
    }
}