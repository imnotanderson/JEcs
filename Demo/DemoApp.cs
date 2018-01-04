using J.Demo.Components;
using J.Demo.Entities;
using J.Demo.Systems;
using J.ECS;

namespace J.Demo
{
    public enum Event
    {
        Upt,
    }

    public class DemoApp : App
    {
        protected override void OnInit()
        {
            AddSystem(Event.Upt, new CreateSystem());
            AddSystem(Event.Upt, new RotateSystem());
        }

        protected override void OnStart()
        {
            AddEntity(new CubeEntity().AddComponent(new CreateComponent()).AddComponent(new RotateComponent()));
        }
    }
}