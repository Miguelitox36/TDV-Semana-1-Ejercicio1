using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDV3D___Semana_1___Ejercicio1
{
    public class Enemy
    {
        public int Life { get; private set; }
        public int Damage { get; private set; }

        public Enemy(int life, int damage)
        {
            Life = life;
            Damage = damage;
        }

        public void ReceiveDamage(int daño)
        {
            Life -= daño;
            if (Life < 0)
            {
                Life = 0;
            }
        }

        public int GetDamage()
        {
            return Damage;
        }

        public bool IsAlive()
        {
            return Life > 0;
        }
    }
}
