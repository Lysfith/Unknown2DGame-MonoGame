using _2016_Project_5.ECS;
using _2016_Project_5.ECS.Models;
using _2016_Project_5.GameClient.Models.Systems.Models;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.GameClient.Models.Systems
{
    public class UpdateInputSystem : UpdateSystem
    {
        public UpdateInputSystem(int priority, List<Type> componentTypes, World world)
            :base(priority, componentTypes, world)
        {

        }

        public override void Update(double elapsedTime)
        {
            var entities = _world.EntityManager.GetEntities();

            var player = entities.Where(x => x.HasComponents(_componentTypes) && x.GetComponent<TypeEntityComponent>().TypeEntity == Enums.EnumTypeEntity.Player).FirstOrDefault();

            if(player != null)
            { 
                var transformComponent = player.GetComponent<TransformComponent>();
                var inputComponent = player.GetComponent<InputComponent>();

                var keyboardState = Keyboard.GetState();

                inputComponent.Left = keyboardState.IsKeyDown(Keys.Q) || keyboardState.IsKeyDown(Keys.Left);
                inputComponent.Right = keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right);
                inputComponent.Up = keyboardState.IsKeyDown(Keys.Z) || keyboardState.IsKeyDown(Keys.Up);
                inputComponent.Down = keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down);
                inputComponent.SetBomb = keyboardState.IsKeyDown(Keys.Space);

                if (inputComponent.Left)
                {
                    transformComponent.X -= 1;
                }
                else if (inputComponent.Right)
                {
                    transformComponent.X += 1;
                }
                else if (inputComponent.Up)
                {
                    transformComponent.Y -= 1;
                }
                else if (inputComponent.Down)
                {
                    transformComponent.Y += 1;
                }

                //if (inputComponent.SetBomb)
                //{
                //    shootComponent.ShootAsked = true;
                //}
            }
        }
    }
}
