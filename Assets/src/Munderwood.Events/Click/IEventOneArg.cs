namespace Munderwood.Events.Click
{
    public interface IEventOneArg
    {
        void AddListener(object call);
        void Invoke(object invoking);
    }
}