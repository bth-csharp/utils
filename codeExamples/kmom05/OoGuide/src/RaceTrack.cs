namespace OoGuide.src;

class RaceTrack
{
    private const string NAME = "DBWEBB Racing track";
    private const int MINIMUM_FINISH = 20;
    private int _finishLine;
    private Weather? _weather = null; // null för att markera inget väder satt ännu
    private List<Car> _cars;
    private int _winnerIndex;

    public RaceTrack(int finishLine)
    {
        this._finishLine = finishLine;
        if (finishLine < RaceTrack.MINIMUM_FINISH)
        {
            this._finishLine = RaceTrack.MINIMUM_FINISH;
        }
        this._cars = new List<Car>();
        this.CreateRace();
        this._winnerIndex = -1; // negativt visar ingen vinnare
    }

    public List<Car> GetCars()
    {
        return this._cars;
    }

    // Other methods
    private void CreateRace()
    {
        string personData = "Säte läge: 3, Däcktemperatur: default, Chassi: default";
        Car car1 = new Sport(personData, "Ferrari", 899000);
        this._cars.Add(car1);
        Car car2 = new Passenger("Volvo", 99000);
        this._cars.Add(car2);
        Car car3 = new ElSuv(627, 28, true, "Ford Capri", 464000);
        this._cars.Add(car3);
    }

    public void Description()
    {
        Console.WriteLine($"\nVälkommen till {RaceTrack.NAME}!");
        if (this._weather != null)
        {
            Console.WriteLine($"{this._weather.GetForecast()}");
        }
    }

    private void PrintFinishLine(bool heading = true)
    {
        string spaces = new string(' ', this._finishLine);
        if (heading)
        {
            Console.WriteLine(string.Concat("\nSTART", spaces.AsSpan(0, spaces.Length - 6), "MÅL"));
        }
        Console.WriteLine(spaces + "|");
    }

    public void AddWeather(Weather newWeather)
    {
        this._weather = newWeather;
    }

    public string GetWeatherForecast()
    {
        string forecast = "Väder okänt";

        if (this._weather != null)
        {
            forecast = this._weather.GetForecast();
        }

        return forecast;
    }

    private void MoveCars()
    {
        this.PrintFinishLine();
        foreach (var aCar in this._cars)
        {
            if (this._winnerIndex < 0)
            {
                aCar.Description();
                aCar.Move();
                this.PrintFinishLine(false);
            }
        }
    }

    public void RunRace()
    {
        while (this._winnerIndex < 0)
        {
            Console.Clear(); // Rensar terminalen
            this.Description();
            this.MoveCars();
            this.CheckIfFinished();
            Thread.Sleep(100); // Pausar i 0,1 sekunder för att vi ska se förflyttningarna
        }
        Console.WriteLine("\n\nVINNAREN:");
        this._cars[this._winnerIndex].Description();
    }

    private void CheckIfFinished()
    {
        bool finished = false;
        int index = 0;

        while (index < this._cars.Count && !finished)
        {
            if (this._cars[index].GetPosition() > this._finishLine)
            {
                finished = true;
                this._winnerIndex = index;
            }
            index++;
        }
    }
}
