
using System;
using System.Reflection;
using Munderwood.Events.Click;
using UnityEngine;
using UnityEngine.Events;

namespace Munderwood.Events
{
    public class EventManager
    {
        private readonly GameObject _gameObject;
        private readonly Type _controllerType;
        private readonly MethodInfo method;
        private UnityEvent _clickEvent;
        private IEventOneArg _clickEventOneArg;
        private IEventTwoArgs _clickEventTwoArgs;
        private IEventThreeArgs _clickEventThreeArgs;
        private IEventFourArgs _clickEventFourArgs;
        private object[] arguments;
        

        public EventManager(GameObject controller, Type controllerType, string methodName)
        {
            _gameObject = controller;
            _controllerType = controllerType;
            method = _controllerType.GetMethod(methodName);
            arguments = new object[]{};
        }
        
        public void AddListener ()
        {
            UnityEvent eventClick = new UnityEvent();
            eventClick.AddListener(
                () => { method.Invoke(_gameObject.GetComponent(_controllerType), new object[] {});
                });
            _clickEvent = eventClick;
        }
        
        public void AddListener <T>(T val)
        {
            ClickEvent<T> eventClick = new ClickEvent<T>();
            eventClick.AddListener(
                (T a) => { method.Invoke(_gameObject.GetComponent(_controllerType), new object[] {a});
                });
            _clickEventOneArg = eventClick;
        }
        
        public void AddListener <T,T2>(T val,T2 val2)
        {
            ClickEvent<T,T2> eventClick = new ClickEvent<T, T2>();
            eventClick.AddListener(
                (T a,T2 b) => { method.Invoke(_gameObject.GetComponent(_controllerType), new object[] {a,b});
                });
            _clickEventTwoArgs = eventClick;
        }
        
        public void AddListener <T,T2,T3>(T val,T2 val2,T3 val3)
        {
            ClickEvent<T,T2, T3> eventClick = new ClickEvent<T, T2, T3>();
            eventClick.AddListener(
                (T a,T2 b,T3 c) => { method.Invoke(_gameObject.GetComponent(_controllerType), new object[] {a,b,c});
                });
            _clickEventThreeArgs = eventClick;
        }

        public void AddListener <T,T2,T3,T4> (T val,T2 val2,T3 val3,T4 val4)
        {
            ClickEvent<T,T2, T3,T4> eventClick = new ClickEvent<T, T2, T3,T4>();
            eventClick.AddListener(
                (T a,T2 b,T3 c,T4 d) => { method.Invoke(_gameObject.GetComponent(_controllerType), new object[] {a,b,c,d});
                });
            _clickEventFourArgs = eventClick;
        }
        //TODO make private and call in the add listener method
        public void AssignValues <T>(T val)
        {
            arguments = new object[] {val};
        }

        //TODO make private and call in the add listener method
        public void AssignValues <T,T2>(T val,T2 val2)
        {
            arguments = new object[] {val,val2};
        }

        //TODO make private and call in the add listener method
        public void AssignValues <T,T2,T3>(T val,T2 val2,T3 val3)
        {
            arguments = new object[] {val,val2,val3};
        }

        //TODO make private and call in the add listener method
        public void AssignValues <T,T2,T3,T4>(T val,T2 val2,T3 val3,T4 val4)
        {
            arguments = new object[] {val,val2,val3,val4};
        }
        
        public void Invoke()
        {
            switch (arguments.Length)
            {
                case 0:
                    _clickEvent.Invoke();
                    break;
                case 1:
                    _clickEventOneArg.Invoke(arguments[0]);
                    break;
                case 2:
                    _clickEventTwoArgs.Invoke(arguments[0],arguments[1]);
                    break;
                case 3:
                    _clickEventThreeArgs.Invoke(arguments[0],arguments[1],arguments[2]);
                    break;
                case 4:
                    _clickEventFourArgs.Invoke(arguments[0],arguments[1],arguments[2],arguments[3]);
                    break;
                
            }
        }
        
    }
}