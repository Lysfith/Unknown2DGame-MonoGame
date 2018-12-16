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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.GameClient.Models.Systems
{
    public class DrawFloorSystem : DrawSystem
    {
        public DrawFloorSystem(int priority, List<Type> componentTypes, World world)
            :base(priority, componentTypes, world)
        {

        }

        public override void Draw(double elapsedTime, MySpriteBatch spriteBatch)
        {
            var offsetX = (int)((MyGame.Instance.ScreenWidth - (MyGame.MapWidth * MyGame.Instance.SpriteWidth)) * 0.5f);
            var offsetY = (int)((MyGame.Instance.ScreenHeight - (MyGame.MapHeight * MyGame.Instance.SpriteHeight)) * 0.5f);

            for (int i=0; i < MyGame.MapWidth * MyGame.MapHeight; i++)
            {
                var region = MyGame.Instance.TextureManager.GetRegionByIndex(33);
                spriteBatch.Draw(MyGame.Instance.TextureManager.GetTexture(),
                   new Rectangle(
                       (int)(i % MyGame.MapWidth) * MyGame.Instance.SpriteWidth + offsetX,
                       (int)(i / MyGame.MapHeight) * MyGame.Instance.SpriteHeight + offsetY,
                       (int)(region.Width),
                       (int)(region.Height)
                       ),
                   new Rectangle(
                       region.X,
                       region.Y,
                       region.Width,
                       region.Height
                       ),
                   Color.White,
                   0,
                   new Vector2(
                       MyGame.Instance.SpriteWidth * 0.5f,
                       MyGame.Instance.SpriteHeight *0.5f),
                   SpriteEffects.None,
                   0);
            }
        }
    }
}
