using System.Collections.Generic;

namespace J.ECS
{
    public abstract class ISystem
    {
        private Group group = null;

        protected abstract Group getGroup();
        
        public ISystem()
        {
            group = getGroup();
        }
        
        public void Selector(IEnumerable<IEntity> entities)
        {
            List<IEntity> all = new List<IEntity>();
            foreach (var entity in entities)
            {
                if (entity.HasComponents(@group.TargettedComponents))
                {
                    all.Add(entity);
                }
            }
            foreach (var entity in all)
            {
                Execute(all,entity);
            }
        }
        
        public void Selector<T>(IEnumerable<IEntity> entities,T t)
        {
            List<IEntity> all = new List<IEntity>();
            foreach (var entity in entities)
            {
                if (entity.HasComponents(@group.TargettedComponents))
                {
                    all.Add(entity);
                }
            }
            foreach (var entity in all)
            {
                Execute(all, entity, t);
            }
        }
        
        public void Selector<T1,T2>(IEnumerable<IEntity> entities,T1 t1,T2 t2)
        {
            List<IEntity> all = new List<IEntity>();
            foreach (var entity in entities)
            {
                if (entity.HasComponents(@group.TargettedComponents))
                {
                    all.Add(entity);
                }
            }
            foreach (var entity in all)
            {
                Execute(all,entity, t1, t2);
            }
        }

        protected abstract void Execute(List<IEntity> all, IEntity entity, params object[] args);

    }

}