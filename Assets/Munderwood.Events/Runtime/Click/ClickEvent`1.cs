using UnityEngine.Events;

namespace Munderwood.Events.Click 
{
    [System.Serializable]
    public class ClickEvent<T>: UnityEvent<T>, IEventOneArg
    {
        public void AddListener(object call)
        {
            UnityAction<T> eventToAdd = (UnityAction<T>) call;
            base.AddListener(eventToAdd);
        }

        public void Invoke(object invoking)
        {
            T arg = (T) invoking;
            base.Invoke(arg);
        }

    }

    public interface IEventOneArg
    {
        void AddListener(object call);
        void Invoke(object invoking);
    }
}