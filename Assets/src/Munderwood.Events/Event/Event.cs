using System;
using UnityEngine.Events;

namespace Munderwood.Events.Event
{
        [Serializable]
        public class Event : UnityEvent , IEvent
        {
            public object[] Values { get; set; }

            public void AddListener(object call)
            {
                var eventToAdd = (UnityAction) call;
                base.AddListener(eventToAdd);
            }

            public void Invoke(object invoking)
            {
                base.Invoke();
            }
        }
}