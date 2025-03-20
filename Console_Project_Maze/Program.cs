using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250319_실습2
{
    class Program
    {
        struct Position
        {
            public int x;
            public int y;
        }

        static void Main(string[] args)
        {
            bool gameOver = false;

            Position playerPos;
            Position goalPos;

            bool[,] map;

            Start(out playerPos, out goalPos, out map);

            while (gameOver == false)
            {
                Render(playerPos, goalPos, map);
                ConsoleKey key = Input();
                Update(key, ref playerPos, goalPos, map, ref gameOver);
            }
            End();
        }


        static void Start(out Position playerPos, out Position goalPos, out bool[,] map)
        {
            Console.CursorVisible = false;

            playerPos.x = 1;
            playerPos.y = 5;

            goalPos.x = 8;
            goalPos.y = 1;

            map = new bool[7, 10]
            {

            { false, false, false, false, false, false, false, false, false, false },
            { false, true,  true,  true,  true,  true,  false, true,  true, false },
            { false, false, false, true,  false, true,  true,  true,  true,  false },
            { false, true,  true,  true,  false, false, false, true,  false, false },
            { false, true,  false, false, false, true,  true,  true,  false, false },
            { false, true,  true,  true,  false, false, false, true,  false, false },
            { false, false, false, false, false, false, false, false, false, false },
            
            };

            ShowTitle();
        }

        static void ShowTitle()
        {
            Console.WriteLine("아무키나 누르세요");

            Console.ReadKey(true);
            Console.Clear();
        }


        static void Render(Position playerPos, Position goalPos, bool[,] map)
        {

            Console.SetCursorPosition(0, 0);
            PrintMap(map);
            PrintPlayer(playerPos);
            PrintGoal(goalPos);
        }

        static void PrintMap(bool[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write('▒');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }

        static void PrintPlayer(Position playerPos)
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('P');
            Console.ResetColor();
        }

        static void PrintGoal(Position goalPos)
        {
            Console.SetCursorPosition(goalPos.x, goalPos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('G');
            Console.ResetColor();
        }

        static ConsoleKey Input()
        {
            ConsoleKey input = Console.ReadKey(true).Key;
            return input;
        }


        static void Update(ConsoleKey key, ref Position playerPos, Position goalPos, bool[,] map, ref bool gameOver)
        {
            Move(key, ref playerPos, map);
            bool isClear = CheckGameClear(playerPos, goalPos);

            if (!map[playerPos.y, playerPos.x]) // 벽에 닿으면 죽는 코드 구현
            {
                Console.Clear();
                Console.WriteLine("벽에 닿아서 죽었습니다!");
                Environment.Exit(0);
            }
            else if (isClear)
            {
                gameOver = true;
            }
        }

        static void Move(ConsoleKey key, ref Position playerPos, bool[,] map)
        {
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (map[playerPos.y, playerPos.x - 1] == true)
                    {
                        playerPos.x--;
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (map[playerPos.y, playerPos.x + 1] == true)
                    {
                        playerPos.x++;
                    }
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (map[playerPos.y - 1, playerPos.x] == true)
                    {
                        playerPos.y--;
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (map[playerPos.y + 1, playerPos.x] == true)
                    {
                        playerPos.y++;
                    }
                    break;
            }
        }

        static bool CheckGameClear(Position playerPos, Position goalPos)
        {
            bool success = (playerPos.x == goalPos.x) && (playerPos.y == goalPos.y);
            return success;
        }


        static void End()
        {

            Console.Clear();
            Console.WriteLine(" 　　(/ΩΩ/)\r\n　　 / ◎◎ /\r\n　　(＿ノ |  Chill하게 클리어\r\n　　　 |　|\r\n　　　 |　|\r\n　　 __|　|＿\r\n　　/ヘ　　/ )\r\n　　Lニニコ/\r\n　　 |￣￣￣|\r\n　　 |　　　|――三\r\n　　 |　∩　|\r\n　　 |　||　|\r\n　　 |　||　|\r\n　　 |二||二|");
        }
    }
}