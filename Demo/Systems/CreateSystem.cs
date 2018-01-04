using System.Collections.Generic;
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

        protected override void Execute(List<IEntity> all, IEntity entity, params object[] args)
        {
            var c = entity.GetComponent<CreateComponent>();
            var r = entity.GetComponent<RotateComponent>();
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            r.trans = go.transform;
            entity.RemoveComponent<CreateComponent>();
        }
    }
}