using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentApp
{
    internal class Monster
    {
        public Weapon Weapon { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public bool Dead { get; set; }
        public int ExperienceReward { get; set; }
        public Monster(int health, string name, int experience)
        {
            Health = health;
            Name = name;
            ExperienceReward = experience;
            Dead = false;
        }

        public void Attack(Character character, Monster monster)
        {
            if (!IsDead())
            {
                Random random = new Random();
                int minValue = Weapon.MinDamage; // Ska man referera till monster minDamage eller monster vapen?
                int maxValue = Weapon.MaxDamage; // Ska man referera till monster minDamage eller monster vapen?
                int hitDamageMonster = random.Next(minValue, maxValue + 1); // +1 to include maxValue
                character.Health = character.Health - hitDamageMonster;
                Console.WriteLine($"{character.Name} lost {hitDamageMonster} and has {character.Health} HP remaining");
                Thread.Sleep(500);
            }
        }

        public bool IsDead()
        {
            if(Health<= 0)
            {
                Dead = true;
                return Dead;
            }
            return false;
        }
    }
}
