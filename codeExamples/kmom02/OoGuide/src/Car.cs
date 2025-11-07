namespace OoGuide.src;

public class Car
{
    public const int WHEELS = 4;
    private static int _carCount = 0;

    private string _model;
    private int _price;

    public Car(string model, int price)
    {
        this._model = model;
        this._price = price;
        Car._carCount += 1;
    }

    // Static methods
    public static int GetCarCount()
    {
        return Car._carCount;
    }

    // Get methods
    public string GetModel()
    {
        return this._model;
    }

    public int GetPrice()
    {
        return this._price;
    }

    // Set methods
    public void SetModel(string newModel)
    {
        this._model = newModel;
    }

    public void SetPrice(int newPrice)
    {
        this._price = newPrice;
    }

    // Other methods
    public void Description()
    {
        Console.WriteLine($"Bilen är en {this._model} och kostar {this._price} kr.");
    }
}
