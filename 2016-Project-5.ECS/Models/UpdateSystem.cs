using _2016_Project_5.ECS.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS.Models
{
    public class UpdateSystem : GameSystem
    {
        public UpdateSystem(int priority, List<Type> componentTypes, World world)
            :base(priority, componentTypes, world)
        {

        }

        public virtual void Update(double elapsedTime)
        {

        }
    }
}
