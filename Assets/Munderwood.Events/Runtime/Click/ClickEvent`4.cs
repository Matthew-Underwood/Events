using UnityEngine.Events;

namespace Munderwood.Events.Click
{
    [System.Serializable]
    public class ClickEvent<T,U,V,W>: UnityEvent<T,U,V,W>, IEventFourArgs
    {
        public void AddListener(object call)
        {
            UnityAction<T,U,V,W> eventToAdd = (UnityAction<T,U,V,W>) call;
            base.AddListener(eventToAdd);
        }

        public void Invoke(object invoking, object invoking2, object invoking3, object invoking4)
        {
            T arg = (T) invoking;
            U arg2 = (U) invoking2;
            V arg3 = (V) invoking3;
            W arg4 = (W) invoking4;
            base.Invoke(arg,arg2,arg3,arg4);
        }
    }
    
    public interface IEventFourArgs
    {
        void AddListener(object call);
        void Invoke(object invoking, object invoking2, object invoking3, object invoking4);
    }
}