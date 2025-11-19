using static Lab;
using static Module;

Console.WriteLine(Lab.Assert(Module.Hello, [], "Hello World!"));

Console.WriteLine(Lab.Assert(Module.ToMinutes, [0, 0], 0));
Console.WriteLine(Lab.Assert(Module.ToMinutes, [2, 2], 122));
Console.WriteLine(Lab.Assert(Module.ToMinutes, [4, 61], 301));

Console.WriteLine(Lab.Assert(Module.ToSeconds, [0, 0, 0], 0));
Console.WriteLine(Lab.Assert(Module.ToSeconds, [12, 12, 12], 43932));
Console.WriteLine(Lab.Assert(Module.ToSeconds, [23, 59, 59], 86399));

Console.WriteLine(Lab.Assert(Module.TimeAsString, [0, 0, 0], "00:00:00"));
Console.WriteLine(Lab.Assert(Module.TimeAsString, [12, 12, 12], "12:12:12"));
Console.WriteLine(Lab.Assert(Module.TimeAsString, [23, 59, 59], "23:59:59"));

Console.WriteLine(Lab.Assert(Module.SecondsToHHMMSS, [0], "00:00:00"));
Console.WriteLine(Lab.Assert(Module.SecondsToHHMMSS, [12 * 60 * 60 + 12 * 60 + 12], "12:12:12"));
Console.WriteLine(Lab.Assert(Module.SecondsToHHMMSS, [23 * 60 * 60 + 60 * 60 - 1], "23:59:59"));

Console.WriteLine(Lab.Assert(Module.Percentage, [100.0, 50.11, 2], 50.11));
Console.WriteLine(Lab.Assert(Module.Percentage, [3.0, 2.0, 2], 66.67));
Console.WriteLine(Lab.Assert(Module.Percentage, [9.0, 8.0, 4], 88.8889));

Console.WriteLine(Lab.Assert(Module.RectangleArea, [0, 0], 0));
Console.WriteLine(Lab.Assert(Module.RectangleArea, [2, 2], 4));
Console.WriteLine(Lab.Assert(Module.RectangleArea, [3, 4], 12));

Console.WriteLine(Lab.Assert(Module.CircleArea, [1], 3.14159));
Console.WriteLine(Lab.Assert(Module.CircleArea, [2], 12.56637));
Console.WriteLine(Lab.Assert(Module.CircleArea, [3], 28.27433));

Console.WriteLine(Lab.Assert(Module.TriangleType, [1, 1, 1], "equil", 2));
Console.WriteLine(Lab.Assert(Module.TriangleType, [1, 1, 2], "isosc"));
Console.WriteLine(Lab.Assert(Module.TriangleType, [1, 2, 1], "isosc"));
Console.WriteLine(Lab.Assert(Module.TriangleType, [2, 1, 1], "isosc"));
Console.WriteLine(Lab.Assert(Module.TriangleType, [1, 2, 3], "different"));

Console.WriteLine(Lab.Assert(Module.Pythagorean, [1, 1, Math.Sqrt(2)], true, 2));
Console.WriteLine(Lab.Assert(Module.Pythagorean, [1, 2, Math.Sqrt(5)], true));
Console.WriteLine(Lab.Assert(Module.Pythagorean, [3, 9, 3.0 * Math.Sqrt(10)], true));
Console.WriteLine(Lab.Assert(Module.Pythagorean, [1, 1, 1], false));

Console.WriteLine(Lab.Assert(Module.FizzBuzz, [1, 1], "1", 3));
Console.WriteLine(Lab.Assert(Module.FizzBuzz, [1, 3], "1 2 Fizz"));
Console.WriteLine(Lab.Assert(Module.FizzBuzz, [2, 9], "2 Fizz 4 Buzz Fizz 7 8 Fizz"));
Console.WriteLine(Lab.Assert(Module.FizzBuzz, [11, 20], "11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz"));

Console.WriteLine(Lab.Assert(Module.IsPrime, [1], true, 3));
Console.WriteLine(Lab.Assert(Module.IsPrime, [2], true));
Console.WriteLine(Lab.Assert(Module.IsPrime, [5], true));
Console.WriteLine(Lab.Assert(Module.IsPrime, [10], false));
Console.WriteLine(Lab.Assert(Module.IsPrime, [13], true));
Console.WriteLine(Lab.Assert(Module.IsPrime, [47], true));
Console.WriteLine(Lab.Assert(Module.IsPrime, [99], false));

Console.WriteLine(Lab.Done());
