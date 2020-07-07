using System;
using UnityEngine.Events;

namespace Munderwood.Events.Click
{
    [Serializable]
    public class ClickEvent<T, U> : UnityEvent<T, U>, IEventTwoArgs
    {
        public void AddListener(object call)
        {
            var eventToAdd = (UnityAction<T, U>) call;
            base.AddListener(eventToAdd);
        }

        public void Invoke(object invoking, object invoking2)
        {
            var arg = (T) invoking;
            var arg2 = (U) invoking2;
            base.Invoke(arg, arg2);
        }
    }
}