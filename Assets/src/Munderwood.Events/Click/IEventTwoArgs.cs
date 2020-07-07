namespace Munderwood.Events.Click
{
    public interface IEventTwoArgs
    {
        void AddListener(object call);
        void Invoke(object invoking, object invoking2);
    }
}