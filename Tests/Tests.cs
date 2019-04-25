using System;
using hIoc;
using NUnit.Framework;

namespace Tests
{
    public interface FakeType
    {
    }

    public class ConcreteFakeType : FakeType
    {
    }

    public interface FakeTypeWithConstructorParams
    {
    }

    public class ConcreteFakeTypeWithConstructorParams : FakeTypeWithConstructorParams
    {
        public ConcreteFakeTypeWithConstructorParams(FakeType fakeType)
        {
        }
    }
    
    [TestFixture]
    public class Tests
    {
        [Test]
        public void resolve_object()
        {
            var container = new IocContainer();
            
            container.Register<FakeType, ConcreteFakeType>();

            var instance = container.Resolve<FakeType>();
            
            Assert.That(instance, Is.InstanceOf(typeof(ConcreteFakeType)));
        }

        [Test]
        public void exception_for_bad_type()
        {
            var container = new IocContainer();

            Exception e = null;
            try
            {
                container.Resolve(typeof(FakeType));
            }
            catch (Exception exception)
            {
                e = exception;
            }
            Assert.That(e, Is.InstanceOf(typeof(TypeNotRecognisedException)));
        }

        [Test]
        public void should_resolve_with_parameters()
        {
            var container = new IocContainer();
            
            container.Register<FakeType, ConcreteFakeType>();
            container.Register<FakeTypeWithConstructorParams, ConcreteFakeTypeWithConstructorParams>();

            var instance = container.Resolve<FakeTypeWithConstructorParams>();
            
            Assert.That(instance, Is.InstanceOf(typeof(ConcreteFakeTypeWithConstructorParams)));
        }

        [Test]
        public void can_create_singleton_type()
        {
            var container = new IocContainer();
            
            container.Register<FakeType, ConcreteFakeType>(LifeCycle.Singleton);

            var instance = container.Resolve<FakeType>();
            
            Assert.That(instance, Is.SameAs(container.Resolve<FakeType>()));
        }
        
        [Test]
        public void can_create_singleton_type_by_default()
        {
            var container = new IocContainer();
            
            container.Register<FakeType, ConcreteFakeType>();

            var instance = container.Resolve<FakeType>();
            
            Assert.That(instance, Is.SameAs(container.Resolve<FakeType>()));
        }
        
        [Test]
        public void can_create_transient_type()
        {
            var container = new IocContainer();
            
            container.Register<FakeType, ConcreteFakeType>(LifeCycle.Transient);

            var instance = container.Resolve<FakeType>();
            
            Assert.That(instance, Is.Not.SameAs(container.Resolve<FakeType>()));
        }
    }
}