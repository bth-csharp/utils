using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OoGuide.src;
public class Weather
{
    private string _type;
    private double _temperature;
    private double _wind;

    public Weather(string type, double temperature, double wind)
    {
        this._type = type;
        this._temperature = temperature;
        this._wind = wind;
    }

    public string GetForecast()
    {
        return $"Väder: {this._type}, {this._temperature} grader och {this._wind} m/s.";
    }

    public void Update(string type, double temperature, double wind)
    {
        // borde hämta infon från någon vädersida istället
        this._type = type;
        this._temperature = temperature;
        this._wind = wind;
    }
}
