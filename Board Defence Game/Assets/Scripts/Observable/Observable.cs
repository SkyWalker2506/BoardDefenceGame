using System;

namespace Observables
{
    public class Observable<T> 
    {
        private T value;
        public T Value
        {
            get => value;
            set
            {
                if (value.Equals(this.value))
                {
                    return;
                }
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }
        public Action<T> OnValueChanged;
    }
}



