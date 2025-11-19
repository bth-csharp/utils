using static Lab;
using static Module;

string[] checkCatContent = ["class Cat", "private string _", "private static int _",
"public string GetName()"];
if (Lab.CheckClassesContent(checkCatContent))
{
    string expectedStr = "Missy";
    Console.WriteLine(Lab.Assert(Module.GetCatName, [], expectedStr));
}

string[] checkCatContent2 = ["class Cat", "private string _", 
    "public static void SetLivesLeft(", "public string Description()"];
if (Lab.CheckClassesContent(checkCatContent2))
{
    string expectedStr = "My cat's name is Luna, has blue eyes and -1 lives left to live.";
    Console.WriteLine(Lab.Assert(Module.GetCatDescription1, [], expectedStr));
}

string[] checkCatContent3 = ["public static void SetLivesLeft(", "public static int GetLivesLeft()"];
if (Lab.CheckClassesContent(checkCatContent3))
{
    Console.WriteLine(Lab.Assert(Module.GetCatNoOfLives, [], 3));    
}

string expectedCatStr = "My cat's name is Luna, has blue eyes and 9 lives left to live.";
Console.WriteLine(Lab.Assert(Module.GetCatDescription2, [], expectedCatStr));

string[] checkOwnerContent = ["class Owner", "public void AddCat(Cat",
    "public int GetCatNoOfCats()"];
if (Lab.CheckClassesContent(checkOwnerContent))
{
    Console.WriteLine(Lab.Assert(Module.GetCatNoOfCats, [], 2));
}

string[] checkInsuranceContent = ["class Insurance", "public Insurance(",
    "public string Information()", "\"Insurance type:"];
if (Lab.CheckClassesContent(checkInsuranceContent))
{
    string expectedStr = "Insurance type: Half, price: 100 kr per month.";
    Console.WriteLine(Lab.Assert(Module.GetInsuranceInfo, [], expectedStr));
}

string expectedInsuranceStr = "Insurance type: Full, price: 200 kr per month.";
Console.WriteLine(Lab.Assert(Module.GetInsuranceInfoEmptyType, [], expectedInsuranceStr));

string[] checkCatInfoContent = ["Dictionary<string, Insurance> _catInfo", "public string GetCatInfo()",
    "No cats."];
if (Lab.CheckClassesContent(checkCatInfoContent))
{
    string expectedStr = "No cats.";
    Console.WriteLine(Lab.Assert(Module.GetEmptyCatInfo, [], expectedStr));
}

string expectedCatStr2 = "Cat 1, named Missy has Insurance type: Full, price: 200 kr per month.\n";
Console.WriteLine(Lab.Assert(Module.GetCatInfo, [], expectedCatStr2));

string expectedCatStr3 = "Cat 1, named Missy has Insurance type: Full, price: 200 kr per month.\n";
expectedCatStr3 += "Cat 2, named Luna has Insurance type: Half, price: 100 kr per month.\n";
Console.WriteLine(Lab.Assert(Module.GetCatInfo2, [], expectedCatStr3));

Console.WriteLine(Lab.Done());
