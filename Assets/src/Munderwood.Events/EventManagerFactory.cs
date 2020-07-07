using System;
using UnityEngine;

namespace Munderwood.Events
{
    public class EventManagerFactory
    {
        public EventManager Create(GameObject controller, Type controllerType, string methodName)
        {
            return new EventManager(controller, controllerType, methodName);
        }
    }
}