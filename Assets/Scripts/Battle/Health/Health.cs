using System;

namespace Battle
{
    public class Health : IHealth
    {
        private readonly int _initValue;
        private int _value;
        
        public event Action OnEmpty;
        public event Action<float> OnValueChangeDelta;

        public Health(int initValue)
        {
            _value = initValue;
            _initValue = _value;
        }

        private float GetValueDelta() => (float)_value / _initValue;

        public void DecreaseValue(int value)
        {
            if(_value <= 0)
                return;

            if (_value - value <= 0)
            {
                _value = 0;
                OnValueChangeDelta?.Invoke(GetValueDelta());
                OnEmpty?.Invoke();
                return;
            }

            _value -= value;
            OnValueChangeDelta?.Invoke(GetValueDelta());
        }
    }
}