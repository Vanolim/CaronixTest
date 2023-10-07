using System;

namespace Battle
{
    public interface IHealth
    {
        public event Action OnEmpty;
        public event Action<float> OnValueChangeDelta;
    }
}