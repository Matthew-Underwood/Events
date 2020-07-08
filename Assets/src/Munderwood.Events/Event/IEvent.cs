namespace Munderwood.Events.Event
{
    public interface IEvent
    {
        object[] Values { get; set; }
        void AddListener(object call);
        void Invoke();
    }
}