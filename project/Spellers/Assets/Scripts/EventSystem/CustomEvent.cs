using System;
using System.Collections.Generic;
using System.Linq;


namespace CustomEventSystem
{
    public class CustomEvent
    {
        private event Action action = delegate { };

        public void Invoke()
        {
            action?.Invoke();
        }

        public void AddListener(Action listener)
        {
            action += listener;
        }

        public void RemoveListener(Action listener)
        {
            action -= listener;
        }
    }

    public class CustomEvent<T>
    {
        private event Action<T> action = delegate { };

        public void Invoke(T param)
        {
            action?.Invoke(param);
        }

        public void AddListener(Action<T> listener)
        {
            action += listener;
        }

        public void RemoveListener(Action<T> listener)
        {
            action -= listener;
        }
    }

    public class CustomEvent<T1, T2>
    {
        private event Action<T1,T2> action = delegate { };

        public void Invoke(T1 param, T2 param2)
        {
            action?.Invoke(param, param2);
        }

        public void AddListener(Action<T1, T2> listener)
        {
            action += listener;
        }

        public void RemoveListener(Action<T1, T2> listener)
        {
            action -= listener;
        }
    }
}
