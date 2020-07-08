using System;
using UnityEngine.Events;

namespace Munderwood.Events.Event
{
    [Serializable]
    public class Event<T> : UnityEvent<T>, IEvent
    {
        public object[] Values { get; set; }

        public void AddListener(object call)
        {
            var eventToAdd = (UnityAction<T>) call;
            base.AddListener(eventToAdd);
        }

        public void Invoke()
        {
            var arg = (T) Values[0];
            base.Invoke(arg);
        }
    }
}