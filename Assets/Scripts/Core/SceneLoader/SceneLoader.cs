using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader
    {
        private readonly SceneLoaderView _sceneLoaderView;
        private readonly SceneLinks _sceneLinks;
        private readonly CoroutineService _coroutineService;

        public SceneLoader(SceneLoaderView sceneLoaderView, SceneLinks sceneLinks, CoroutineService coroutineService)
        {
            _sceneLoaderView = sceneLoaderView;
            _sceneLinks = sceneLinks;
            _coroutineService = coroutineService;
        } 
        
        private IEnumerator Load(string sceneName, float delay, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            yield return new WaitForSeconds(delay);
            var operation = SceneManager.LoadSceneAsync(sceneName);

            if (loadSceneMode == LoadSceneMode.Single)
                _coroutineService.StartCoroutine(AnimateLoadingBar(operation));
        }

        private IEnumerator AnimateLoadingBar(AsyncOperation operation)
        {
            _sceneLoaderView.Activate();
            
            while (operation.isDone == false)
            {
                yield return null;
            }
            
            _sceneLoaderView.Deactivate();
        }

        public void Load(LoadableScene scene, float delay = 0) => 
            _coroutineService.StartCoroutine(Load(_sceneLinks.GetSceneName(scene), delay));
    }
}