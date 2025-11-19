/*
 * This module contains the methods you should implement.
 */
static class Solution
{
    /*
     * Return the string "Hello World!".
     */
    public static string Hello()
    {
        // TODO: Write your code here.
        return "Hello World!";
    }

    /*
     * Get the hours and minutes from the parameter list and convert it into 
     * minutes only, 1 hour is 60 minutes.
     */
    public static int ToMinutes(int hour, int minute)
    {
        // TODO: Write your code here.
        return hour * 60 + minute;
    }

    /*
     * Convert incoming parameters hour, minute and second to seconds.
     */
    public static int ToSeconds(int hour, int minute, int second)
    {
        // TODO: Write your code here.
        return hour * 60 * 60 + minute * 60 + second;
    }

    /*
     * Return a string with the format "hh:mm:ss", pad with zeros if needed.
     */
    public static string TimeAsString(int hour, int minute, int second)
    {
        // TODO: Write your code here.
        return $"{hour:D2}:{minute:D2}:{second:D2}";
    }

    /*
     * Convert seconds to hour, minutes and seconds by returning a string with
     * the format "hh:mm:ss", pad with zeros if needed.
     */
    public static string SecondsToHHMMSS(int seconds)
    {
        // TODO: Write your code here.
        int hour = (int)seconds / 60 / 60;
        int minute = (int)(seconds - hour * 60 * 60) / 60;
        int second = seconds - hour * 60 * 60 - minute * 60;

        return TimeAsString(hour, minute, second);
        //return $"{hour:D2}:{minute:D2}:{second:D2}";
    }

    /*
     * Calculate the percentage from part and total and round to num decimals.
     */
    public static double Percentage(double total, double part, int decimals)
    {
        // TODO: Write your code here.
        return Math.Round(part / total * 100, decimals);
    }

    /*
     * Calculate the area of a rectangle.
     */
    public static int RectangleArea(int width, int height)
    {
        // TODO: Write your code here.
        return width * height;
    }

    /*
     * Calculate the area of a circle with five decimals.
     */
    public static double CircleArea(int radius)
    {
        // TODO: Write your code here.
        return Math.Round(Math.PI * radius * radius, 5);
    }

    /*
     * Get the length of the sides of the triangle and check if the triangle is:
     * Equilateral: All sides are the same length.
     * Isosceles: Two sides are the same length.
     * Different sided: All sides are different lengths.
     * Return "equil", "isosc" or "different".
     */
    public static string TriangleType(int sideA, int sideB, int sideC)
    {
        // TODO: Write your code here.
        string type = "different";
        if (sideA == sideB && sideA == sideC && sideB == sideC)
        {
            type = "equil";
        }
        else if (sideA == sideB || sideA == sideC || sideB == sideC)
        {
            type = "isosc";
        }
        return type;
    }

    /*
     * Check if the triangle is a right triangle (rätvinklig triangle) by using 
     * Pythagorean theorem a*a + b*b = c*c where c is the length of the
     * hypotenusa. Use four decimals when comparing.
     * Return true or false.
     */
    public static bool Pythagorean(double sideA, double sideB, double sideC)
    {
        // TODO: Write your code here.
        double partA = Math.Round(sideA * sideA + sideB * sideB, 4);
        double partB = Math.Round(sideC * sideC, 4);
        //Console.WriteLine($"{partA} == {partB}");

        return partA == partB;
    }

    /*
     * Loop from start to end and return a string with the following conditions:
     * "Fizz" if the number is divisible by 3.
     * "Buzz" if the number is divisible by 5.
     * "FizzBuzz" if the number is divisible by both 3 and 5.
     * Otherwise, the number itself must be added to the string.
     * Add a space between each value.
     */
    public static string FizzBuzz(int start, int end)
    {
        // TODO: Write your code here.
        string res = "";
        for (int i = start; i <= end; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                res += "FizzBuzz";
            }
            else if (i % 3 == 0)
            {
                res += "Fizz";
            }
            else if (i % 5 == 0)
            {
                res += "Buzz";
            }
            else
            {
                res += $"{i}";
            }

            if (i < end)
            {
                res += " ";
            }
        }

        return res;
    }

    /*
     * Check if the incoming number is a prime number, meaning it is only
     * divisible with 1 and itself. 
     * Return true or false.
     */
    public static bool IsPrime(int number)
    {
        // TODO: Write your code here.
        bool success = true;

        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                success = false;
                break;
            }
        }

        return success;
    }
}
