using System;
using System.Reflection;
using Munderwood.Events.Click;
using UnityEngine;
using UnityEngine.Events;

namespace Munderwood.Events
{
    public class EventManager
    {
        private readonly GameObject _controllerGameObject;
        private readonly MethodInfo _controllerMethod;
        private readonly Type _controllerType;
        private object[] _arguments;
        private UnityEvent _clickEvent;
        private IEventFourArgs _clickEventFourArgs;
        private IEventOneArg _clickEventOneArg;
        private IEventThreeArgs _clickEventThreeArgs;
        private IEventTwoArgs _clickEventTwoArgs;


        public EventManager(GameObject controller, Type controllerType, string methodName)
        {
            _controllerGameObject = controller;
            //TODO most likely dont need to pass this in
            _controllerType = controllerType;
            _controllerMethod = _controllerType.GetMethod(methodName);
            _arguments = new object[] { };
        }

        public void AddListener()
        {
            var eventClick = new UnityEvent();
            eventClick.AddListener(
                () =>
                {
                    _controllerMethod.Invoke(_controllerGameObject.GetComponent(_controllerType), new object[] { });
                });
            _clickEvent = eventClick;
        }

        public void AddListener<T>(T val)
        {
            var eventClick = new ClickEvent<T>();
            eventClick.AddListener(
                a =>
                {
                    _controllerMethod.Invoke(_controllerGameObject.GetComponent(_controllerType), new object[] {a});
                });
            _clickEventOneArg = eventClick;
            _arguments = new object[] {val};
        }

        public void AddListener<T, T2>(T val, T2 val2)
        {
            var eventClick = new ClickEvent<T, T2>();
            eventClick.AddListener(
                (a, b) =>
                {
                    _controllerMethod.Invoke(_controllerGameObject.GetComponent(_controllerType), new object[] {a, b});
                });
            _clickEventTwoArgs = eventClick;
            _arguments = new object[] {val, val2};
        }

        public void AddListener<T, T2, T3>(T val, T2 val2, T3 val3)
        {
            var eventClick = new ClickEvent<T, T2, T3>();
            eventClick.AddListener(
                (a, b, c) =>
                {
                    _controllerMethod.Invoke(_controllerGameObject.GetComponent(_controllerType),
                        new object[] {a, b, c});
                });
            _clickEventThreeArgs = eventClick;
            _arguments = new object[] {val, val2, val3};
        }

        public void AddListener<T, T2, T3, T4>(T val, T2 val2, T3 val3, T4 val4)
        {
            var eventClick = new ClickEvent<T, T2, T3, T4>();
            eventClick.AddListener(
                (a, b, c, d) =>
                {
                    _controllerMethod.Invoke(_controllerGameObject.GetComponent(_controllerType),
                        new object[] {a, b, c, d});
                });
            _clickEventFourArgs = eventClick;
            _arguments = new object[] {val, val2, val3, val4};
        }

        public void Invoke()
        {
            switch (_arguments.Length)
            {
                case 0:
                    _clickEvent.Invoke();
                    break;
                case 1:
                    _clickEventOneArg.Invoke(_arguments[0]);
                    break;
                case 2:
                    _clickEventTwoArgs.Invoke(_arguments[0], _arguments[1]);
                    break;
                case 3:
                    _clickEventThreeArgs.Invoke(_arguments[0], _arguments[1], _arguments[2]);
                    break;
                case 4:
                    _clickEventFourArgs.Invoke(_arguments[0], _arguments[1], _arguments[2], _arguments[3]);
                    break;
            }
        }
    }
}