using UnityEngine.Events;

namespace Munderwood.Events.Click 
{
    [System.Serializable]
    public class ClickEvent<T,U>: UnityEvent<T,U>, IEventTwoArgs
    {
        public void AddListener(object call)
        {
            UnityAction<T, U> eventToAdd = (UnityAction<T, U>) call;
            base.AddListener(eventToAdd);
        }

        public void Invoke(object invoking, object invoking2)
        {
            T arg = (T) invoking;
            U arg2 = (U) invoking2;
            base.Invoke(arg,arg2);
        }

    }

    public interface IEventTwoArgs
    {
        void AddListener(object call);
        void Invoke(object invoking, object invoking2);
    }
}