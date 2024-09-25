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

    }
}
