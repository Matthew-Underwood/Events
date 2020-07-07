namespace Munderwood.Events.Click
{
    public interface IEventThreeArgs
    {
        void AddListener(object call);
        void Invoke(object invoking, object invoking2, object invoking3);
    }
}