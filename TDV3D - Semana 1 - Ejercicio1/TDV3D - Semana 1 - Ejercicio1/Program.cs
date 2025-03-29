using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDV3D___Semana_1___Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {          
            Player player = new Player(100, 20);
                      
            List<Enemy> enemies = new List<Enemy>
        {
            new Enemy(50, 10),
            new Enemy(60, 15),
            new Enemy(70, 20)
        };

            
            GameManager gameManager = new GameManager(player, enemies);
                     
            gameManager.StartGame();
        }
    }
}
