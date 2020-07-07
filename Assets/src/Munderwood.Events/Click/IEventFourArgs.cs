namespace Munderwood.Events.Click
{
    public interface IEventFourArgs
    {
        void AddListener(object call);
        void Invoke(object invoking, object invoking2, object invoking3, object invoking4);
    }
}