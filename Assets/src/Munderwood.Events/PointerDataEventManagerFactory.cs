using System;
using UnityEngine;

namespace Munderwood.Events
{
    public class PointerDataEventManagerFactory
    {
        public PointerDataEventManager Create(GameObject controller, Type controllerType, string methodName)
        {
            return new PointerDataEventManager(controller, controllerType, methodName);
        }
    }
}