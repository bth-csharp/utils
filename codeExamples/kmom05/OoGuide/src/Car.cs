namespace OoGuide.src;

public class Car
{
    private const int WHEELS = 4;
    private static int _carCount = 0;

    private string _model;
    private int _price;
    protected int _position;
    protected float _speed;

    public Car(string model, int price, string type = "Passenger")
    {
        this._model = model;
        this._price = price;
        this._position = 0;
        this._speed = 1F;
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

    protected virtual float CalculateSpeed(float minSpeed = 0.5f, float maxSpeed = 3.5f)
    {
        Random random = new Random();

        return (float)(minSpeed + (random.NextDouble() * (maxSpeed - minSpeed)));
    }

    // Get methods
    public int GetPosition()
    {
        return this._position;
    }

    // Other methods
    public virtual void Description() // may be overridden in sub class
    {
        Console.WriteLine($"Bilen är en {this._model} och kostar {this._price} kr.");
    }

    public void Move()
    {
        this._position += (int)Math.Round(this._speed);
        this.PrintAsciiModel(new string(' ', this._position));
    }

    // Asci art method
    public void PrintAsciiModel(string pos = "")
    {
        Console.WriteLine(AsciiArt.GetAsciiModel(this.GetType().Name, pos));
    }
}
