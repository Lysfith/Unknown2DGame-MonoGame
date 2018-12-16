using _2016_Project_5.ECS;
using _2016_Project_5.ECS.Managers;
using _2016_Project_5.ECS.Models;
using _2016_Project_5.GameClient.Models.Enums;
using _2016_Project_5.GameClient.Models.Systems.Models;
using _2016_Project_5.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.GameClient.Models.Systems
{
    public class DrawEntitySystem : DrawSystem
    {
        private int _offsetX;
        private int _offsetY;

        private Stopwatch _stopwatch = new Stopwatch();

        public DrawEntitySystem(int priority, List<Type> componentTypes, World world)
            :base(priority, componentTypes, world)
        {
            _offsetX = (int)((MyGame.Instance.ScreenWidth - (MyGame.MapWidth * MyGame.Instance.SpriteWidth)) * 0.5f);
            _offsetY = (int)((MyGame.Instance.ScreenHeight - (MyGame.MapHeight * MyGame.Instance.SpriteHeight)) * 0.5f);

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public override void Draw(double elapsedTime, MySpriteBatch spriteBatch)
        {
            var entities = _world.EntityManager.GetEntities();

            var entitiesFounded = entities.Where(x => x.HasComponents(_componentTypes)).ToList();

            foreach (var e in entitiesFounded)
            {
                var spriteComponent = e.GetComponent<SpriteComponent>();
                var transformComponent = e.GetComponent<TransformComponent>();

                var region = MyGame.Instance.TextureManager.GetRegionByIndex(spriteComponent.SpriteIndex);

                spriteBatch.Draw(MyGame.Instance.TextureManager.GetTexture(),
                   new Rectangle(
                       (int)(transformComponent.X) * MyGame.Instance.SpriteWidth + _offsetX,
                       (int)(transformComponent.Y) * MyGame.Instance.SpriteHeight + _offsetY,
                       (int)(region.Width * spriteComponent.ScaleX),
                       (int)(region.Height * spriteComponent.ScaleY)
                       ),
                   new Rectangle(
                       region.X,
                       region.Y,
                       region.Width,
                       region.Height
                       ),
                   spriteComponent.Color,
                   transformComponent.Rotation,
                   new Vector2(
                       region.Width * spriteComponent.OriginX,
                       region.Height * spriteComponent.OriginY),
                   spriteComponent.Effect,
                   0);
            }
        }
    }
}
