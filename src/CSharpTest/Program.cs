using System;

namespace CSharpTest
{
    internal class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3,
        }

        struct Player
        {
            public int hp;
            public int attack;
            //public ClassType type;
        }

        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3,
            Dragon = 4
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }

        static ClassType ChooseClass()
        {
            Console.WriteLine(" 직업을 선택하세요 ! ");
            Console.WriteLine(" [1] 기사");
            Console.WriteLine(" [2] 궁수");
            Console.WriteLine(" [3] 법사");

            string input = Console.ReadLine();

            ClassType choice = ClassType.None;

            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    break;
                case "2":
                    choice = ClassType.Archer;
                    break;
                case "3":
                    choice = ClassType.Mage;
                    break;
            }
            return choice;
        }

        static void CreatePlayer(ClassType choice, out Player player)
        {
            // 기사(100/10) 궁수 (75/12) 법사 (50/15)
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 300;
                    player.attack = 50;
                    break;
                case ClassType.Archer:
                    player.hp = 275;
                    player.attack = 42;
                    break;
                case ClassType.Mage:
                    player.hp = 150;
                    player.attack = 80;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }

        }

        static void CreateRandomMonster(out Monster monster)
        {
            // 랜덤으로 1-3 몬스터 중 하나를 리스폰
            Random rand = new Random();
            int randMonster = rand.Next(1, 5);

            Console.WriteLine("");

            switch (randMonster)
            {
                case (int)MonsterType.Slime:

                    Console.WriteLine(" 슬라임이 스폰되었습니다! ");
                    monster.hp = 20;
                    monster.attack = 5;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine(" 오거가 스폰되었습니다! ");
                    monster.hp = 120;
                    monster.attack = 30;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.WriteLine(" 스켈레톤이 스폰되었습니다! ");
                    monster.hp = 80;
                    monster.attack = 45;
                    break;
                case (int)MonsterType.Dragon:
                    Console.WriteLine(" [보스] 드래곤이 스폰되었습니다! ");
                    monster.hp = 91320;
                    monster.attack = 5000;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }

        }

        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine(" 게임에 접속했습니다.");
                Console.WriteLine(" [1] 필드로 간다 ");
                Console.WriteLine(" [2] 로비로 간다 ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    EnterField(ref player);
                }
                else if (input == "2")
                {
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            while (true)
            {
                Console.WriteLine(" 필드에 접속했습니다.");

                // 몬스터 생성
                Monster monster;
                CreateRandomMonster(out monster);

                Console.WriteLine(" [1] 전투모드로 돌입");
                Console.WriteLine(" [2] 일정 확률로 마을로 도망");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Fight(ref player, ref monster);
                }
                else if (input == "2")
                {
                    //33%
                    Random rand = new Random();
                    int randValue = rand.Next(0, 101);

                    if (randValue <= 33)
                    {
                        Console.WriteLine(" 도망에 성공했습니다. ");
                        break;
                    }
                    else
                    {
                        Fight(ref player, ref monster);
                    }
                }
            }

        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                // 플레이어가 몬스터 공격
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    Console.WriteLine(" 전투에서 승리했습니다. ");
                    Console.WriteLine($" 남은 체력 : {player.hp} ");
                    break;
                }

                // 몬스터 공격
                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    Console.WriteLine(" 전투에서 패배했습니다. ");

                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ClassType choice = ChooseClass();
                if (choice == ClassType.None)
                    continue;

                // 캐릭터 생성
                Player player;

                CreatePlayer(choice, out player);

                Console.WriteLine($"");
                Console.WriteLine($" 당신의 스테이터스 ");
                Console.WriteLine($" HP {player.hp} ATTACK {player.attack} ");
                Console.WriteLine($"");

                EnterGame(ref player);

            }
        }


    }
}
