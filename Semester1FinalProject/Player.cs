using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester1FinalProject
{
    class Player
    {
        public string name;
        public int move_count;

        public Player(string name)
        {
            this.name = name;
            this.move_count = 0;
        }

        public void Move(ref Board board)
        {
            string[] input_coordinates = new string[4];
            int[,] coordinates = new int[2, 2];
            Console.WriteLine($"\n\n{name} következik... Add meg a kellő koordinátákat!");
            Console.Write("1. pont - X: ");
            input_coordinates[0] = Console.ReadLine();
            Console.Write("\n1. pont - Y: ");
            input_coordinates[1] = Console.ReadLine();
            Console.Write("\n2. pont - X: ");
            input_coordinates[2] = Console.ReadLine();
            Console.Write("\n2. pont - Y: ");
            input_coordinates[3] = Console.ReadLine();

            int i = 0;
            bool is_invalid = false;
            while (i <= input_coordinates.Length - 1 && !is_invalid)
            {
                int counter = 0;
                while (counter < input_coordinates[i].Length && char.IsDigit(input_coordinates[i][counter]))
                {
                    counter++;
                }
                if (counter == input_coordinates[i].Length && input_coordinates[i].Length != 0)
                {
                    i++;
                }
                else
                    is_invalid = true;
                    
             
            }
            if (!is_invalid)
            {
                Point point1 = new Point(int.Parse(input_coordinates[0]), int.Parse(input_coordinates[1]));
                Point point2 = new Point(int.Parse(input_coordinates[2]), int.Parse(input_coordinates[3]));
                if (board.ValidateMove(point1, point2))
                {
                    board.Update(point1, point2);
                    move_count++;
                }
                else
                {
                    Console.WriteLine("\n\nÉrvénytelen lépés!");
                    Move(ref board);
                }
            }
            else
            {
                Console.WriteLine("\n\nÉrvénytelen koordináta érték(ek)!");
                Move(ref board);
            }
        }
    }
}
