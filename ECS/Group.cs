using System;

namespace J.ECS
{
    public class Group
    {
        public Type[] TargettedComponents;

        public Group(params Type[] types)
        {
            TargettedComponents = types;
        }
    }
}