using UnityEngine.EventSystems;

namespace Munderwood.Events
{
    public interface IPointerData
    {
        void SetPointerEventData(PointerEventData pointerEventData);
    }
}