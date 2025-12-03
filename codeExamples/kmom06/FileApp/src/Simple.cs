namespace FileApp.src;

public class Simple
{
    private string _filename;

    public Simple(string filename)
    {
        this._filename = @filename;
    }

    public void Save(string line)
    {
        try
        {
            File.AppendAllText(this._filename, line + Environment.NewLine);
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

    private string[] Read()
    {
        string[] shoppingList = new string[]{}; // tom array med strängar

        try
        {
            if (File.Exists(this._filename))
            {
                shoppingList = File.ReadAllLines(this._filename);
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

        return shoppingList;
    }

    public void Present()
    {
        string[] shoppingList = new string[]{}; // tom array med strängar

        Console.WriteLine("Din shoppinglista");
        shoppingList = this.Read();

        if (shoppingList.Length == 0)
        {
            Console.WriteLine("Listan är tom");
            return;
        }
        foreach (string line in shoppingList)
        {
            Console.WriteLine(line);
        }
    }

    public void CheckQuantity(string quantity)
    {
        int checkedQuantity;
        
        if (string.IsNullOrWhiteSpace(quantity) || quantity.Length == 0)
        {
            throw new QuantityException("Antalet får inte vara tomt!");
        }
        if (!int.TryParse(quantity, out checkedQuantity))
        {
            throw new QuantityException("Du matade inte in ett tal! Talet ska vara 1 <= tal <= 20!");
        }
        if (checkedQuantity > 20)
        {
            throw new QuantityException("Du matade in ett för stort tal, 1 <= tal <= 20!");
        }
        if (checkedQuantity < 1)
        {
            throw new QuantityException("Du matade in ett för litet tal, 1 <= tal <= 20!");
        }
    }
}