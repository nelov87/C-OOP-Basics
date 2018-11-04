using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class StartUp
    {
        static void Main()
        {
            int[] dimestion = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimestion[0];
            int cols = dimestion[1];

            
            Galaxy galaxy = new Galaxy(rows, cols);
            

            

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] playerCoordinats = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilCoordinates = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Player evil = new Player(evilCoordinates[0], evilCoordinates[1]);
                Player player = new Player(playerCoordinats[0], playerCoordinats[1]);
                

                while (evil.Row >= 0 && evil.Col >= 0)
                {
                    if (galaxy.IsInGalaxy(evil.Row, evil.Col))
                    {
                        galaxy.Matrix[evil.Row, evil.Col] = 0;
                    }
                    evil.Row--;
                    evil.Col--;
                }

               

                while (player.Row >= 0 && player.Col < galaxy.Matrix.GetLength(1))
                {
                    if (galaxy.IsInGalaxy(player.Row, player.Col))
                    {
                        sum += galaxy.Matrix[player.Row, player.Col];
                    }

                    player.Col++;
                    player.Row--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}
