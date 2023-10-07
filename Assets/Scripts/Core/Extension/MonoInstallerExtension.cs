using UnityEngine;
using Zenject;

namespace Core
{
    public static class MonoInstallerExtension
    {
        public static void BindPrefab<T>(this MonoInstaller monoInstaller, 
            DiContainer diContainer, T obj) where T : MonoBehaviour
        {
            T instance = GameObject.Instantiate(obj, monoInstaller.transform);
            diContainer.QueueForInject(instance);

            diContainer
                .Bind<T>()
                .FromInstance(instance)
                .AsSingle();
        }
    }
}