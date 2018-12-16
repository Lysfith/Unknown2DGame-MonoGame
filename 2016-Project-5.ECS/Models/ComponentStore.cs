using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS.Models
{
    public class ComponentStore<T> : Store where T : Component
    {
        protected new Dictionary<long, T> _components;

        public ComponentStore()
        {
            _components = new Dictionary<long, T>();
        }

        /// <summary>
        /// Ajoute un composant dans le stockage
        /// </summary>
        /// <param name="e"></param>
        /// <param name="c"></param>
        public void Add(long e, T c)
        {
            _components.Add(e, c);
        }

        public new T Get(long e)
        {
            return _components[e];
        }
    }
}
