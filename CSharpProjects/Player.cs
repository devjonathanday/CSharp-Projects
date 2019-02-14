using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjects
{
    public class Player
    {
        private string name;

        public int fragCount;
        public int deathCount;
        public int totalDamage;

        public string Name
        {
            get { return name; }
            set { if(name.Length > 0) name = Name; }
        }
        public int Score { get { return Math.Max(0, fragCount - deathCount); } }
    }
}
