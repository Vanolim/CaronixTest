using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class PlayerInput : IInitializable,
        ILateDisposable
    {
        private CompositeDisposable _compositeDisposable;
        private bool _isMobilePlatform;
        
        public event Action<Vector2> OnInput;

        private Vector2 GetInputPosition()
        {
            if (_isMobilePlatform)
            {
                return Input.GetTouch(0).position;
            }
            
            return Input.mousePosition;
        }

        private void SetCurrentPlatform()
        {
            if (Application.isMobilePlatform)
            {
                _isMobilePlatform = true;
            }
            else
            {
                _isMobilePlatform = false;
            }
        }

        public void Initialize()
        {
            SetCurrentPlatform();
            
            _compositeDisposable = new CompositeDisposable();
            
            Observable.EveryUpdate() 
                .Where(_ => Input.GetMouseButtonDown(0))
                .Subscribe (x => { OnInput?.Invoke(GetInputPosition()); })
                .AddTo(_compositeDisposable); 
        }

        public void LateDispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}