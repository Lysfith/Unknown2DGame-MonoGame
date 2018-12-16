using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.ECS.Models
{
    public class Component
    {
        private static int _id = 0;

        public int Id { get; private set; }

        public int Type { get; protected set; }

        public Component()
        {
            Id = _id;
            _id++;
        }

        public int GetTypeComponent()
        {
            return Type;
        }
    }
}
