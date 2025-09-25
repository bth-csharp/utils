namespace Dice100.src;

public class Helpers
{
    // Methods
    public static void GetTerminalReady(string title)
    {
        Console.Clear();
        Console.Title = title;
    }

    public static int ReadIntFromTerminal(string info)
    {
        Console.WriteLine("\n" + info);
        string input = Console.ReadLine() ?? "1";

        return int.Parse(input);
    }

    public static void PrintDateAndTimeNow()
    {
        DateTime presentTime = DateTime.Now;

        Console.WriteLine("Dagens datum: " + presentTime.ToString("yyyy-MM-dd"));
        Console.WriteLine("Tiden: " + presentTime.ToString("HH:mm:ss"));
    }
}