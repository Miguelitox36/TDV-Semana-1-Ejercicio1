using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDV3D___Semana_1___Ejercicio1
{
    public class GameManager
    {
        private Player player;
        private List<Enemy> enemies;

        public GameManager(Player player, List<Enemy> enemies)
        {
            this.player = player;
            this.enemies = enemies;
        }

        public void StartGame()
        {
            while (player.Life > 0 && enemies.Any(enemies => enemies.IsAlive()))
            {
                Console.WriteLine("Turno del jugador:");
                AttackEnemy();

                
                if (!enemies.Any(enemigo => enemigo.IsAlive()))
                {
                    Console.WriteLine("¡Victoria! Has derrotado a todos los enemigos.");
                    return;
                }
                                
                Console.WriteLine("Turno de los enemigos:");
                EnemiesAttack();
            }

            if (player.Life <= 0)
            {
                Console.WriteLine("¡Derrota! Te has quedado sin vida.");
            }
        }

        private void AttackEnemy()
        {           
            Enemy enemyObject = enemies.FirstOrDefault(enemy => enemy.IsAlive());
            if (enemyObject != null)
            {
                enemyObject.ReceiveDamage(player.GetDamage());
                Console.WriteLine($"El jugador ataca al enemigo y le inflige {player.GetDamage()} de daño.");
            }
            else
            {
                Console.WriteLine("No hay enemigos vivos para atacar.");
            }
        }

        private void EnemiesAttack()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.IsAlive())
                {
                    player.ReceiveDamage(enemy.GetDamage());
                    Console.WriteLine($"El enemigo ataca al jugador y le inflige {enemy.GetDamage()} de daño.");
                }
            }
        }
    }
}
