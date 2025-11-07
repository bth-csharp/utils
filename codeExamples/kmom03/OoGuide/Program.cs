using OoGuide.src;

static void TestingPrivatePrintouts()
{
    // Console.WriteLine("Antal hjul: " + Car.WHEELS);
    // Ger kompileringsfelet: error CS0122: 'Car.Wheels' is inaccessible due to its protection level

    RaceTrack track1 = new RaceTrack(100);
    //track1.PrintFinishLine();
    // Ger kompileringsfelet:  error CS0122: 'RaceTrack.PrintFinishLine()' is inaccessible due to its protection level
    track1.Description();
}

// TestingPrivatePrintouts();

static void TestingStaticMethodPrintouts()
{
    Console.WriteLine("Antal hjul: " + Car.GetWheels());

    Car bmw = new Car("BMW", 100000);

    bmw.Description();
    Car.DescriptionStatic();

    Console.WriteLine($"Prisreduktion: {Car.CalculatePriceReduction(bmw.GetPrice())} kr.");
}

// TestingStaticMethodPrintouts();

static void TestingOperatorOverloadPrintouts()
{
    Car bmw = new Car("BMW", 100000);
    Car volvo = new Car("Volvo", 80000);

    Console.WriteLine("Addera priset: " + (bmw + volvo));

    Console.WriteLine("Addera priset (Car+int): " + (bmw + 10000));
}

// TestingOperatorOverloadPrintouts();

static void TestObjectInObject()
{
    Weather weather = new Weather("Soligt", 18, 8);
    Console.WriteLine(weather.GetForecast());

    weather.Update("Halvmulet", 15, 4);
    Console.WriteLine(weather.GetForecast());

    RaceTrack track = new RaceTrack(100);
    Console.WriteLine(track.GetWeatherForecast());
    track.AddWeather(weather);
    Console.WriteLine(track.GetWeatherForecast());

    track.Description();
}

// TestObjectInObject();

RaceTrack track = new RaceTrack(100);
Weather weather = new Weather("Soligt", 18, 8);

track.AddWeather(weather);
track.RunRace();
