using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 조건문 분기가 깔끔하게 읽히지 않습니다. 더 좋은 구조나 방법이 있지

namespace Text_RPG
{
    internal class Store
    {
        internal class SellingItem
        {
            public Item Item { get; set; }
            public bool isSold { get; set; } = false;

            public SellingItem(Item item, bool curStatus)
            {
                Item = item;
                isSold = curStatus;
            }
        }

        public List<SellingItem> Stall { get; set; } = new List<SellingItem>();

        public Store()
        {
            Item NoviceArmor = new Item
                (
                   "수련자 갑옷",
                   "수련에 도움을 주는 갑옷입니다.",
                   1000,
                   0,
                   5
                );

            Item CastIronArmor = new Item
                (
                   "무쇠 갑옷",
                   "무쇠로 만들어져 튼튼한 갑옷입니다.",
                   2000,
                   0,
                   9
                );

            Item SpartaArmor = new Item
                (
                   "스파르타 갑옷",
                   "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                   3500,
                   0,
                   15
                );

            Item OldSword = new Item
                (
                   "낡은 검",
                   "쉽게 볼 수 있는 낡은 검 입니다.",
                   600,
                   2,
                   0
                );

            Item BronzeAx = new Item
                (
                   "청동 도끼",
                   "어디선가 사용됐던거 같은 도끼입니다.",
                   1500,
                   5,
                   0
                );

            Item SpartanSpear = new Item
                (
                   "스파르타의 창",
                   "스파르타의 전사들이 사용했다는 전설의 창입니다.",
                   1000,
                   7,
                   0
                );

            Stall.Add(new SellingItem(NoviceArmor, false));
            Stall.Add(new SellingItem(CastIronArmor, false));
            Stall.Add(new SellingItem(SpartaArmor, false));
            Stall.Add(new SellingItem(OldSword, false));
            Stall.Add(new SellingItem(BronzeAx, false));
            Stall.Add(new SellingItem(SpartanSpear, false));
        }

        public void StoreSystem(Player customer_Player)
        {
            bool isPurchaseDecision = false;
            while (true)
            {
                Console.Clear();

                if(!isPurchaseDecision) Console.WriteLine("상점");
                else Console.WriteLine("상점 - 아이템 구매");

                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine("{0} G\n" , customer_Player.Gold.ToString());

                PrintStallItem(isPurchaseDecision);

                if(!isPurchaseDecision) Console.WriteLine("1. 아이템 구매");
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

                if(!isPurchaseDecision)
                {
                    if (curInput == 0)
                    {
                        break;
                    }
                    else if (curInput == 1)
                    {
                        isPurchaseDecision = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        string temp = Console.ReadLine()!;
                    }
                }
                else
                {
                    if (curInput == 0) break;
                    PurchaseSystem(curInput, customer_Player);
                }
            }
        }

        public void PrintStallItem(bool isPurchaseDecision)
        {
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Stall.Count; i++)
            {
                string PurchaseDecision = " ";
                if(isPurchaseDecision)
                {
                    PurchaseDecision += (i + 1).ToString();
                }

                string Status = "";
                if (Stall[i].isSold)
                {
                    Status = "구매 완료";
                }
                else Status = Stall[i].Item.Price.ToString() + " G";


                Console.WriteLine("- {0} {1}        | {2}", PurchaseDecision, Stall[i].Item.ItemInfo() , Status);
            }

            Console.Write("\n");
        }

        public void PurchaseSystem(int curInput, Player customer_Player)
        {
            if (curInput.GetType() == typeof(int) && curInput <= Stall.Count && curInput >= 1)
            {
                int indexInput = curInput - 1;

                if (Stall[indexInput].isSold)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    string temp = Console.ReadLine()!;
                }
                else if (!Stall[indexInput].isSold)
                {
                    if (customer_Player.Gold >= Stall[indexInput].Item.Price)
                    {
                        customer_Player.Gold -= Stall[indexInput].Item.Price;
                        customer_Player.Inventory.Add(Stall[indexInput].Item);
                        Stall[indexInput].isSold = true;

                        Console.WriteLine("구매를 완료했습니다.");
                        string temp = Console.ReadLine()!;
                    }
                    else
                    {
                        Console.WriteLine("Gold 가 부족합니다.");
                        string temp = Console.ReadLine()!;
                    }
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                string temp = Console.ReadLine()!;
            }
        }
    }
}
