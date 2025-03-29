using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDV3D___Semana_1___Ejercicio1
{
    public class Player
    {
        public int Life { get; private set; }
        public int Damage { get; private set; }

        public Player(int life, int damage)
        {
            if (life > 100 || damage > 100)
            {
                throw new ArgumentException("La vida y el daño no pueden superar los 100.");
            }

            Life = life;
            Damage = damage;
        }

        public void ReceiveDamage(int damage)
        {
            Life -= damage;
            if (Life < 0)
            {
                Life = 0;
            }
        }

        public int GetDamage()
        {
            return Damage;
        }
    }
}
