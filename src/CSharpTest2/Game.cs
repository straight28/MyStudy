using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest2
{
    public enum GameMode
    {   
        None,
        Lobby,
        Town,
        Field
    }

    class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player Player = null;
        private Monster monster = null;

        Random rand = new Random();

        public void Process()
        {
            switch (mode) 
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요");
            Console.WriteLine("[1] 기사 ");
            Console.WriteLine("[2] 법사 ");
            Console.WriteLine("[3] 궁수 ");
            

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Player = new Knight();
                    mode = GameMode.Town;
                    break;
                case "2":
                    Player = new Mage();
                    mode = GameMode.Town;
                    break;
                case "3":
                    Player = new Archer();
                    mode = GameMode.Town;
                    break;
            }
        }


        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다");
            Console.WriteLine("[1] 필드로 가기 ");
            Console.WriteLine("[2] 로비로 돌아가기 ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    mode = GameMode.Lobby;
                    break;
            }

        }


        private void ProcessField()
        {
            Console.WriteLine("필드에 입장했습니다");
            Console.WriteLine("[1] 전투시작 ");
            Console.WriteLine("[2] 마을로 도망가기(확률) ");

            CreateRandomMonster();

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    TryEscape();
                    
                    break;
            }

        }

        private void TryEscape()
        {
            int randValue = rand.Next(0,100);  

            if(randValue < 33)
            {
                mode = GameMode.Town;  
            }
            else
            {
                ProcessFight();
            }
        }

        private void ProcessFight()
        {
            while (true)
            {
                int damage = Player.GetAttack();
                monster.OnDamaged(damage);

                if (monster.IsDead())
                {
                    Console.WriteLine("승리했습니다");
                    Console.WriteLine($"남은 체력 {Player.GetHp()}");
                    break;
                }

                damage = monster.GetAttack();
                Player.OnDamaged(damage);

                if (Player.IsDead())
                {
                    Console.WriteLine("패배했습니다");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }

        private void CreateRandomMonster()
        {
            int randValue = rand.Next(0, 3);

            switch (randValue)
            {
                case 0:
                    monster = new Slime();
                    Console.WriteLine("슬라임이 생성되었습니다.");

                    break;
                case 1:
                    monster = new Orc();
                    Console.WriteLine("오거가 생성되었습니다. ");
                    break;
                case 2:
                    monster = new Skeleton();
                    Console.WriteLine("스켈레톤이 생성되었습니다. ");
                    break;
            }
        }

    }
}

