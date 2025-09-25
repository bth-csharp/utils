﻿using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Menu.Tests")]
// Methods
static void PrintMenu()
{
    Console.WriteLine("\nVälj mellan dessa menyalternativ:");
    Console.WriteLine("1. Info om C#");
    Console.WriteLine("2. Celsius till Fahrenheit");
    Console.WriteLine("3. Upprepa tecken");
    Console.WriteLine("4. Skapa akronym");
    Console.WriteLine("5. Summa och medel");
    Console.WriteLine("6. Validera personnummer");
    Console.WriteLine("e. Avsluta");
}

static void GetTerminalReady(string title)
{
    Console.Clear();
    Console.Title = title;
}

static string PrintInfoAboutCsharp()
{
    string info = "\nInformation om C#";
    info += "=============================";
    info += "\nC# är ett objektorienterat språk utvecklat av Microsoft.";
    info += "Det är en del av .NET plattformen, är baserat på C++ och liknar Java.";
    info += "\nC# är relativt lätt att lära sig och kan användas utan utvecklingsverktyg.";
    info += "Men prestandan är något lägre än C eller C++.";

    return info;
}

static double ReadDoubleFromTerminal(string info)
{
    double inputAsDouble;

    Console.WriteLine("\n" + info);
    string input = Console.ReadLine() ?? "1";
    try
    {
        inputAsDouble = double.Parse(input);
    }
    catch
    {
        input = input.Replace('.', ',');
        inputAsDouble = double.Parse(input);
    }
    //double inputAsDouble = double.Parse(Console.ReadLine());

    return inputAsDouble;   
}

static string ReadStringFromTerminal(string info)
{
    Console.WriteLine("\n" + info);
    
    return Console.ReadLine() ?? "1";
}

static double ConvertCelsiusToFahrenheit(double tempCelsius)
{
    double tempFahrenheit = tempCelsius * 9 / 5 + 32;

    return Math.Round(tempFahrenheit, 2);
}

static string RepeatLetters()
{
    string myStr = ReadStringFromTerminal("Skriv in en sträng: ");
    string newStr = "";

    for (int index = 0; index < myStr.Length; index++)
    {
        char letter = myStr[index];
        newStr += letter + new string(letter, index) + '-';
    }

/*     int index = 0;
    foreach (char letter in myStr)
    {
        newStr += letter + new string(letter, index) + '-';
        index++;
    } */

    return newStr.TrimEnd('-');
}

static string CreateAcronym()
{
    string input = ReadStringFromTerminal("Skriv in ett namn: ");
    string acronym = "";

    foreach (char letter in input)
    {
        if (Char.IsUpper(letter))
        {
            acronym += letter;
        }
    }

    return acronym;
}

static string CountSumAndAverage()
{
    Console.WriteLine("\nAnge en siffra ('klar' om klar): ");
    double[] result = {0, 0};
    int count = 0;

    while (true)
    {
        Console.Write("\nAnge en siffra ('klar' om klar): ");
        string userInput = Console.ReadLine() ?? "";

        if (userInput != "klar")
        {
            if (double.TryParse(userInput, out double number))
            {
                result[0] += number;
                count++;
            }
            else
            {
                Console.WriteLine("Skriv en siffra. Försök igen!");
            }
        }
        else
        {
            break;
        }
    }

    result[1] = (count > 0) ? Math.Round(result[0] / count, 2) : 0;

    return "Summan=" + result[0] + " och medelvärdet=" + result[1];
}

/* static string CountSumAndAverageException()
{
    Console.Write("\nAnge en siffra ('klar' om klar): ");
    double[] result = {0, 0};
    int count = 0;

    while (true)
    {
        Console.Write("Skriv en siffra: ");
        string userInput = Console.ReadLine() ?? "";

        if (userInput != "klar")
        {
            try
            {
                double number = double.Parse(userInput);
                result[0] += number;
                count++;
            }
            catch (FormatException)
            {
                Console.WriteLine("Skriv en siffra. Försök igen!");
                continue;
            }
        }
        else
        {
            break;
        }
    }

    result[1] = (count > 0) ? Math.Round(result[0] / count, 2) : 0;

    return "Summan=" + result[0] + " och medelvärdet=" + result[1];
} */

static bool ValidateSsn()
{
    string valid = "Not valid";
    bool result = false;
    Console.Write("\nSkriv in ett personnummer: ");
    string ssnInput = Console.ReadLine() ?? "";
    string ssn = ssnInput.Replace("-", "");
    int multiplicative = 2;
    int total = 0;
    foreach (char number in ssn)
    {
        int tmp = int.Parse(number.ToString()) * multiplicative;
        total += tmp > 9 ? 1 + (tmp - 10) : tmp;
        multiplicative = multiplicative == 2 ? 1 : 2;
    }
    if (total > 0 && total % 10 == 0)
    {
        valid = "Valid";
        result = true;
    }
    Console.WriteLine(valid);

    return result;
}

// Setup
static void Run()
{
    GetTerminalReady("MENY");
    string choice = "";

    while (choice != "e")
    {
        PrintMenu();
        Console.WriteLine("\nDitt val: ");
        choice = Console.ReadLine() ?? "";

        switch (choice) 
        {
            case "1":
                Console.WriteLine(PrintInfoAboutCsharp());
                break;
            case "2":
                double tempCelcius = ReadDoubleFromTerminal("Temperatur i Celsius? (t ex 2,212)");
                Console.WriteLine("\nTemperatur i Fahrenheit: " + ConvertCelsiusToFahrenheit(tempCelcius));
                break;
            case "3":
                Console.WriteLine("\nResultat:" + RepeatLetters());
                break;
            case "4":
                Console.WriteLine("\nAkronym: " + CreateAcronym());
                break;
            case "5":
                Console.WriteLine(CountSumAndAverage());
                //Console.WriteLine(CountSumAndAverageException());
                break;
            case "6":
                Console.WriteLine("\n" + ValidateSsn());
                break;
            case "e":
                Console.WriteLine("\nDu har valt att avsluta! Hej då!");
                break;
            default:
                Console.WriteLine("Ogiltligt menyval");
                break;
        }
    }   
}

// Run program
Run();

