using System;
using UnityEngine.Events;

namespace Munderwood.Events.Event
{
    [Serializable]
    public class Event<T, U, V, W> : UnityEvent<T, U, V, W>, IEvent
    {
        public object[] Values { get; set; }

        public void AddListener(object call)
        {
            var eventToAdd = (UnityAction<T, U, V, W>) call;
            base.AddListener(eventToAdd);
        }
        public void Invoke()
        {
            var arg = (T) Values[0];
            var arg2 = (U) Values[1];
            var arg3 = (V) Values[2];
            var arg4 = (W) Values[3];
            base.Invoke(arg, arg2, arg3, arg4);
        }
    }
}