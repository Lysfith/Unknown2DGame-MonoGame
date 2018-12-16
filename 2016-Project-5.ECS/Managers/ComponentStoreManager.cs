using _2016_Project_5.ECS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS.Managers
{
    public class ComponentStoreManager
    {
        private Dictionary<Type, Store> _stores;

        public ComponentStoreManager()
        {
            _stores = new Dictionary<Type, Store>();
        }

        public void Add<T>(GameObject e, T c) where T : Component
        {
            var type = typeof(T);

            ComponentStore<T> store = null;
            if (!_stores.ContainsKey(type))
            {
                store = new ComponentStore<T>();
                _stores.Add(type, store);
            }
            else
            {
                store = (ComponentStore<T>)_stores[type];
            }

            //S'il n'a pas deja le composant on le rajoute
            if(!store.Has(e.Id))
            {
                store.Add(e.Id, c);

                e.ComponentTypes.Add(type);
            }
        }

        public void Remove(GameObject e)
        {
            var components = e.ComponentTypes;
            var stores = _stores.Where(x => components.Contains(x.Key)).ToList();
            
            foreach(var store in stores)
            {
                store.Value.Remove(e.Id);
            }
        }


        public ComponentStore<T> GetStore<T>() where T : Component
        {
            return (ComponentStore<T>)_stores[typeof(T)];
        }
    }
}
