using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDV3D___Semana_1___Ejercicio1
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int Damage { get; private set; }
        Random random = new Random();

        public Player(string name, int health, int damage)
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

        public void Heal()
        {
            int healAmount = random.Next(10, 21);
            Health += healAmount;
            if (Health > MaxHealth)
                Health = MaxHealth;

            Console.WriteLine($"{Name} se curó {healAmount} puntos de vida.");
        }

        public bool TryToEvade()
        {
            bool success = random.NextDouble() < 0.5;
            if (success)
                Console.WriteLine($"{Name} esquivó exitosamente el próximo ataque.");
            else
                Console.WriteLine($"{Name} falló al intentar esquivar...");
            return success;
        }
    }
}
