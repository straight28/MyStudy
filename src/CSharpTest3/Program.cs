using System;
using System.Collections.Generic;

namespace CSharpTest3
{
    class Program
    {

        class Map
        {
            int[,] tiles = {
                    {1,1,1,1,1},
                    {1,0,0,0,1},
                    {1,0,1,0,1},
                    {1,0,0,0,1},
                    {1,1,1,1,1},
            };

            public void Rander()
            {
                var defulatColor = Console.ForegroundColor;
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    for (int x = 0; x < tiles.GetLength(0); x++)
                    {
                        if (tiles[y, x] == 1)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else
                            Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write('\u25cf');
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = defulatColor;
            }
        }

        static void Main(string[] args)
        {
            Map map = new Map();
            map.Rander();

            int[] arr = new int[1000];
            //List <- 동적배열

            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);

            // 삽입
            list.Insert(2, 999);
            
            // 삭제 (값을 통해 삭제)
            bool success = list.Remove(3);

            // 삭제 (인덱스 통해 삭제)
            list.RemoveAt(3);

            // 완전 클리어
            list.Clear();

        }
    }
}
