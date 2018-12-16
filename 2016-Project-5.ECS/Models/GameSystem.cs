using _2016_Project_5.ECS.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS.Models
{
    public class GameSystem
    {
        protected int _priority;
        protected World _world;

        protected List<GameObject> _entities;
        protected List<Type> _componentTypes;

        public bool ToRemove { get; set; }

        public GameSystem(int priority, List<Type> componentTypes, World world)
        {
            _priority = priority;
            _world = world;
            _componentTypes = componentTypes;

            _entities = new List<GameObject>();
        }

        public void AddEntity(GameObject e)
        {
            _entities.Add(e);
        }

        public void RemoveEntity(GameObject e)
        {
            _entities.Remove(e);
        }
    }
}
