using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDV3D___Semana_1___Ejercicio1
{
    public class Enemy
    {
        public string Name;
        public int Health;
        public int MaxHealth;
        public int Damage;

        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Damage = damage;
        }

        public void ReceiveDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }
    }
}
