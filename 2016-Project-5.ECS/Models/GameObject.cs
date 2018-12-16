using _2016_Project_5.ECS.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS.Models
{
    public class GameObject
    {
        private static long _id = 0;

        public long Id { get; private set; }
        public bool ToRemove { get; set; }
        public double TimeBeforeRemove { get; set; }

        public ComponentStoreManager _manager;

        public List<Type> ComponentTypes { get; private set; }

        public GameObject(ComponentStoreManager manager)
        {
            Id = _id;
            _id++;

            ComponentTypes = new List<Type>();

            _manager = manager;
        }

        public void AddComponent<T>(T component) where T : Component
        {
            _manager.Add<T>(this, component);
        }

        public T GetComponent<T>() where T : Component
        {
            var type = typeof(T);
            var store = _manager.GetStore<T>();

            return store.Get(this.Id);
        }

        public bool HasComponents(List<Type> types)
        {
            return ComponentTypes.Intersect(types).Count() == types.Count;
        }

    }
}
