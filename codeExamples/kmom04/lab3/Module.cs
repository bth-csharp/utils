/*
 This module contains the methods you should implement.
 */


static class Module
{
    /*    
    Create a class called "Cat" in "Classes.cs". The class has 3
    private members describing eye color, name and number of lives
    left. The class has a constructor with only eye color and name.
    The default value is -1 for the static member; number of lives left.
    Create a method "GetName" that returns the cat's name.

    Create a "Cat" object with name "Missy" and brown eyes and
    return its name.
    */
    public static string GetCatName()
    {
        // TODO: Write your code here.

        return "";
    }

    /*   
    Create a method "Description" that returns a string. Example
    "My cat's _name is Luna, has blue eyes and -1 lives left to live."

    Create a "Cat" object with name "Luna" and blue eyes and return
    the result from the "Description" method on that object.
    */
    public static string GetCatDescription1()
    {
        // TODO: Write your code here.

        return "";
    }

    /*
    Add get- and set- method for the static member; number of lives left.
    
    Set the number of lives to 3 and return the number of lives.
    */
    public static int GetCatNoOfLives()
    {
        // TODO: Write your code here.

        return 0;
    }

    /*     
    Create a "Cat" object with name "Luna" and blue eyes. Set its lives
    to 9 and return the result from the "Description" method on that object.
    */
    public static string GetCatDescription2()
    {
        // TODO: Write your code here.

        return "";
    }

    /*
    Create a class called "Owner" in Classes.cs. The class has two
    private members, the owners name and a list of cats. The pets 
    can live without the owner so the pet is added with a method
    called "AddCat".

    Add 2 cats to the owner and return the owner's number of cats.
    */
    public static int GetCatNoOfCats()
    {
        // TODO: Write your code here.

        return 0;
    }

    /*
    Create a class called "Insurance" in Classes.cs. The class has two
    private members, the type of insurance and a price. The constructor
    contains only type, Full is 200 and Half is 100 kr per month.
    The insurance type is Full or Half, if any other type is used
    then Full is default.
    Create a method called "Information" that returns the a string
    in this format: "Insurance type: Half, price: 100 kr per month."
    
    Create an "Insurance" object with type Half and return its information
    using its method "Information".
    */
    public static string GetInsuranceInfo()
    {
        // TODO: Write your code here.

        return "";
    }

    /*
    Create an "Insurance" object with type Full and return its information
    using its method "Information".
    */
    public static string GetInsuranceInfoEmptyType()
    {
        // TODO: Write your code here.

        return "";
    }

    /*
    The cat owner must have an insurance for every cat.
    Add a private member to the "Owner" class called "_catInfo" that 
    have the cat's name as key and an "Insurance" object as value.

    Add a method to the "Owner" class called "GetCatInfo" that
    returns a string "No cats" if the owner has no cats.
    
    Create an "Owner" object and return the info from "GetCatInfo".
    */
    public static string GetEmptyCatInfo()
    {
        // TODO: Write your code here.

        return "";
    }

    /*
    Crete a method AddCat in the "Owner" class with 2 parameters, a "Cat"
    object and the insurance type as a string. The "Cat" object is added to
    the owner's list of cats and the insurance type is added to "_catInfo".
    
    Extend method called "GetCatInfo" in the "Owner" class that to return
    a string on the format:
    Cat 1, named Missy has Insurance type: Full, price: 200 kr per month.
    Add newline "\n" at the end of the string.
    
    Create an "Owner" object, with one cat called "Missy", with brown eyes and
    Full insurance.
    
    Return the info from "GetCatInfo".
    */
    public static string GetCatInfo()
    {
        // TODO: Write your code here.

        return "";
    }

    /*
    Create an "Owner" object, with one cat called "Missy", with brown eyes and
    Full insurance and another cat called "Luna", with blue eyes and Half insurance.
    
    Return the info from "GetCatInfo".
    */
    public static string GetCatInfo2()
    {
        // TODO: Write your code here.

        return "";
    }
}
