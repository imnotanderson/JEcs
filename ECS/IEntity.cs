using System;
using System.Collections.Generic;
using System.Linq;

namespace J.ECS
{
    public abstract class IEntity
    {
        Dictionary<Type,IComponent> components = new Dictionary<Type, IComponent>();
        
        public IEntity AddComponent(IComponent component)
        {
            components[component.GetType()] = component;
            return this;
        }

        public IEntity RemoveComponent<T>()
        {
            var t = typeof(T);
            components.Remove(t);
            return this;
        }

        public T GetComponent<T>()
        {
            var t = typeof(T);
            IComponent val = null;
            components.TryGetValue(t, out val);
            return (T) val;
        }
        
        public bool HasComponents(params Type[] componentTypes)
        {
            if(components.Count == 0)
            { return false; }
            return componentTypes.All(x => components.ContainsKey(x));
        }
    }
    
}