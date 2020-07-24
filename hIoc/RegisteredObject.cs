using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace hIoc
{
    public class RegisteredUnityObject : RegisteredObject
    {
        public RegisteredUnityObject(Type type, Type concrete, LifeCycle lifeCycle, GameObject gObject) 
            : base(type, concrete, lifeCycle)
        {
            TypeToResolve = type;
            ConcreteType = concrete;
            LifeCycle = lifeCycle;
            Instance = gObject;
        }

        public new object Instance { get; private set; }

        public void CreateInstance(GameObject gObject, params object[] args)
        {
            Instance = Object.Instantiate(gObject);
        }
    }
    
    public class RegisteredObject
    {
        public RegisteredObject(Type type, Type concrete, LifeCycle lifeCycle)
        {
            TypeToResolve = type;
            ConcreteType = concrete;
            LifeCycle = lifeCycle;
        }

        public LifeCycle LifeCycle { get; set; }
        public Type ConcreteType { get; set; }
        public Type TypeToResolve { get; set; }

        public object Instance { get; private set; }

        public void CreateInstance(params object[] args)
        {
            Instance = Activator.CreateInstance(ConcreteType, args);
        }
    }
}