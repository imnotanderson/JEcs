using J.Demo.Components;
using J.ECS;
using UnityEngine;

namespace J.Demo.Systems
{
    public class CreateSystem:ISystem
    {
        protected override Group getGroup()
        {
            return new Group(typeof(CreateComponent), typeof(RotateComponent));
        }

        protected override void Execute(IEntity entity, params object[] args)
        {
            var c = entity.GetComponent<CreateComponent>();
            var r = entity.GetComponent<RotateComponent>();
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            r.trans = go.transform;
            entity.RemoveComponent<CreateComponent>();
        }
    }
}