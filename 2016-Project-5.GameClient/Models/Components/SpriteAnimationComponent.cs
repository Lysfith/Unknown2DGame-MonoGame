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
    public class SpriteAnimationComponent : Component
    {
        public int SpriteIndexStart { get; set; }
        public int SpriteIndexEnd { get; set; }
        public double IntervalBetweenFrame { get; set; }
        public double LastFrameChanged { get; set; }

        public SpriteAnimationComponent()
        {
            Type = (int)(EnumComponent.SpriteAnimation);
        }
    }
}
