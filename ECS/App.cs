using System.Collections.Generic;

namespace J.ECS
{
    public abstract class App
    {
        private Msg msg = new Msg();
        private List<ISystem> systems = new List<ISystem>();
        private List<IEntity> entities = new List<IEntity>();

        public void Init()
        {
            OnInit();
            OnStart();
        }

        protected abstract void OnInit();
        protected abstract void OnStart();

        public void Upt()
        {
            foreach (var system in systems)
            {
                system.Selector(entities);
            }
        }

        protected void AddSystem(object sign, ISystem system)
        {
            systems.Add(system);
            msg.ListenMsg(sign, () => system.Selector(entities));
        }
        
        protected void AddSystem<T>(object sign, ISystem system)
        {
            systems.Add(system);
            msg.ListenMsg<T>(sign, (t) => system.Selector(entities, t));
        }
        
        protected void AddSystem<T1,T2>(object sign, ISystem system)
        {
            systems.Add(system);
            msg.ListenMsg<T1, T2>(sign, (t1, t2) => system.Selector(entities, t1, t2));
        }

        public void AddEntity(IEntity entity)
        {
            entities.Add(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            entities.Remove(entity);
        }

        public void SendMsg(object sign)
        {
            msg.SendMsg(sign);
        }

        public void SendMsg<T>(object sign, T t)
        {
            msg.SendMsg(sign, t);
        }

        public void SendMsg<T1, T2>(object sign, T1 t1, T2 t2)
        {
            msg.SendMsg(sign, t1, t2);
        }
 
    }
}