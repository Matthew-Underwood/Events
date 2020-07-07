using System;
using System.Reflection;
using Munderwood.Events.Click;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Munderwood.Events
{
    public class PointerDataEventManager
    {
        private readonly GameObject _controller;
        private readonly Type _controllerType;
        private readonly MethodInfo method;
        private IEventOneArg pointerEvent;
        private object[] arguments;
        

        public PointerDataEventManager (GameObject controller, Type controllerType,  string methodName)
        {
            _controller = controller;
            _controllerType = controllerType;
            method = _controllerType.GetMethod(methodName);
        }
        
        public void AddListener (PointerEventData pointerEventData)
        {
            ClickEvent<PointerEventData> eventClick = new ClickEvent<PointerEventData>();
            eventClick.AddListener(
                (PointerEventData a) => { method.Invoke(_controller.GetComponent(_controllerType), new object[] {a});
                });
            pointerEvent = eventClick;
        }
        
        public void AssignValues (PointerEventData pointerEventData)
        {
            arguments = new object[] {pointerEventData};
        }
        
        public void Invoke()
        {
            pointerEvent.Invoke(arguments[0]);
        }
        
    }
}