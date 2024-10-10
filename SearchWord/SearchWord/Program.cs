namespace SearchWord;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Mətn daxil edin: ");
        string textInput = Console.ReadLine();
        Console.Write("Axtarılacaq sözü daxil edin: ");
        string searchInput = Console.ReadLine();
        bool response = SearchWord(textInput, searchInput);

        if (response)
            Console.WriteLine($"{searchInput} tapıldı");
        else
            Console.WriteLine($"{searchInput} tapılmadı");
    }

    public static bool SearchWord(string text, string search)
    {
        for (int i = 0; i <= text.Length - search.Length; i++)
        {
            if (text.Substring(i, search.Length) == search) return true;
        }
        return false;
    }
}