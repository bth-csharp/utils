using FileApp.src;

SimpleJson shoppingList = new SimpleJson("simpleList.json");

shoppingList.Present();
bool enterProduct = true;
bool checkQuantity = true;

while (enterProduct)
{
    string? product;
    string quantity = string.Empty;

    Console.Write("\nAnge produktnamn (eller ENTER för att sluta): ");
    product = Console.ReadLine() ?? "";
    if (product == "") 
    { 
        enterProduct = false; // För att avsluta yttre loopen
    }
    else
    {
        while (checkQuantity)
        {
            Console.Write("\nAnge antal: ");
            try
            {
                quantity = Console.ReadLine() ?? "";
                shoppingList.CheckQuantity(quantity);
                checkQuantity = false; // Allt är ok, inga fler kontroller behövs
            }
            catch (QuantityException exQ)
            {
                Console.WriteLine(exQ.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        string saveInput = $"{product} {quantity}";
        shoppingList.Save(saveInput);
        // Återställ för ny kontroll av antalet
        checkQuantity = true;
    }
}

shoppingList.Present();
