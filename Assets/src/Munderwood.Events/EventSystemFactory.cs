using UnityEngine;

namespace Munderwood.Events
{
    public class EventSystemFactory
    {
        public void Create()
        {
            Object.Instantiate(Resources.Load<GameObject>("EventSystem"));
        }
    }
}