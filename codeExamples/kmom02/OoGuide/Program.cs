using OoGuide.src;

static void TestingClassPrintouts()
{
    Car bmw = new Car("BMW", 100000);
    Car volvo = new Car("Volvo", 150000);
    Car extraCar = volvo;

    Console.WriteLine("Antal hjul: " + Car.WHEELS);
    // ger utskriften: Antal hjul: 4

    // Console.WriteLine("Antal hjul: " + bmw.WHEELS);
    // ger utskriften: error CS0176: Member 'Car.GetWHEELS()' cannot be accessed with an instance reference; qualify it with a type name instead. Alltså måste statiska variabler accessas via klassnamnet annars får vi kompileringsfel.

    // Console.WriteLine("Antal bilar: " + Car.CarCount); // Funkar ej, CarCount är private
    // Ger kompileringsfel: error CS0117: 'Car' does not contain a definition for 'CarCount'

    Console.WriteLine("Antal bilar: " + Car.GetCarCount());
    // ger utskriften: Antal bilar: 2

    Console.WriteLine(volvo);
    // Först namespace följt av en punkt och sen klassnamnet. Alla instanser av klassen Car för samma utskrift.

    if (!Object.Equals(bmw, volvo))
        Console.WriteLine("bmw och volvo är olika instanser på olika platser i minnet");
    // ger utskriften: bmw och volvo är olika instanser på olika platser i minnet

    if (Object.Equals(volvo, extraCar))
        Console.WriteLine("extraCar och volvo är samma instans och pekar på samma plats i minnet");
    // ger utskriften: extraCar och volvo är samma instans och pekar på samma plats i minnet

    Console.WriteLine("Model: " + bmw.GetModel());
    // ger utskriften: Model: BMW

    Console.WriteLine($"Model: {volvo.GetModel()} och pris: {volvo.GetPrice()} kr");
    // ger utskriften: Model: Volvo och pris: 150000 kr
}

//TestingClassPrintouts();

static void TestingMethodPrintouts(Car aCar)
{
    RaceTrack track1 = new RaceTrack(100); // ange mållinjen
    track1.PrintFinishLine();

    RaceTrack track2 = new RaceTrack(0); // mållinjen ska bli 20
    track2.PrintFinishLine();

    aCar.SetModel("BMW iX2"); // Det är en elbil
    aCar.SetPrice(500000); // Priset var alldeles för lågt

    Console.WriteLine($"\nNy model: {aCar.GetModel()} och nytt pris: {aCar.GetPrice()} kr");
    // ger utskriften: Ny model: BMW iX2 och nytt pris: 500000 kr

    aCar.Description();
}

//TestingClassPrintouts();

Car bmw = new Car("BMW", 100000);
TestingMethodPrintouts(bmw);
