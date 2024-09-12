using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentApp
{
    internal class WeaponList
    { 
        public List<Weapon> weapons;

        public Weapon sword = new Weapon("Sword of Hercules", 4, 10);
        public Weapon dagger = new Weapon("Shiny dagger", 2, 7);
        public Weapon axe = new Weapon("Axe of Thunder", 3, 8);

        public WeaponList()
        {
            weapons = new List<Weapon>() { sword, dagger, axe };
        }
    }
}
