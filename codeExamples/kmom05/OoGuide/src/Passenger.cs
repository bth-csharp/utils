namespace OoGuide.src;

public class Passenger : Car
{
    private bool _echoDrivingOn; // true om echo driving är på

    public Passenger(string model, int price) : base(model, price)
    {
        this._echoDrivingOn = false; // bästa race läget
        base._speed = base.CalculateSpeed(); // använder defaultparametrarna
    }

    public void ToggleEchoDriving()
    {
        this._echoDrivingOn = !this._echoDrivingOn;
    }

    public override void Description() // overrides Description in base class
    {
        string message = $"Det är en passagerarbil, hastighet: {this._speed:F2} och echo driving är";

        base.Description();
        message += this._echoDrivingOn ? " på." : " av.";
        Console.WriteLine(message);
    }
}
