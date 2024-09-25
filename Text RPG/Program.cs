namespace Text_RPG
{
    internal class Program
    {
        public bool isTown { get; set; } = true;

        static void Main(string[] args)
        {
            Program TextRPG = new Program();
            Player curPlayer = new Player(TextRPG.SetNameSystem());
            Store store = new Store();

            while (true)
            {
                Console.Clear();
                int Choice = TextRPG.Town();
                if (Choice == 1)
                {
                    curPlayer.PlayerInfo();
                }
                else if(Choice == 2)
                {
                    curPlayer.InvenSystem();
                }
                else if (Choice == 3)
                {
                    store.StoreSystem(curPlayer);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    string temp = Console.ReadLine()!;
                }
            }
        }

        public string SetNameSystem()
        {
            string inputName = "";

            while (true)
            {
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n원하시는 이름을 설정해주세요.\n");
                inputName = Console.ReadLine()!;
                if (string.IsNullOrEmpty(inputName))
                {
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("\n입력하신 이름은 {0} 입니다.\n", inputName);

                Console.WriteLine("1. 저장\n2. 취소\n");

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
                
                if (curInput == 1)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    continue;
                }
            }

            return inputName;
        }

        public int Town()
        {
            while (true)
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

                Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n");

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
                return curInput;
            }
        }
    }
}