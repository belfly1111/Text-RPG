using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Player
    {
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
            Inventory = new List<Item>();
        }

        public void PlayerInfo()
        {
            while(true)
            {
                Console.Clear();

                string curAttack = "";
                if (Attack > 10) curAttack += String.Format( " (+{0}) ",(Attack - 10).ToString());

                string curDefense = "";
                if (Defense > 5) curDefense += String.Format(" (+{0}) ", (Defense - 5).ToString());

                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine("Lv. {0}", Level);
                Console.WriteLine("{0} ( {1} )", Name, "전사");
                Console.WriteLine("공격력 : {0} {1}", Attack, curAttack);
                Console.WriteLine("방어력 : {0} {1}", Defense, curDefense);
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

        public void InvenSystem()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                if(Inventory != null)
                {
                    PrintInvenItem(false);
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
                    if (InvenSystem_Item_Management()) continue;  
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

        public bool InvenSystem_Item_Management()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                if (Inventory != null)
                {
                    PrintInvenItem(true);
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

                if (curInput.GetType() == typeof(int) && Inventory != null && curInput >= 1)
                {
                    if(curInput >= 1 && curInput <= Inventory.Count)
                    {
                        if (Inventory[curInput - 1].isEquiped)
                        {
                            Inventory[curInput - 1].isEquiped = false;
                            if (Inventory[curInput - 1].haveAttackStat) Attack -= Inventory[curInput - 1].AttackStat;
                            if (Inventory[curInput - 1].haveDefenseStat) Defense -= Inventory[curInput - 1].DefenseStat;
                        }
                        else
                        {
                            Inventory[curInput - 1].isEquiped = true;
                            if (Inventory[curInput - 1].haveAttackStat) Attack += Inventory[curInput - 1].AttackStat;
                            if (Inventory[curInput - 1].haveDefenseStat) Defense += Inventory[curInput - 1].DefenseStat;
                        }

                        continue;
                    }
                }
                else if(curInput == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    string temp = Console.ReadLine()!;
                }
            }

            return true;
        }

        public void PrintInvenItem(bool isEquipDecision)
        {
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Inventory.Count; i++)
            {
                string EquipDecision = "";
                if (isEquipDecision)
                {
                    EquipDecision += (i + 1).ToString();
                }

                Console.WriteLine("- {0} {1}", EquipDecision, Inventory[i].ItemInfo());
            }

            Console.Write("\n");
        }
    }
}
