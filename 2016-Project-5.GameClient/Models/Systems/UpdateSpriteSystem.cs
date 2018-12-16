using _2016_Project_5.ECS;
using _2016_Project_5.ECS.Managers;
using _2016_Project_5.ECS.Models;
using _2016_Project_5.GameClient.Models.Enums;
using _2016_Project_5.GameClient.Models.Systems.Models;
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
    public class UpdateSpriteSystem : UpdateSystem
    {
        public UpdateSpriteSystem(int priority, List<Type> componentTypes, World world)
            :base(priority, componentTypes, world)
        {

        }

        public override void Update(double elapsedTime)
        {
            var entities = _world.EntityManager.GetEntities();

            var entitiesFounded = entities.Where(x => x.HasComponents(_componentTypes)).ToList();

            foreach (var e in entitiesFounded)
            {
                var spriteComponent = e.GetComponent<SpriteComponent>();
                var spriteAnimationComponent = e.GetComponent<SpriteAnimationComponent>();

                spriteAnimationComponent.LastFrameChanged += elapsedTime;

                if (spriteAnimationComponent.LastFrameChanged > spriteAnimationComponent.IntervalBetweenFrame * 1000)
                {
                    spriteComponent.SpriteIndex++;

                    if (spriteComponent.SpriteIndex > spriteAnimationComponent.SpriteIndexEnd)
                    {
                        spriteComponent.SpriteIndex = spriteAnimationComponent.SpriteIndexStart;
                    }

                    spriteAnimationComponent.LastFrameChanged = 0;
                }
            }
        }
    }
}
