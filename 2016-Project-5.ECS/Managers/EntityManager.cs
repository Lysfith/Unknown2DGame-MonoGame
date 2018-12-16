using _2016_Project_5.ECS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS.Managers
{
    public class GameObjectManager
    {
        private List<GameObject> _entities;

        public GameObjectManager()
        {
            _entities = new List<GameObject>();
        }

        public GameObject CreateGameObject(World world)
        {
            var e = new GameObject(world.ComponentStoreManager);
            _entities.Add(e);

            return e;
        }

        public void RemoveEntity(int id)
        {
            _entities.RemoveAll(x => x.Id == id);
        }

        public void Update(double elapsedTime)
        {
            var entitiesToRemove = _entities.Where(x => x.ToRemove && x.TimeBeforeRemove > 0);

            foreach (var e in entitiesToRemove)
            {
                e.TimeBeforeRemove -= elapsedTime / 1000;
            }

            _entities.RemoveAll(x => x.ToRemove && x.TimeBeforeRemove <= 0);
        }

        public IList<GameObject> GetEntities()
        {
            return new List<GameObject>(_entities);
        }
    }
}
