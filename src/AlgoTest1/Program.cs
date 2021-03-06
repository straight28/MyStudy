using System;

namespace AlgoTest1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Initialize();

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;
            const char CIRCLE = '\u25cf';
            int lastTick = 0;


            while (true)
            {
                #region 프레임 관리

                // 시스템 시작 이후에 경과된 밀리세컨드
                // 만약 경과한 시간이 1/30초 보다 작다면
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                lastTick = currentTick; 

                #endregion

                // 입력


                // 로직


                // 렌더링
                Console.SetCursorPosition(0,0);

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(CIRCLE);
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}
