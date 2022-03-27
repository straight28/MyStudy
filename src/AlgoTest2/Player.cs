using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest2
{
    class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; }

        Random _random = new Random();


        Board _board;

        public void Initialize(int posY, int posX, int desY, int desX, Board board)
        {
            PosY = posY;
            PosX = posX;
            _board = board;

        }

        // 시간 차이를 넘겨받음
        // 전역 변수 설정이지만 아래 함수에서만 쓰일 내용이므로 바로 위에 표기
        const int MOVE_TICK = 100;  // 0.1초마다 움직이고 싶음
        int _sumTick = 0;
        public void Update(int deltaTick)
        {
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                // 초기화
                _sumTick = 0;


                // 여기에다가 0.1초마다 실행될 로직을 넣어준다.
                int randValue = _random.Next(0, 5);

                switch (randValue)
                {

                    case 0:  // 상
                        if (PosY - 1 >= 0 && _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                            PosY = PosY - 1;
                        break;
                    case 1:  // 하
                        if (PosY + 1 < _board.Size && _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                            PosY = PosY + 1;
                        break;
                    case 2:  // 좌
                        if (PosX - 1 >= 0 && _board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                            PosX = PosX - 1;
                        break;
                    case 3:  // 우
                        if (PosX + 1 < _board.Size && _board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                            PosX = PosX + 1;
                        break;
                    default:
                        break;
                }

            }
        }


    }
}
