namespace Dice100.src;

public class FileHandler
{
    public static void SaveToFile(string filename, string[] line)
    {
        try
        {
            File.AppendAllLines(@filename, line);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade vid skrivning filen: {ex.Message}");
        }
    }

    public static string[] ReadFromFile(string filename)
    {
        string[] topList = Array.Empty<string>();

        try
        {
            topList = File.ReadAllLines(@filename);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade vid läsning av filen: {ex.Message}");
        }

        return topList;
    }
}