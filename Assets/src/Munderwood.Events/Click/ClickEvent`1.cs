using System;
using UnityEngine.Events;

namespace Munderwood.Events.Click
{
    [Serializable]
    public class ClickEvent<T> : UnityEvent<T>, IEventOneArg
    {
        public void AddListener(object call)
        {
            var eventToAdd = (UnityAction<T>) call;
            base.AddListener(eventToAdd);
        }

        public void Invoke(object invoking)
        {
            var arg = (T) invoking;
            base.Invoke(arg);
        }
    }
}