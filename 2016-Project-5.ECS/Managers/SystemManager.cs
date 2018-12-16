using _2016_Project_5.ECS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS.Managers
{
    public class SystemManager
    {
        private List<UpdateSystem> _updateSystems;
        private List<DrawSystem> _drawSystems;

        public SystemManager()
        {
            _updateSystems = new List<UpdateSystem>();
            _drawSystems = new List<DrawSystem>();
        }

        public void AddSystem(UpdateSystem system)
        {
            _updateSystems.Add(system);
        }

        public void AddSystem(DrawSystem system)
        {
            _drawSystems.Add(system);
        }

        public void RemoveSystem(UpdateSystem system)
        {
            _updateSystems.Remove(system);
        }

        public void RemoveSystem(DrawSystem system)
        {
            _drawSystems.Remove(system);
        }

        public void ClearAll()
        {
            _updateSystems.Clear();
            _drawSystems.Clear();
        }

        public void Update()
        {
            _updateSystems.RemoveAll(x => x.ToRemove);
        }

        public IList<UpdateSystem> GetUpdateSystems()
        {
            return _updateSystems;
        }

        public IList<DrawSystem> GetDrawSystems()
        {
            return _drawSystems;
        }
    }
}
