/*
 * This module contains the methods you should implement.
 */
static class Module
{
    /*
     * Return the string "Hello World!".
     */
    public static string Hello()
    {
        // TODO: Write your code here.
        return "";
    }

    /*
     * Get the hours and minutes from the parameter list and convert it into 
     * minutes only, 1 hour is 60 minutes.
     */
    public static int ToMinutes(int hour, int minute)
    {
        // TODO: Write your code here.
        return 0;
    }

    /*
     * Convert incoming parameters hour, minute and second to seconds.
     */
    public static int ToSeconds(int hour, int minute, int second)
    {
        // TODO: Write your code here.
        return 0;
    }

    /*
     * Return a string with the format "hh:mm:ss", pad with zeros if needed.
     */
    public static string TimeAsString(int hour, int minute, int second)
    {
        // TODO: Write your code here.
        return "0";
    }

    /*
     * Convert seconds to hour, minutes and seconds by returning a string with
     * the format "hh:mm:ss", pad with zeros if needed.
     */
    public static string SecondsToHHMMSS(int seconds)
    {
        // TODO: Write your code here.
        return "0";
    }

    /*
     * Calculate the percentage from part and total and round to num decimals.
     */
    public static double Percentage(double total, double part, int decimals)
    {
        // TODO: Write your code here.
        return 0.0;
    }

    /*
     * Calculate the area of a rectangle.
     */
    public static int RectangleArea(int width, int height)
    {
        // TODO: Write your code here.
        return 0;
    }

    /*
     * Calculate the area of a circle with five decimals.
     */
    public static double CircleArea(int radius)
    {
        // TODO: Write your code here.
        return 0.0;
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
        return "0";
    }

    /*
     * Check if the triangle is a right triangle (rätvinklig triangle) by using 
     * Pythagorean theorem a*a + b*b = c*c where c is the length of the
     * hyphotenusa. Use four decimals when comparing.
     * Return true or false.
     */
    public static bool? Pythagorean(double sideA, double sideB, double sideC)
    {
        // TODO: Write your code here.
        return null;
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
        return "0";
    }

    /*
     * Check if the incoming number is a prime number, meaning it is only
     * divisible with 1 and itself. 
     * Return true or false.
     */
    public static bool? IsPrime(int number)
    {
        return null;
    }
}
