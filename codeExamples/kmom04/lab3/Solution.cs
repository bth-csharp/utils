/*
 * This module contains the methods you should implement.
 */

static class Solution
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
        Cat cat = new Cat("Missy", "brown");

        return cat.GetName();
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
        Cat cat = new Cat("Luna", "blue");

        return cat.Description();
    }

    /*
    Add get- and set- method for the static member; number of lives left.
    
    Set the number of lives to 3 and return the number of lives.
    */
    public static int GetCatNoOfLives()
    {
        // TODO: Write your code here.
        Cat.SetLivesLeft(3);

        return Cat.GetLivesLeft();
    }

    /*     
    Create a "Cat" object with name "Luna" and blue eyes. Set its lives
    to 9 and return the result from the "Description" method on that object.
    */
    public static string GetCatDescription2()
    {
        // TODO: Write your code here.
        Cat cat = new Cat("Luna", "blue");
        Cat.SetLivesLeft(9);

        return cat.Description();
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
        Cat cat1 = new Cat("Luna","blue");
        Cat cat2 = new Cat("Missy", "brown");
        Owner owner = new Owner("Marie");

        owner.AddCat(cat1);
        owner.AddCat(cat2);

        return owner.GetCatNoOfCats();
    }

    /*
    Create a class called "Insurance" in Classes.cs. The class has two
    private members, the type of insurance and a price. The constructor
    has only type as parameter, Full is 200 and Half is 100 kr per month.
    The insurance type is Full or Half, if any other type is used
    then Full is the default value.
    Create a method called "Information" that returns the a string
    in this format: "Insurance type: Half, price: 100 kr per month."
    
    Create an "Insurance" object with type Half and return its information
    using its method "Information".
    */
    public static string GetInsuranceInfo()
    {
        // TODO: Write your code here.
        Insurance insurance = new Insurance("Half");

        return insurance.Information();
    }

    /*
    Create an "Insurance" object with type Full and return its information
    using its method "Information".
    */
    public static string GetInsuranceInfoEmptyType()
    {
        // TODO: Write your code here.
        Insurance insurance = new Insurance("Full");

        return insurance.Information();
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
        Owner owner = new Owner("Betty");

        return owner.GetCatInfo();
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
        Owner owner = new Owner("Betty");
        Cat cat = new Cat("Missy", "brown");

        owner.AddCat(cat, "Full");

        return owner.GetCatInfo();
    }

    /*
    Create an "Owner" object, with one cat called "Missy", with brown eyes and
    Full insurance and another cat called "Luna", with blue eyes and Half insurance.
    
    Return the info from "GetCatInfo".
    */
    public static string GetCatInfo2()
    {
        // TODO: Write your code here.
        Owner owner = new Owner("Betty");
        Cat cat1 = new Cat("Missy", "brown");
        Cat cat2 = new Cat("Luna", "blue");

        owner.AddCat(cat1, "Full");
        owner.AddCat(cat2, "Half");

        return owner.GetCatInfo();
    }

    /*
    Create a class "CatHelper" with 2 private variables; a list of Cat objects 
    and the name of the cat helper. Implement the method "public int AddCat(Cat newCat)"
    that adds a Cat object to the cat helpers list of cats and returns the number
    of cats. Implement the method "public int RemoveCat(Cat oldCat)" that removes
    the Cat object "oldCat" from the list of cats and returns the number of cats.

    Create a class "CatShelter" with 2 private variables; a list of Cat objects 
    and the name of the cat shelter. Implement:
    public int GetCatNoOfCats()
    public void MoveCatToCatHelper(Cat aCat, CatHelper helper) - takes a cat "aCat" from
    the shelter and puts it into the care of cat helper "helper".
    public void ReturnCatToShelter(Cat aCat, CatHelper helper) - takes a cat "aCat"
    from the cat helper "helper" and puts it into the care of the shelter.
    Create a default parameter for helper for cats that is admitted without any helper.

    Create 2 Cat objects and put into CatShelter, the cats come from no one.
    Create 1 CatHelper object and give the cat helper one of the cats to take care
    of.
    
    Return the number of cats in the shelter.
    */
    public static int GetTheNumberOfCatsInShelter()
    {
        Cat cat1 = new Cat("Missy", "brown");
        Cat cat2 = new Cat("Luna", "blue");
        CatShelter aShelter = new CatShelter("dbwebb cat home");
        CatHelper helper = new CatHelper("Andreas");

        aShelter.ReturnCatToShelter(cat1);
        aShelter.ReturnCatToShelter(cat2);

        aShelter.MoveCatToCatHelper(cat1, helper);

        return aShelter.GetCatNoOfCats();
    }


    /*
    Create 2 Cat objects and put one into CatShelter and the other one to the
    cat helper.
    Create 1 CatShelter and put one cat there. The cat is found on the street.
    Create 1 CatHelper object and give the cat helper one of the cats to take care
    of.

    Return the number of cats at the cat helper.
    */
    public static int GetTheNumberOfCatsAtCarHelper()
    {
        Cat cat1 = new Cat("Missy", "brown");
        Cat cat2 = new Cat("Luna", "blue");
        CatShelter aShelter = new CatShelter("dbwebb cat home");
        CatHelper helper = new CatHelper("Andreas");

        aShelter.ReturnCatToShelter(cat1);

        return helper.AddCat(cat2);
    }

    /*
    Create 2 Cat objects and put into CatShelter.
    Create 1 CatHelper object and give the cat helper both the cats to take care
    of.
    One of the cats is to hard for the cat helper so it will be return to the 
    shelter.

    Return the number of cats in the shelter.
    */
    public static int GetTheNumberOfCatsInShelter2()
    {
        Cat cat1 = new Cat("Missy", "brown");
        Cat cat2 = new Cat("Luna", "blue");
        CatShelter aShelter = new CatShelter("dbwebb cat home");
        CatHelper helper = new CatHelper("Andreas");

        aShelter.ReturnCatToShelter(cat1);
        aShelter.ReturnCatToShelter(cat2);

        aShelter.MoveCatToCatHelper(cat1, helper);
        aShelter.MoveCatToCatHelper(cat2, helper);

        aShelter.ReturnCatToShelter(cat1, helper);

        return aShelter.GetCatNoOfCats();
    }

    /*
    Create 2 Cat objects.
    Create 1 CatHelper object and give the cat helper both the cats to take care
    of.
    One of the cats is to hard for the cat helper but the neighbour wants that cat.
    Just remove that Cat object from the cat helper.

    Return the number of cats at the cat helper.
    */
    public static int GetTheNumberOfCatsAtCarHelper2()
    {
        Cat cat1 = new Cat("Missy", "brown");
        Cat cat2 = new Cat("Luna", "blue");
        CatHelper helper = new CatHelper("Andreas");
        int noOfCats = 0;

        noOfCats = helper.AddCat(cat1);
        noOfCats = helper.AddCat(cat2);

        // Too much work with 2 cats
        noOfCats = helper.RemoveCat(cat1);

        return noOfCats;
    }
}
