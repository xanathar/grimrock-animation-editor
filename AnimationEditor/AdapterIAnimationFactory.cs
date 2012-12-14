using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimationEditor
{
    public class AdapterIAnimationFactory
    {
        Dictionary<Type, Func<object, AdapterIAnimationFactory, IAnimationAdapter>> m_FactoryMethods = new Dictionary<Type, Func<object, AdapterIAnimationFactory, IAnimationAdapter>>();

        public void RegisterFactoryMethod<T>(Func<T, AdapterIAnimationFactory, IAnimationAdapter> adapterFactoryMethod)
        {
            RegisterFactoryMethod(typeof(T), (o, a) => adapterFactoryMethod((T)o, a));
        }

        public void RegisterFactoryMethod(Type t, Func<object, AdapterIAnimationFactory, IAnimationAdapter> adapterFactoryMethod)
        {
            m_FactoryMethods.Add(t, adapterFactoryMethod);
        }

        public IAnimation GetAdapter(object o)
        {
            return m_FactoryMethods[o.GetType()](o, this);
        }
    }
}
