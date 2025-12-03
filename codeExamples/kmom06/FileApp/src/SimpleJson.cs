namespace FileApp.src;

using System;
using System.IO;
using System.Text.Json;

public class SimpleJson
{
    private string _filename;

    public SimpleJson(string filename)
    {
        this._filename = @filename;
    }

    public void Save(string line)
    {
        try
        {
            string[] lineSplit = line.Split(' ');
            var dataToSave = new ProductData();
            List<ProductData> dataList = Read();

            dataToSave.Product = lineSplit[0];
            dataToSave.Quantity = lineSplit[1];
            dataList.Add(dataToSave);

            // Konvertera data till JSON-sträng
            string jsonString = JsonSerializer.Serialize(dataList, new JsonSerializerOptions() { WriteIndented = true });

            // Skapa en StreamWriter för att skriva JSON till filen
            using (StreamWriter writer = new StreamWriter(this._filename))
            {
                writer.WriteLine(jsonString);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ett fel inträffade vid skrivning filen: {ex.Message}");
        }
    }

    private List<ProductData> Read()
    {
        string? jsonData;
        List<ProductData> dataList = new List<ProductData>();

        if (File.Exists(this._filename))
        {
            // Läs JSON från filen
            using (StreamReader reader = new StreamReader(this._filename))
            {
                jsonData = reader.ReadToEnd();
            }

            // Konvertera JSON till objekt
            dataList = JsonSerializer.Deserialize<List<ProductData>>(jsonData) ?? new List<ProductData>();
        }

        return dataList;
    }

    public void Present()
    {
        Console.WriteLine("\nDin shoppinglista");
        try
        {
            List<ProductData> dataList = Read();

            if (dataList.Count == 0)
            {
                Console.WriteLine("Listan är tom");
                return;
            }
            foreach (ProductData row in dataList)
            {
                Console.WriteLine(row.Product + " " + row.Quantity);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ett fel inträffade vid läsning av filen: {ex.Message}");
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

internal class ProductData
{
    public string? Product { get; set; }
    public string? Quantity { get; set; }
}
