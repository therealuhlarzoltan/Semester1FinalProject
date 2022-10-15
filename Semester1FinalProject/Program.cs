using System;


namespace Semester1FinalProject
{
    class Program
    {
        static Player CreateNewPlayer()
        {
            string username = "";
            do
            {
                username = Console.ReadLine();
            } while (username.Length < 1 || username.Length > 30);
            Player player = new Player(username);
            return player;
        }

        static Board CreateBoard(string input)
        {
            int counter = 0;
            while (counter < input.Length && char.IsDigit(input[counter]))
            {
                counter++;
            }
            if (counter == input.Length && input.Length != 0)
            {
                Board board = new Board(int.Parse(input));
                return board;
            }
            else
            {
                Board board = new Board();
                return board;
            }
        }

        static void NextStep(ref Player player1, ref Player player2, ref Board board)
        {
            if (player1.move_count == player2.move_count)
                player1.Move(ref board);

            else if (player1.move_count > player2.move_count)
                player2.Move(ref board);

            else
                player1.Move(ref board);
            board.Draw();

        }



        static void Main(string[] args)
        {
            int max_width = Console.LargestWindowWidth;
            int max_height = Console.LargestWindowHeight;
            Console.WindowWidth = max_width;
            Console.WindowHeight = max_height;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Üdvözöllek a játékban!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Kérlek add meg az első játékos nevét (legalább 1 karakter és maximum 30 karakter): ");
            Player player1 = CreateNewPlayer();
            Console.WriteLine();
            Console.Write("Kérlek add meg a második játékos nevét(legalább 1 karakter és maximum 30 karakter): ");
            Player player2 = CreateNewPlayer();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("A játék menete:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nA játékosok felváltva vesznek el a táblán elhelyezett kövekből úgy, hogy egyszerre csak egy oszlopból vagy egy sorból vehetnek el.\nAkármennyit, az egész sort vagy oszlopot is, de egy követ is lehet. (Legalább 1 kavicsot viszont mindenképp el kell venni.) \n\nAmi különösen fontos,hogy csakis egymás mellettieket vehetnek el. Tehát, ha az egyik fél elvette valamelyik sorból a két középsőt,\nakkor a rákövetkező nem veheti el a maradék kettőt, csak az egyiket.\n\nA játéknak akkor van vége, ha a tábláról elfogytak a kövek. A játékot az nyeri, aki az utolsó kavicsot veszi el a tábláról.\n\nA soron következő játékosnak két koordinátát kell megadnia: az elvenni kívánt „kavicsszakasz” kezdőés végpontjait. Ha csak egy kavicsot venne el, \nakkor ugyanazt a koordinátát adja meg kétszer.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nA folytatáshoz nyomj bármilyen billentyűt!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n\nLehetőséged van testreszabni a játéktábla méretét!\nEhhez kérlek írj ide egy 4-nél nagyobb számot (amennyiben kisebbet írsz egy 4x4-es táblán fogsz játszani): ");
            Board board = CreateBoard(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMinden beállítva! A folytatáshoz nyomj bármilyen billentyűt!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
            board.Draw();
            int remaining_sotnes = board.GetStones();
            while (remaining_sotnes > 0)
            {
                NextStep(ref player1, ref player2, ref board);
                remaining_sotnes = board.GetStones();
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (player1.move_count > player2.move_count)
                Console.WriteLine($"\n\n{player1.name} nyerte a játékot!");
            else
                Console.WriteLine($"\n\n{player2.name} nyerte a játékot!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
