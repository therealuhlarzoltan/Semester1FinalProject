using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester1FinalProject
{
    class Board
    {
        public char[,] board;

        public Board()
        {
            char[,] board = new char[4,4];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '@';
                }
            }
            this.board = board;
        }


        public Board(int size)
        {
            char[,] board = new char[size, size];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '@';
                }
            }
            this.board = board;
        }

        public void Draw()
        {
            Console.WriteLine("\nA játéktábla aktuális állapota:\n\n");
            int character_count = 0;
            for (int i = 0; i <= board.GetLength(0);i++)
            {
                for (int j = 0; j <= board.GetLength(1);j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Console.Write("y/x| ");
                        character_count += 5;
                    }
                    else if (i == 0 && j == board.GetLength(1))
                    {
                        Console.WriteLine($"{j - 1} |");
                        character_count += (j - 1).ToString().Length + 2;
                    }
                    else if (i == 0)
                    {
                        Console.Write($"{j - 1} | ");
                        character_count += (j - 1).ToString().Length + 3;
                    }
                    else if (j == 0)
                    {
                        Console.Write($" {i - 1} | ");
                    }
                    else if (j == board.GetLength(1))
                    {
                        Console.WriteLine($"{board[i-1, j-1]} |");
                    }
                    else
                    {
                        Console.Write($"{board[i-1, j-1]} | ");
                    }
                }
                for (int k = 0; k < character_count; k++)
                {
                    if (k == character_count -1)
                        Console.WriteLine($"-");
                    else
                        Console.Write($"-");
                }
            }
        }

        public int GetStones()
        {
            int stones = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '@')
                        stones++;
                }
            }
            return stones;
        }

        public bool ValidateMove(Point point1, Point point2)
        {
          
            if (point1.x >= board.GetLength(1) || point2.x >= board.GetLength(1))
                return false;

            if (point1.y >= board.GetLength(0) || point2.y >= board.GetLength(1))
                return false;

           

            if (point1.x != point2.x && point1.y != point2.y)
            {
                return false;
            }

            if (point1.x == point2.x)
            {
                if (point1.y < point2.y)
                {
                    for (int i = point1.y; i <= point2.y;i++)
                    {
                        if (board[i, point1.x] != '@')
                            return false;
                    }
                }
                if (point1.y > point2.y)
                {
                    for (int i = point1.y; i >= point2.y; i--)
                    {
                        if (board[i, point1.x] != '@')
                            return false;
                    }
                }
                if (point1.y == point2.y)
                {
                    if (board[point1.y, point1.x] != '@')
                            return false;
                }
            }
            if (point1.y == point2.y)
            {
                if (point1.x < point2.x)
                {
                    for (int i = point1.x; i <= point2.x; i++)
                    {
                        if (board[point1.y, i] != '@')
                            return false;
                    }
                }
                if (point1.x > point2.x)
                {
                    for (int i = point1.x; i >= point2.x; i--)
                    {
                        if (board[point1.y, i] != '@')
                            return false;
                    }
                }
                if (point1.x == point2.x)
                {
                    if (board[point1.y, point1.x] != '@')
                        return false;
                }

            }

            return true;
        }

        public void Update(Point point1, Point point2)
        {
            if (point1.x == point2.x)
            {
                if (point1.y < point2.y)
                {
                    for (int i = point1.y; i <= point2.y; i++)
                    {
                        board[i, point1.x] = ' ';
                    }
                }
                if (point1.y > point2.y)
                {
                    for (int i = point1.y; i >= point2.y; i--)
                    {
                        board[i, point1.x] = ' ';    
                    }
                }
                if (point1.y == point2.y)
                    board[point1.y, point1.x] = ' ';
            }
            if (point1.y == point2.y)
            {
                if (point1.x < point2.x)
                {
                    for (int i = point1.x; i <= point2.x; i++)
                    {
                        board[point1.y, i] = ' ';
                    }
                }
                if (point1.x > point2.x)
                {
                    for (int i = point1.x; i >= point2.x; i--)
                    {
                        board[point1.y, i] = ' ';
                    }
                }
                if (point1.x == point2.x)
                    board[point1.y, point1.x] = ' ';

            }


        }
    }
}
