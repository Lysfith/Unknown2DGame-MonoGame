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
    public class InputComponent : Component
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool SetBomb { get; set; }

        public InputComponent()
        {

        }
    }
}
