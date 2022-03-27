using System;

namespace AlgoTest2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
           

            while (true) 
            {
                #region 프레임 관리

                // 시스템 시작 이후에 경과된 밀리세컨드
                // 만약 경과한 시간이 1/30초 보다 작다면

                // int currentTick = System.Environment.TickCount;
                // if (currentTick - lastTick < WAIT_TICK)
                //     continue;
                // lastTick = currentTick;

                #endregion

                // 입력
                // 로직
                // 렌더링
                Console.SetCursorPosition(0, 0);
                board.Render();
            }

        }
    }
}
