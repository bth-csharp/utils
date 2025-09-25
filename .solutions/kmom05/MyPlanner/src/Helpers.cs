namespace MyPlanner.src;

public static class Helpers
{
    // Methods
    public static void GetTerminalReady(string title)
    {
        Console.Clear();
        Console.Title = title;
    }

    public static int ReadIntFromTerminal(string info)
    {
        Console.Write("\n" + info);
        string input = Console.ReadLine() ?? "1";
        if (!int.TryParse(input, out int number))
        {
            number = 1;
        }

        return number;
    }

    public static string ReadStringFromTerminal(string info)
    {
        Console.Write(info);
        string input = Console.ReadLine() ?? "";

        return input;
    }
}
