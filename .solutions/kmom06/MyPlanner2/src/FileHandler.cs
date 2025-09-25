using System.Threading.Tasks;

namespace MyPlanner2.src;

public class FileHandler : IFileHandler
{
    private readonly string _filename;

    public FileHandler(string filename)
    {
        this._filename = @filename;
    }


    public string[] Read()
    {
        string[] result = ReadAsync().Result;

        return result;
    }

    public void Save(string[] lines)
    {
        _ = SaveAsync(lines);
    }

    public async Task SaveAsync(string[] lines)
    {
        try
        {
            await File.WriteAllTextAsync(this._filename, string.Empty); // rensar filen
            foreach (var line in lines)
            {
                await File.AppendAllTextAsync(this._filename, line + Environment.NewLine);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Behörighet att öppna filen saknas: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ett IO (input/output fel inträffade): {ex.Message}");
        }
    }

    public async Task<string[]> ReadAsync()
    {
        string[] taskList = []; // tom array med strängar

        try
        {
            if (File.Exists(this._filename))
            {
                taskList = await File.ReadAllLinesAsync(this._filename);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Behörighet att öppna filen saknas: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ett IO (input/output fel inträffade): {ex.Message}");
        }

        return taskList;
    }
}
