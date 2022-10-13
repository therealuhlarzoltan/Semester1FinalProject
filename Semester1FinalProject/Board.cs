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
                        Console.Write("x/y| ");
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

        public bool ValidateMove(int[,] coordinates)
        {
            for (int i = 0; i < 2; i++)
            {
                if (coordinates[i, 0] >= board.GetLength(0) || coordinates[i, 1] >= board.GetLength(1))
                    return false;
            }

            //for (int i = 0; i < coordinates.GetLength(0);i++)
            //{
            //    for (int j = 0; j < coordinates.GetLength(1);j++)
            //    {
            //        Console.WriteLine(coordinates[i, j]);
            //    }
            //}

            if (coordinates[0, 1] != coordinates[1, 1] && coordinates[0, 0] != coordinates[1, 0])
            {
                return false;
            }

            if (coordinates[0,1] == coordinates[1,1])
            {
                if (coordinates[0,0] < coordinates[1,0])
                {
                    for (int i = coordinates[0,0]; i <= coordinates[1,0];i++)
                    {
                        if (board[i, coordinates[0,1]] != '@')
                            return false;
                    }
                }
                if (coordinates[0, 0] > coordinates[1, 0])
                {
                    for (int i = coordinates[1,0]; i >= coordinates[0, 0]; i--)
                    {
                        if (board[i, coordinates[0, 1]] != '@')
                            return false;
                    }
                }
                if (coordinates[0,0] == coordinates[1,0])
                {
                    if (board[coordinates[0, 0], coordinates[0, 1]] != '@')
                            return false;
                }
            }
            if (coordinates[0,0] == coordinates[1,0])
            {
                if (coordinates[0, 1] < coordinates[1, 1])
                {
                    for (int i = coordinates[0, 1]; i <= coordinates[1, 1]; i++)
                    {
                        if (board[coordinates[0,0], i] != '@')
                            return false;
                    }
                }
                if (coordinates[0, 1] > coordinates[1, 1])
                {
                    for (int i = coordinates[0, 1]; i >= coordinates[1, 1]; i--)
                    {
                        if (board[coordinates[0,0], i] != '@')
                            return false;
                    }
                }
                if (coordinates[0, 1] == coordinates[0, 1])
                {
                    if (board[coordinates[0, 0], coordinates[0, 1]] != '@')
                        return false;
                }

            }

            return true;
        }

        public void Update(int[,] coordinates)
        {
            if (coordinates[0, 1] == coordinates[1, 1])
            {
                if (coordinates[0, 0] < coordinates[1, 0])
                {
                    for (int i = coordinates[0, 0]; i <= coordinates[1, 0]; i++)
                    {
                        board[i, coordinates[0, 1]] = ' ';
                    }
                }
                if (coordinates[0, 0] > coordinates[1, 0])
                {
                    for (int i = coordinates[1, 0]; i >= coordinates[0, 0]; i--)
                    {
                        board[i, coordinates[0, 1]] = ' ';
                    }
                }
                if (coordinates[0, 0] == coordinates[1, 0])
                    board[coordinates[0,0], coordinates[0,1]] = ' ';
            }
            if (coordinates[0, 0] == coordinates[1, 0])
            {
                if (coordinates[0, 1] < coordinates[1, 1])
                {
                    for (int i = coordinates[0, 1]; i <= coordinates[1, 1]; i++)
                    {
                        board[coordinates[0, 0], i] = ' ';
                      
                    }
                }
                if (coordinates[0, 1] > coordinates[1, 1])
                {
                    for (int i = coordinates[0, 1]; i >= coordinates[1, 1]; i--)
                    {
                        board[coordinates[0, 0], i] = ' ';
                    }
                }
                if (coordinates[0,1] == coordinates[1,1])
                    board[coordinates[0,0], coordinates[0, 1]] = ' ';
            }
        }
    }
}
