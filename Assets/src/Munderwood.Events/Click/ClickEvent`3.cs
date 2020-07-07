using System;
using UnityEngine.Events;

namespace Munderwood.Events.Click
{
    [Serializable]
    public class ClickEvent<T, U, V> : UnityEvent<T, U, V>, IEventThreeArgs
    {
        public void AddListener(object call)
        {
            var eventToAdd = (UnityAction<T, U, V>) call;
            base.AddListener(eventToAdd);
        }

        public void Invoke(object invoking, object invoking2, object invoking3)
        {
            var arg = (T) invoking;
            var arg2 = (U) invoking2;
            var arg3 = (V) invoking3;
            base.Invoke(arg, arg2, arg3);
        }
    }
}