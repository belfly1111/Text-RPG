using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Item
    {
        public string Name { get; set; } = "임시";
        public string Explanation { get; set; } = "임시";

        public int Price { get; set; } = 0;
        public int AttackStat { get; set; } = 0;
        public int DefenseStat { get; set; } = 0;
        public bool isEquiped { get; set; } = false;
        public bool haveAttackStat { get; set; } = false;
        public bool haveDefenseStat { get; set; } = false;

        public Item(string name, string explanation, int price, int atkStat, int dtsStat)
        {
            Name = name;
            Explanation = explanation;
            Price = price;
            AttackStat = atkStat;
            DefenseStat = dtsStat;
            if (AttackStat > 0) haveAttackStat = true;
            if (DefenseStat > 0) haveDefenseStat = true;
        }

        public string ItemInfo()
        {
            string NameInfo = "";
            if (isEquiped) NameInfo = "[E]" + Name;
            else NameInfo = Name;

            string StatInfo = "";
            if (haveAttackStat) StatInfo += "공격력 +" + AttackStat.ToString();
            if (haveDefenseStat) StatInfo += "방어력 +" + DefenseStat.ToString();

            string Info = string.Format("{0}    | {1} | {2}", NameInfo, StatInfo, Explanation);
            return Info;
        }
    }
}
