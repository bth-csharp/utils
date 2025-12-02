namespace OoGuide.src;

public class Sport : Car
{
    private const float MAX_SPEED = 5.5F;
    private const float MIN_SPEED = 2.5F;

    private string _personData; // personlig data för att anpassa bilen efter föraren

    public Sport(string personData, string model, int price) : base(model, price)
    {
        this._personData = personData;
        base._speed = base.CalculateSpeed(Sport.MIN_SPEED, Sport.MAX_SPEED);
    }

    public void SetPersonData(string newPersonData)
    {
        if (newPersonData.Length > 20 )
        {
            this._personData = newPersonData;
        }
    }

    public override void Description() // overrides Description in base class
    {
        base.Description(); // Anropar basklassens metod
        Console.WriteLine($"Det är en sportbil, hastighet: {this._speed:F2}. Personlig data:");
        Console.WriteLine(this._personData);
    }
}
