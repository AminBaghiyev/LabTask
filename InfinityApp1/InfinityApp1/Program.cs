namespace InfinityApp1;

internal class Program
{
    static void Main(string[] args)
    {
        string input = "";

        while (input != "6")
        {
            WelcomeMsg();
            input = Console.ReadLine().Trim();

            switch (input)
            {
                case "0":
                    Console.WriteLine("0 ise dusdu");
                    break;
                case "1":
                    Console.WriteLine("1 ise dusdu");
                    break;
                case "2":
                    Console.WriteLine("2 ise dusdu");
                    break;
                case "3":
                    Console.WriteLine("3 ise dusdu");
                    break;
                case "4":
                    Console.WriteLine("4 ise dusdu");
                    break;
                case "5":
                    Console.WriteLine("5 ise dusdu");
                    break;
                default:
                    Console.WriteLine("Bele bir komanda yoxdur");
                    break;
            }
        }
    }

    static void WelcomeMsg()
    {
        Console.WriteLine("""
0 - Informasiya
1 - Shoot
2 - Fire
3 - GetRemainBulletCount
4 - Reload
5 - ChangeFireMode
6 - Quit from app

""");
    }
}