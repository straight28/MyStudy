using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest2
{

    class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] _tile;
        public int _size;

        Player _player;

        public enum TileType
        {
            Empty,
            Wall
        }


        public void Initialize(int size, Player player)
        {
            if (size % 2 == 0)
                return;

            _tile = new TileType[size, size];
            _size = size;

            _player = player;

            // GenerateByBinaryTree();
            GenerateBySideWinder();

        }


        // 미로 생성
        // Binary Tree Alorithm
        private void GenerateByBinaryTree()
        {
            // 길을 막음
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    //if (x == 0 || x == _size - 1 || y == 0 || y == size - 1)
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        _tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        _tile[y, x] = TileType.Empty;
                    }
                }
            }

            // 랜덤으로 우측 혹은 아래로 길을 뚫는 작업

            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    //if (x == 0 || x == _size - 1 || y == 0 || y == size - 1)
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == _size - 2 && x == _size - 2)
                        continue;

                    // 우측 맨 마지막이 벽이라면
                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    // 하단 맨 마지막이 벽이라면
                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    // 1/2 확률?
                    if (rand.Next(0, 2) == 0)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        _tile[y + 1, x] = TileType.Empty;
                    }

                }
            }
        }

        // 미로 생성
        // SideWinder 우측으로 미로를 생성한 미로칸 중 랜덤 미로칸을 선택해서 아래로 미로 생성
        private void GenerateBySideWinder()
        {
            // 길을 막음
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    //if (x == 0 || x == _size - 1 || y == 0 || y == size - 1)
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        _tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        _tile[y, x] = TileType.Empty;
                    }
                }
            }

            // 랜덤으로 우측 혹은 아래로 길을 뚫는 작업

            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                // 연속된 점의 갯수
                int count = 1;

                for (int x = 0; x < _size; x++)
                {
                    //if (x == 0 || x == _size - 1 || y == 0 || y == size - 1)
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    // 우측 맨 마지막이 벽이라면
                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    // 하단 맨 마지막이 벽이라면
                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        // 우측으로 길을 뚫음
                        _tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        // 아래로 길을 뚫음
                        int randomIndex = rand.Next(0, count);
                        _tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }

                }
            }
        }



        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    
                    Console.ForegroundColor = GetTileColor(_tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }

    }
}
