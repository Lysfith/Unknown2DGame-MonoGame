using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS.Models
{
    public class Store
    {
        protected Dictionary<long, Component> _components;

        public Store()
        {
            _components = new Dictionary<long, Component>();
        }

        public void Add(long e, Component c)
        {
            _components.Add(e, c);
        }

        public void Remove(long e)
        {
            _components.Remove(e);
        }

        public Component Get(long e)
        {
            return _components[e];
        }

        public bool Has(long e)
        {
            return _components.ContainsKey(e);
        }

        public int Count()
        {
            return _components.Count;
        }
    }
}
