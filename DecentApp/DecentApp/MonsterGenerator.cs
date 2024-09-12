using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentApp
{
    internal class MonsterGenerator
    {
        public List<Monster> monsters;
        
        public MonsterGenerator()
        {
            monsters = new List<Monster>();

            Monster rat = new Monster(20, "Rat", 15);
            Monster goblin = new Monster(30, "Goblin", 35);
            //Monster dragon = new Monster(150, "Dragon", 100);

            monsters.Add(rat);
            monsters.Add(goblin);
            //monsters.Add(dragon);
           
        }
    }
}
