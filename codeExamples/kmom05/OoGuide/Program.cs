using OoGuide.src;

RaceTrack raceTrack = new RaceTrack(100);
Weather weather = new Weather("Soligt", 18, 8);

raceTrack.AddWeather(weather);
raceTrack.RunRace();

/* Console.WriteLine("\n\nTesting subclass ElSuv");
// Skapa ett objekt av subklassen ElSuv, spara i en variabel av typen ElSuv och anropa dess metod Description
ElSuv elSuv = new ElSuv( 627, 28, true, "Ford Capri", 464000);
elSuv.Description();
Console.WriteLine($"Objektet elSuv är av typen {elSuv.GetType().Name} och dess basklass är {elSuv.GetType().BaseType}.");

// Skapa ett objekt av subklassen ElSuv, spara i en variabel av typen Suv och anropa dess metod Description
Suv suv = new ElSuv( 627, 28, true, "Ford Capri", 464000);
suv.Description();
Console.WriteLine($"Objektet suv är av typen {suv.GetType().Name} och dess basklass är {suv.GetType().BaseType}.");

// Skapa ett objekt av subklassen ElSuv, spara i en variabel av typen Car och anropa dess metod Description
Car car = new ElSuv( 627, 28, true, "Ford Capri", 464000);
car.Description();
Console.WriteLine($"Objektet car är av typen {car.GetType().Name} och dess basklass är {car.GetType().BaseType}.");

// Skapa ett objekt av subklassen Suv, spara i en variabel av typen Car och gör samma utskrift med namn och basklass
Car car2 = new Suv(true, "Ford Kuga", 299000);
Console.WriteLine($"Objektet car2 är av typen {car2.GetType().Name} och dess basklass är {car2.GetType().BaseType}.");

Console.WriteLine($"Testar ToString() på objektet car2: {car2.ToString()}.");
Console.WriteLine($"Testar Equals() på objektet car2 och car: {car2.Equals(car)}.");

Car car3 = new Car("Ford Kuga", 299000);
Console.WriteLine($"Objektet car3 är av typen {car3.GetType().Name} och dess basklass är {car3.GetType().BaseType}."); */

