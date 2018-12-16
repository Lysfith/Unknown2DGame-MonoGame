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
    public class ScriptComponent : Component
    {
        public string Script { get; set; }

        public ScriptComponent()
        {
            
        }
    }
}
