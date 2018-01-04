using System.Collections.Generic;
using J.Demo.Components;
using J.ECS;
using UnityEngine;

namespace J.Demo.Systems
{
    public class RotateSystem:ISystem
    {
        protected override Group getGroup()
        {
            return new Group(typeof(RotateComponent));
        }

        protected override void Execute(List<IEntity> all, IEntity entity, params object[] args)
        {
            var r = entity.GetComponent<RotateComponent>();
            r.fRotate += 1;
            if (r.trans!=null)
            {
                r.trans.rotation = Quaternion.Euler(r.fRotate, 0, 0);
            }
        }
    }
}