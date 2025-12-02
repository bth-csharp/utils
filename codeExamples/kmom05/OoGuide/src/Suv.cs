namespace OoGuide.src;

public class Suv : Car
{
    private const float MAX_SPEED = 3.0f;
    private const float MIN_SPEED = 1.0f;    
    private bool _fourWheelOn; // true om fyrhjulsdrift är på


    public Suv(bool fourWheelOn, string model, int price) : base(model, price)
    {
        this._fourWheelOn = fourWheelOn;
        base._speed = this.CalculateSpeed(Suv.MIN_SPEED, Suv.MAX_SPEED);
    }

    public void ToggleFourWheel()
    {
        this._fourWheelOn = !this._fourWheelOn;
    }

    public override void Description() // overrides Description in base class
    {
        string message = $"Det är en SUV, hastighet: {this._speed:F2} och fyrhjulsdrift är";

        base.Description();
        message += this._fourWheelOn ? " på." : " av.";
        Console.WriteLine(message);
    }

    protected override float CalculateSpeed(float minSpeed = 0.5f, float maxSpeed = 3.5f)
    {
        Random random = new Random();

        return (float)(minSpeed + (random.NextDouble() * 0.9 * (maxSpeed - minSpeed)));
    }
}
