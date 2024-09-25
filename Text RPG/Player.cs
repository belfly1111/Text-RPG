using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Player
    {
        // 자동 구현 프로퍼티를 사용해 외부에서 잘못된 변수가 들어오면 차단한다.
        // 단, 이름으로 플레이어를 구분하기 때문에 Name 변수는 외부의 직접적 접근을 막는다.
        private string name = "스파르타 용사";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Level { get; set; } = 1;
        public int Attack { get; set; } = 10;
        public int Defense { get; set; } = 5;
        public int Hp { get; set; } = 100;
        public int Gold { get; set; } = 1500;

        public List<Item> Inventory { get; set; }


        public Player(string PlayerName)
        {
            Name = PlayerName;
        }

        public void PlayerInfo()
        {
            while(true)
            {
                Console.Clear();

                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine("Lv. {0}", Level);
                Console.WriteLine("{0} ( {1} )", "전사", Name);
                Console.WriteLine("공격력 : {0}", Attack);
                Console.WriteLine("방어력 : {0}", Defense);
                Console.WriteLine("체력 : {0}", Hp);
                Console.WriteLine("Gold : {0}\n", Gold);

                Console.WriteLine("0. 나가기\n", Gold);

                Console.WriteLine("원하시는 행동을 입력해주세요.");

                int curInput = 0;
                try
                {
                    curInput = int.Parse(Console.ReadLine()!);
                }
                catch
                {
                    curInput = -1;
                }


                if (curInput == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    string temp = Console.ReadLine()!;
                }
            }
        }

        public void PlayerInven()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]\n");

                if(Inventory != null)
                {
                    PrintInvenItem();
                }

                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");

                int curInput = 0;
                try
                {
                    curInput = int.Parse(Console.ReadLine()!);
                }
                catch
                {
                    curInput = -1;
                }


                if(curInput == 1)
                {
                    PlayerInven_Management();
                }
                else if (curInput == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    string temp = Console.ReadLine()!;
                }
            }
        }

        public void PlayerInven_Management()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                if (Inventory != null)
                {
                    PrintInvenItem();
                }
                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");

                int curInput = 0;
                try
                {
                    curInput = int.Parse(Console.ReadLine()!);
                }
                catch
                {
                    curInput = -1;
                }

                if (curInput == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    string temp = Console.ReadLine()!;
                }
            }
        }

        public void PrintInvenItem()
        {
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Inventory.Count; i++)
            {
                string curItem = "- ";
                curItem += i.ToString() + " ";
                if (Inventory[i].isEquiped)
                {
                    curItem += "[E]";
                }

                curItem += Inventory[i].Name + "    | ";

                if (Inventory[i].haveAttackStat)
                {
                    curItem += ("공격력 +{0} | ", Inventory[i].AttackStat.ToString());
                }
                if (Inventory[i].haveDefenseStat)
                {
                    curItem += ("방어력 +{0} | ", Inventory[i].DefenseStat.ToString());
                }

                curItem += Inventory[i].Explanation;
                Console.WriteLine(curItem);
            }
            Console.WriteLine("\n");
        }
    }
}
