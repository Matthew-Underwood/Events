using System;
using UnityEngine.Events;

namespace Munderwood.Events.Event
{
    [Serializable]
    public class Event<T, U> : UnityEvent<T, U>, IEvent
    {
        public object[] Values { get; set; }

        public void AddListener(object call)
        {
            var eventToAdd = (UnityAction<T, U>) call;
            base.AddListener(eventToAdd);
        }

        public void Invoke()
        {
            var arg = (T) Values[0];
            var arg2 = (U) Values[1];
            base.Invoke(arg, arg2);
        }
    }
}