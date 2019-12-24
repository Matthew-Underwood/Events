using UnityEngine.Events;

namespace Munderwood.Events.Click
{
    [System.Serializable]
    public class ClickEvent<T,U,V>: UnityEvent<T,U,V>, IEventThreeArgs
    {
        public void AddListener(object call)
        {
            UnityAction<T,U,V> eventToAdd = (UnityAction<T,U,V>) call;
            base.AddListener(eventToAdd);
        }

        public void Invoke(object invoking, object invoking2, object invoking3)
        {
            T arg = (T) invoking;
            U arg2 = (U) invoking2;
            V arg3 = (V) invoking3;
            base.Invoke(arg,arg2,arg3);
        }
    }
    
    public interface IEventThreeArgs
    {
        void AddListener(object call);
        void Invoke(object invoking, object invoking2, object invoking3);
    }
}