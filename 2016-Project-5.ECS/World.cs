using _2016_Project_5.ECS.Managers;
using _2016_Project_5.ECS.Models;
using _2016_Project_5.Graphic;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS
{
    public class World
    {
        public SystemManager SystemManager { get; private set; }
        public GameObjectManager EntityManager { get; private set; }
        public ComponentStoreManager ComponentStoreManager { get; private set; }

        private bool _isRunning;

        public World()
        {
            SystemManager = new SystemManager();
            EntityManager = new GameObjectManager();
            ComponentStoreManager = new ComponentStoreManager();

            _isRunning = true;
        }

        public GameObject CreateGameObject()
        {
            return EntityManager.CreateGameObject(this);
        }

        public void Update(double elapsedTime)
        {
            if (_isRunning)
            {
                var systems = SystemManager.GetUpdateSystems();
                foreach (var s in systems)
                {
                    s.Update(elapsedTime);
                }

                EntityManager.Update(elapsedTime);
                SystemManager.Update();
            }
        }

        public void Draw(double elapsedTime, MySpriteBatch spriteBatch)
        {
            if (_isRunning)
            {
                var systems = SystemManager.GetDrawSystems();
                foreach (var s in systems)
                {
                    s.Draw(elapsedTime, spriteBatch);
                }

            }
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}
