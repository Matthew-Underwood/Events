namespace Munderwood.Events
{
    public interface IEventInvoker
    {
        void SetEventInvoker(EventManager eventManager);
        void SetPointerDataEventInvoker(PointerDataEventManager pointerDataEventManager);
    }
}