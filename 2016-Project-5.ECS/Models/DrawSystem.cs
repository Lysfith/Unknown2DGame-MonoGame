using _2016_Project_5.ECS.Managers;
using _2016_Project_5.Graphic;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS.Models
{
    public class DrawSystem : GameSystem
    {
        public DrawSystem(int priority, List<Type> componentTypes, World world)
             : base(priority, componentTypes, world)
        {

        }

        public virtual void Draw(double elapsedTime, MySpriteBatch spriteBatch)
        {

        }
    }
}
