using UnityEngine;

namespace hIoc
{
    public class UnityContainer : IocContainer
    {
        public void Register<TTypeToResolve, TConcrete>(GameObject gObject)
        {
            Register<TTypeToResolve, TConcrete>(gObject, LifeCycle.Singleton);
        }

        private void Register<TTypeToResolve, TConcrete>(GameObject gObject, LifeCycle lifeCycle)
        {
            registeredObjects.Add(new RegisteredUnityObject(typeof(TTypeToResolve), typeof(TConcrete), lifeCycle, gObject));
        }
    }
    
    public static class BindingExtensions
    {
        static void To(this RegisteredObject registertewdObject)
        {
            
        }
    }
}