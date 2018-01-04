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
            foreach (var entity in entities)
            {
                if (entity.HasComponents(@group.TargettedComponents))
                {
                    Execute(entity);
                }
            }
        }
        
        public void Selector<T>(IEnumerable<IEntity> entities,T t)
        {
            foreach (var entity in entities)
            {
                if (entity.HasComponents(@group.TargettedComponents))
                {
                    Execute(entity, t);
                }
            }
        }
        
        public void Selector<T1,T2>(IEnumerable<IEntity> entities,T1 t1,T2 t2)
        {
            foreach (var entity in entities)
            {
                if (entity.HasComponents(@group.TargettedComponents))
                {
                    Execute(entity, t1, t2);
                }
            }
        }

        protected abstract void Execute(IEntity entity,params object[] args);
        
    }

}