/*
 * This module contains lab specific code to assert the functions of the lab 
 * and to calculate the result.
 */

using System.Collections.Generic;
using System.Linq;


static class Lab
{
    /*
     * Define the two levels to PASS or PASS WITH HONOUR.
     */
    private static readonly int _pass = 10;
    private static readonly int _passWithHonour = 12;

    /*
     * Store the total number of points, when calculated.
     */
    private static int TOTAL;

    /*
     * Return a string with motivational feedback.
     * @returns {string} A string with a message.
     */
    static public string Feedback(int points)
    {
        string msg = "Try to earn 1 point to get started... 😏";
        if (points == 1)
        {
            msg = "Nice work, lets go, do another! 😉";
        }
        else if (points == _pass - 1)
        {
            msg = "Just one more to PASS. Lets go. 😅";
        }
        else if (points == _pass)
        {
            msg = "Excellent, you have PASSED. Lets try one more? 😁";
        }
        else if (points == _passWithHonour)
        {
            msg = "That is the way, you PASSED WITH HONOUR! 😍";
        }
        else if (points == _passWithHonour)
        {
            msg = "That is the way, you PASSED WITH HONOUR! 😍";
        }
        else if (points == TOTAL)
        {
            msg = "What can I say. You impress me. 🙌";
        }
        else if (points > 1 && points < 6)
        {
            msg = "Great, you are on fire and progress is made. 😋";
        }
        return msg;
    }



    /*
     * Class to hold statistics summary for each method.
     */
    class Statistic
    {
        public int run = 0;
        public int passed = 0;
        public int failed = 0;
        public int points;

        public Statistic(int aPoint)
        {
            points = aPoint;
        }

        public void Run(bool success)
        {
            run++;
            if (success)
            {
                passed++;
            }
            else
            {
                failed++;
            }
        }
    }

    /*
     * Dictionary to hold statistics of each method call.
     */
    static Dictionary<string, Statistic> stats = new Dictionary<string, Statistic>();

    /*
    * Execute the testcase and assert that it was corrent or not and return a
    * status string the can be written out.
    * @param {Function} func - The function to test.
    * @param {Object} args - The arguments to send to the function.
    * @param {Object} expected - The expected result from the function call.
    * @param {number} point - The number of points that this functions is worth in total.
    * @returns {string} A string representation of the test case success or failure.
    */
    static public string Assert(
        Delegate method,
        object[] args,
        object expected,
        object? voidOutput = null,
        int point = 1
    )
    {
        // Call the method with the arguments
        string methodName = method.Method.Name;
        object? result = method.DynamicInvoke(args);
        if (result == null)
        {
            result = voidOutput;
            expected = ReadFile(methodName);
        }
        bool success = false;

        // Verify that returned result matches the expected
        if (expected == null && result == null)
        {
            success = true;
        }
        else if (expected is not null && result is not null && expected.GetType() == result.GetType())
        {
            if (expected.GetType() == typeof(string) && (string)expected == (string)result)
            {
                success = true;
            }
            else if (expected.GetType() == typeof(int) && (int)expected == (int)result)
            {
                success = true;
            }
            else if (expected.GetType() == typeof(double) && (double)expected == (double)result)
            {
                success = true;
            }
            else if (expected.GetType() == typeof(bool) && (bool)expected == (bool)result)
            {
                success = true;
            }
            else if (expected.GetType() == typeof(List<string>))
            {
                List<string> expectedList = (List<string>)expected;
                List<string> resultList = (List<string>)result;
                success = expectedList.SequenceEqual(resultList);
            }
            else if (expected.GetType() == typeof(string[]))
            {
                string[] expectedArray = (string[])expected;
                string[] resultArray = (string[])result;
                success = expectedArray.SequenceEqual(resultArray);
            }
        }

        // Calculate the stats
        if (stats.ContainsKey(methodName) == false)
        {
            stats.Add(methodName, new Statistic(point));
        }
        stats[methodName].Run(success);

        // Prepare the argument string
        string successStr = success ? "✅" : "❌";
        string argStr = ArgsAsString(args);
        string expectedStr = expected is not null ? ArgsAsString([expected]) : "";
        string resultStr = result is not null ? ArgsAsString([result]) : "";
        string expectedType = ReturnTypeOfObject(expected!);
        string resultType = ReturnTypeOfObject(result!);

        return $"{successStr} {methodName}({argStr}), expected: {expectedStr} ({expectedType}), actual: {resultStr} ({resultType})";
    }

    private static string ReturnTypeOfObject(Object objectToCheck)
    {
        string resultType;

        if (objectToCheck is not null && objectToCheck.GetType() == typeof(List<string>))
        {
            resultType = "List<string>";
        }
        else
        {
            resultType = objectToCheck is not null ? objectToCheck.GetType().ToString().Substring(7) : "";
        }

        return resultType;
    }


    /*
    * Format a value to its string representation.
    * @param {Object} args - A value to parse and format as a string.
    * @returns {string} A string representation of the value.
    */
    static string ArgsAsString(object[] args)
    {
        string argStr = "";
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].GetType() == typeof(string))
            {
                argStr += $"\"{args[i]}\", ";
            }
            else if (args[i].GetType() == typeof(string[]))
            {
                argStr += "[ \"" + String.Join("\", \"", (string[])args[i]) + "\" ]";

                return argStr;
            }
            else if (args[i].GetType() == typeof(List<string>))
            {
                argStr += "{ \"" + String.Join("\", \"", (List<string>)args[i]) + "\" }";

                return argStr;
            }
            else
            {
                argStr += $"{args[i]}, ";
            }
        }

        return argStr.Length > 2
            ? argStr = argStr[..^2]
            : argStr
        ;
    }



    /*
    * Print out the results when the execution is done.
    * @returns {string} A string representation of the results.
    */
    static public string Done()
    {
        int points = 0;
        int passed = 0;
        int failed = 0;
        int total = 0;
        int result = 0;
        string str = "";

        foreach (KeyValuePair<string, Statistic> method in stats)
        {
            points += method.Value.points;
            passed += method.Value.passed;
            failed += method.Value.failed;
            total += method.Value.passed + method.Value.failed;
            result += method.Value.points * (int)Math.Floor((decimal)method.Value.passed / (method.Value.passed + method.Value.failed));
        }
        TOTAL = points;

        str += $"Status of test cases: Passed: {passed}, Failed: {failed}, Total: {total}";
        str += $"\nYou need {_pass} points to PASS and {_passWithHonour} points to PASS WITH HONOUR.";
        str += $"\nYou have {result} points out of total {points} points.";
        str += $"\n{Feedback(result)}";
        return str;
    }

    public static string[] ReadFile(string methodName)
    {
        string fileName = "cars.txt";
        if (methodName.ToLower().Contains("fruits")) { fileName = "fruits.txt"; }
        try
        {
            // Testa om filen finns
            if (File.Exists(fileName))
            {
                return File.ReadAllLines(fileName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong, error: {ex.Message}");
        }

        return [];
    }

    public static void ResetCarsFile()
    {
        string[] cars = [ "Volvo", "Peugeot", "Skoda", "Toyota" ];

        // TODO: Write your code here.
        try
        {
            File.WriteAllLines("cars.txt", cars);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong, error: {ex.Message}");
        }

    }
}
