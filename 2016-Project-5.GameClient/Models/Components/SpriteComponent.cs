using _2016_Project_5.ECS.Models;
using _2016_Project_5.GameClient.Models.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.GameClient.Models.Systems.Models
{
    public class SpriteComponent : Component
    {
        public float OriginX { get; set; }
        public float OriginY { get; set; }
        public bool Visible { get; set; }
        public int SpriteIndex { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public SpriteEffects Effect { get; set; }
        public Color Color { get; set; }

        public SpriteComponent()
        {
            Type = (int)(EnumComponent.Sprite);
        }
    }
}
