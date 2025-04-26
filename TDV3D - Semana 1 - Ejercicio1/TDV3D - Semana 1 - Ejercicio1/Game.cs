using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TDV3D___Semana_1___Ejercicio1
{
    internal class Game
    {
        Player player;
        Queue<Enemy> enemyQueue;
        Random random = new Random();
        bool willEvade = false;

        public void Start()
        {
            Console.WriteLine("¡Bienvenido al juego RPG!");
            CreatePlayer();
            CreateEnemies();
            GameLoop();
        }

        private void CreatePlayer()
        {
            Console.WriteLine("Crea tu personaje:");

            Console.Write("Ingresa el nombre de tu personaje: ");
            string name = Console.ReadLine();

            int health = RequestNumber("Ingresa la vida del jugador (máximo 100): ", 1, 100);
            int damage = RequestNumber("Ingresa el daño del jugador (máximo 20): ", 1, 20);

            player = new Player(name, health, damage);
        }

        private void CreateEnemies()
        {
            enemyQueue = new Queue<Enemy>();
            enemyQueue.Enqueue(new Enemy("Goblin", 50, 10));
            enemyQueue.Enqueue(new Enemy("Orco", 70, 15));
            enemyQueue.Enqueue(new Enemy("Dragón", 100, 20));
        }

        private void GameLoop()
        {
            while (player.Health > 0 && enemyQueue.Count > 0)
            {
                var currentEnemy = enemyQueue.Peek();

                ShowStatus(currentEnemy);
                PlayerTurn(currentEnemy);

                if (currentEnemy.Health <= 0)
                {
                    Console.WriteLine($"¡Has derrotado al {currentEnemy.Name}!");
                    enemyQueue.Dequeue();
                    continue;
                }

                EnemyTurn(currentEnemy);
            }

            if (player.Health > 0)
                Console.WriteLine($"¡Victoria! {player.Name} ha derrotado a todos los enemigos.");
            else
                Console.WriteLine($"¡Derrota! {player.Name} se ha quedado sin vida.");
        }

        private void PlayerTurn(Enemy enemy)
        {
            Console.WriteLine("\nTurno del jugador:");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Curarse");
            Console.WriteLine("3. Esquivar");
            Console.Write("Elige una acción: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    enemy.ReceiveDamage(player.Damage);
                    Console.WriteLine($"{player.Name} atacó al {enemy.Name} e infligió {player.Damage} de daño.");
                    break;
                case "2":
                    player.Heal();
                    break;
                case "3":
                    willEvade = player.TryToEvade();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Pierdes el turno.");
                    break;
            }
        }

        private void EnemyTurn(Enemy enemy)
        {
            if (willEvade)
            {
                Console.WriteLine("\n¡Esquivaste el ataque del enemigo!");
                willEvade = false;
            }
            else
            {
                Console.WriteLine("\nTurno del enemigo:");
                player.ReceiveDamage(enemy.Damage);
                Console.WriteLine($"El {enemy.Name} atacó a {player.Name} e infligió {enemy.Damage} de daño.");
            }
        }

        private void ShowStatus(Enemy enemy)
        {
            Console.WriteLine("\n====== Estado Actual ======");
            Console.WriteLine($"{player.Name} - Vida: {player.Health} {HealthBar(player.Health, player.MaxHealth)}");
            Console.WriteLine($"{enemy.Name} - Vida: {enemy.Health} {HealthBar(enemy.Health, enemy.MaxHealth)}");
            Console.WriteLine("============================");
        }

        private string HealthBar(int current, int max)
        {
            int totalBlocks = 10;
            int filledBlocks = (int)Math.Round((double)current / max * totalBlocks);
            return "[" + new string('█', filledBlocks) + new string('-', totalBlocks - filledBlocks) + "]";
        }

        private int RequestNumber(string message, int min, int max)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max);

            return value;
        }
    }
}
