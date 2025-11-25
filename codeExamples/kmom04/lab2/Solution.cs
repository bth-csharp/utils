/*
 * This module contains the methods you should implement.
 */
static class Solution
{
    /*
     * Return Array with strings from this string "Betty Marie Andreas Mikael".
     */
    public static string[] GetArray()
    {
        // TODO: Write your code here.
        string input = "Betty Marie Andreas Mikael";
        string[] strings = input.Split(' ');

        return strings;
    }

    /*
     * Return the size of the array
     */
    public static int GetArraySize()
    {
        string[] fruits = ["apple", "orange", "banana"];
        // TODO: Write your code here.

        return fruits.Length;
    }

    /*
     * Change orange to lemon, and add kiwi
     * Return a array with strings
     */
    public static string[] ManipulateArray()
    {
        string[] fruits = ["apple", "orange", "banana"];
        string[] newFruits = new string[fruits.Length + 1];

        // TODO: Write your code here.
        fruits[1] = "lemon";
        for (int i = 0; i < fruits.Length; i++)
        {
            newFruits[i] = fruits[i];
        }
        newFruits[fruits.Length] = "kiwi";

        return newFruits;
    }

    /*
     * Use error handling when trying to get the fruit at index 4
     * Return a string with the error message
     */
    public static string GetErrorFromArray()
    {
        string[] fruit = ["apple", "orange", "banana"];
        string errorType = string.Empty;

        // TODO: Write your code here.
        try
        {
            var notAFruit = fruit[4];
        }
        catch (Exception ex)
        {
            errorType = ex.Message;
        }

        return errorType;
    }

    /*
    * return the list sorted in ascending order
    */
    public static string[] SortArray()
    {
        string[] fruits = ["apple", "orange", "banana"];

        // TODO: Write your code here.
        Array.Sort(fruits);

        return fruits;
    }

    /*
    * Create a list with strings from this string "Betty Marie Andreas Mikael".
    * Return the size of the list
    */
    public static int GetListSize()
    {
        // TODO: Write your code here.
        string input = "Betty Marie Andreas Mikael";
        List<string> strings = new List<string>(input.Split(' '));

        return strings.Count;
    }

    /*
     * Return list with strings from this string "Betty Marie Andreas Mikael".
     */
    public static List<string> GetList()
    {
        // TODO: Write your code here.
        string input = "Betty Marie Andreas Mikael";
        List<string> strings = new List<string>(input.Split(' '));

        return strings;
    }

    /*
     * Return input sorted in descending order.
     */
    public static List<string> SortList(List<string> input)
    {
        // TODO: Write your code here.
        input.Sort();
        input.Reverse();

        return input;
    }

    /*
     * Read the content of the file, cars.txt. 
     * If anything goes wrong when reading the file an empty array is returned.
     * Return the content as an Array of strings.
     */
    public static string[] GetCars()
    {
        string filename = "cars.txt";

        // TODO: Write your code here.
        try
        {
            // Testa om filen finns
            if (File.Exists(filename))
            {
                return File.ReadAllLines(filename);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong, error: {ex.Message}");
        }

        return [];
    }

    /*
     * Create a new file, fruits.txt. Return "ok" if everything goes ok.
     * If anything goes wrong when reading the file return the error message.
     * Return the message.
     */
    public static void CreateFruitsFile()
    {
        string filename = "fruits.txt";
        string[] fruits = ["apple", "orange", "banana"];

        // TODO: Write your code here.
        try
        {
            File.WriteAllLines(filename, fruits);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong, error: {ex.Message}");
        }
    }

    /*
     * Append a car brand Ferrari to the file, cars.txt. 
     * Return nothing.
     */
    public static void AppendToCarsFile()
    {
        string filename = "cars.txt";

        // TODO: Write your code here.
        try
        {
            File.AppendAllLines(filename, ["Ferrari"]);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong, error: {ex.Message}");
        }
    }

    /*
    * Read the content of the file, info.txt. 
    * Count the number of words in the file and return that number.
    * Return the number of words as an int.
    */
    public static int GetWordsInInfo()
    {
        string filename = "info.txt";
        int wordCount = 0;

        // TODO: Write your code here.
        try
        {
            // Testa om filen finns
            if (File.Exists(filename))
            {
                string content = File.ReadAllText(filename);
                char[] separators = { ' ', '\n', '\r', '\t' };
                string[] words = content.Split(separators);

                foreach (string word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        wordCount++;
                    }
                }

            }
            else
            {
                Console.WriteLine("Filen hittades inte.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong, error: {ex.Message}");
        }

        return wordCount;
    }

    /*
    * Read the content of the file, info.txt. 
    * Count the number of time C# is in the file and return that number.
    * Return the number of occurances of C# as an int.
    */
    public static int GetWordOccuranceInInfo()
    {
        string filename = "info.txt";
        int csharpCount = 0;

        // TODO: Write your code here.
        try
        {
            // Testa om filen finns
            if (File.Exists(filename))
            {
                string content = File.ReadAllText(filename).ToLower();
                char[] separators = { ' ', '\n', '\r', '\t' };
                string[] words = content.Split(separators);

                foreach (string word in words)
                {
                    if (word == "c#")
                    {
                        csharpCount++;
                    }
                }

            }
            else
            {
                Console.WriteLine("Filen hittades inte.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong, error: {ex.Message}");
        }

        return csharpCount;
    }
}
