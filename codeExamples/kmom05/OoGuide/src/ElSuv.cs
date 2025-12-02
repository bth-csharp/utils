namespace OoGuide.src;

public class ElSuv : Suv
{
    private double _range; // räckvidd i km
    private double _chargingTime;  // snabbladdare tid i minuter


    public ElSuv(double range, double time, bool fourWheelOn, string model, int price) : base(fourWheelOn, model, price)
    {
        this._range = ( range > 0 ) ? range : 0;
        this._chargingTime = ( time > 0) ? time : 0;
    }

    public override void Description() // overrides Description in base class
    {
        string message = $"Det är en el SUV med räckvidd: {this._range:F1} km och laddtid (snabbladdare): {this._chargingTime:F1} minuter.";

        base.Description();        
        Console.WriteLine(message);
    }
}