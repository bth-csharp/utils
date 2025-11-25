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

List<string> expectedNames = ["Betty", "Marie", "Andreas", "Mikael"];
Console.WriteLine(Lab.Assert(Module.GetList, [], expectedNames));

List<string> expectedNamesSorted = ["Mikael", "Marie", "Betty", "Andreas"];
Console.WriteLine(Lab.Assert(Module.SortList, [expectedNames], expectedNamesSorted));

string[] expectedCars = ["Volvo", "Peugeot", "Skoda", "Toyota"];
Console.WriteLine(Lab.Assert(Module.GetCars, [], expectedCars));

string[] correctFruitsInFile = ["apple", "orange", "banana"];
Console.WriteLine(Lab.Assert(Module.CreateFruitsFile, [], correctFruitsInFile, new object()));

string[] correctCars = ["Volvo", "Peugeot", "Skoda", "Toyota", "Ferrari"];
Console.WriteLine(Lab.Assert(Module.AppendToCarsFile, [], correctCars, new object()));
Lab.ResetCarsFile();
Console.WriteLine(Lab.Assert(Module.GetWordsInInfo, [], 269));

Console.WriteLine(Lab.Assert(Module.GetWordOccuranceInInfo, [], 11));

Console.WriteLine(Lab.Done());
