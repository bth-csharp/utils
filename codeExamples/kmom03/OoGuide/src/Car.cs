namespace OoGuide.src;

public class Car
{
    private const int WHEELS = 4;
    private static int _carCount = 0;

    private string _model;
    private int _price;
    private string _type;
    private int _position;
    private float _speed;

    public Car(string model, int price, string type = "Passenger")
    {
        this._model = model;
        this._price = price;
        this._type = type;
        this._position = 0;
        this._speed = CalculateSpeed();
        Car._carCount += 1;
    }

    // Static methods
    public static int GetCarCount()
    {
        return Car._carCount;
    }

    public static int GetWheels()
    {
        return Car.WHEELS;
    }

    public static void DescriptionStatic()
    {
        Console.WriteLine($"Bilen har {Car.WHEELS} hjul och är bil nummer {Car._carCount}.");
    }

    public static int CalculatePriceReduction(int price)
    {
        return (int)(price * 0.66); // type cast double from calculation to int
    }

    // Overloading the '+' operator for adding the price of two instances of the class Car
    public static int operator +(Car car1, Car car2)
    {
        return (int)(car1.GetPrice() + car2.GetPrice());
    }

    // Overloading the '+' operator for adding the price of one instances of 
    // the class Car and an integer amount
    public static int operator +(Car car1, int amount)
    {
        return (int)(car1.GetPrice() + amount);
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

    public int GetPosition()
    {
        return this._position;
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

    public void PrintAsciiModel(string pos = "")
    {
        Console.WriteLine(AsciiArt.GetAsciiModel(this._type, pos));
    }

    private float CalculateSpeed()
    {
        Random random = new Random();
        const float MAX_SPEED = 3.5F;
        const float MIN_SPEED = 0.5F;

        return (float)(MIN_SPEED + (random.NextDouble() * (MAX_SPEED - MIN_SPEED)));
    }

    public void Move()
    {
        this._position += (int)Math.Round(this._speed);
        this.PrintAsciiModel(new string(' ', this._position));
        this._speed = CalculateSpeed(); // ny hastighet för mer spänning
    }
}
