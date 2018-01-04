using System;
using System.Collections.Generic;
using System.Linq;

namespace J.ECS
{
    public abstract class IEntity
    {
        public ulong id;
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

        public static bool operator ==(IEntity e1, IEntity e2)
        {
            return e1.id == e2.id;
        }

        public static bool operator !=(IEntity e1, IEntity e2)
        {
            return !(e1 == e2);
        }
    }
    
}