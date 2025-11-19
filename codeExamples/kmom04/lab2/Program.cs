using static Lab;
using static Module;

string[] expectedArray = ["Betty", "Marie", "Andreas", "Mikael"];
Console.WriteLine(Lab.Assert(Module.GetArray, [], expectedArray));

Console.WriteLine(Lab.Assert(Module.GetArraySize, [], 3));

string[] expectedFruits = ["apple", "lemon", "banana", "kiwi"];
Console.WriteLine(Lab.Assert(Module.ManipulateArray, [], expectedFruits));

string expectedError = "Index was outside the bounds of the array.";
Console.WriteLine(Lab.Assert(Module.GetErrorFromArray, [], expectedError));

string[] sortedFruits = ["apple", "banana", "orange"];
Console.WriteLine(Lab.Assert(Module.SortArray, [], sortedFruits));

Console.WriteLine(Lab.Assert(Module.GetListSize, [], 4));

List<string> expectedNames = new List<string> {"Betty", "Marie", "Andreas", "Mikael"};
Console.WriteLine(Lab.Assert(Module.GetList, [], expectedNames));

List<string> expectedNamesSorted = new List<string> {"Mikael", "Marie", "Betty", "Andreas"};
Console.WriteLine(Lab.Assert(Module.SortList, [expectedNames], expectedNamesSorted));

string[] expectedCars = ["Volvo", "Peugeot", "Skoda", "Toyota"];
Console.WriteLine(Lab.Assert(Module.GetCars, [], expectedCars));

string[] checkedFruits = Lab.ReadFile("fruits.txt");
Console.WriteLine(Lab.Assert(Module.CreateFruitsFile, [], new object(), checkedFruits));

string[] correctCars = ["Volvo", "Peugeot", "Skoda", "Toyota", "Ferrari"];
Console.WriteLine(Lab.Assert(Module.AppendToCarsFile, [], new object(), correctCars));
Lab.ResetCarsFile();

Console.WriteLine(Lab.Assert(Module.GetWordsInInfo, [], 269));

Console.WriteLine(Lab.Assert(Module.GetWordOccuranceInInfo, [], 11));

Console.WriteLine(Lab.Done());
