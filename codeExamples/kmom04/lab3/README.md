# lab3: Array, List och filer

I denna laboration får du fortsätta att träna på att programmera med grunderna i programmeringsspråket CSharp med Array, List och filer.

Du kan också behöva använda manualen för att lära dig nya konstruktioner eller leta reda på inbyggda metoder och konstanter.

[[_TOC_]]

## Förutsättning

Du har jobbat igenom kmom01-03.

## Förberedelser

Gå till den katalog du vill jobba i, till exempel `kmom04`.

### Skapa ett nytt program för lab3

```bash
dotnet new console -n lab3
```

Programmet, eller projektet som det också kan kallas, skapas i katalogen `lab3` och du kan flytta ned i den katalogen.

```bash
cd lab3
```

Verifiera att du kan köra koden.

```bash
dotnet run
```

### Hämta filerna till labben

Vi skall hämta ett par filer som behövs för att utföra labben. Utför följande kommandon för att hämta labben, välj vilken terminal du jobbar i.

<details>
<summary>Hämta labben (Bash)</summary>

```bash
// Uppdatera patherna!!!
wget -O Program.cs https://raw.githubusercontent.com/dbwebb-se/webtec2/refs/heads/main/lab/lab_02/Program.cs
wget -O Module.cs https://raw.githubusercontent.com/dbwebb-se/webtec2/refs/heads/main/lab/lab_02/Module.cs
wget -O Lab.cs https://raw.githubusercontent.com/dbwebb-se/webtec2/refs/heads/main/lab/lab_02/Lab.cs
```

När du är klar kan det se ut så här.

```bash
$ tree -L 1                                              
.
├── Lab.cs
├── Module.cs
├── Program.cs
├── bin
├── lab3.csproj
├── lab3.sln
└── obj          
```

</details>

Nu kan du öppna din VS Code utifrån denna katalogen.

```bash
code .
```

Tittar runt i de filerna som finns i labben och försök förstå hur de händer ihop.

### Påbörja labben

Börja med att köra labben med `dotnet run`. Det som körs är main-programmet i `Program.cs`.

```bash
$ dotnet run
❌ Hello(), expected: "Hello World!" (String), actual: "" (String)
```

Du kan titta på filen `Program.cs` via VS Code och se vad som körs.

I filen `Module.cs` finns alla övningsuppgifter som du skall göra. Det är en metod för varje uppgift och du skall implementera koden inuti metoden så att den returnerar rätt resultat.

I modulen `Lab.cs` finns kod som verifierar att rätt saker returneras från dina metoder i `Module.cs` samt förbereder utskrifter.

### Första övningsuppgiften

I den första övningsuppgiften skall du implementera följande funktion.

```csharp
/**
 * Return the string "Hello World!".
 */
public static string Hello()
{
    // TODO: Write your code here.
    return "";
}
```

När du är klar med din implementation så kör du programmet igen och ser om du får grönt ljus som innebär att du gjort rätt.

```bash
$ dotnet run
✅ Hello(), expected: "Hello World!" (String), actual: "Hello World!" (String)
```

Klicka på "Lösningsförslag" nedan för att se hur det kan se ut när du implementerat den första metoden.

<details>
<summary>Lösningsförslag</summary>

```csharp
/**
 * Return the string "Hello World!".
 */
public static string Hello()
{
    // TODO: Write your code here.
    return "Hello World!";
}
```

</details>

### Lösning

Denna labben har en lösningsfil som du kan ladda ned och studera. Ibland finns flera olika lösningsförslag till en funktion.

Använd lösningen om du fastnar och inte lyckas ta dig vidare, eller som en studiehjälp för att jämföra dina egna lösningar med lösningar som någon annan har skrivit.

<details>
<summary>Hämta lösningsförslag (Bash)</summary>

```bash
# Stå i katalogen där du har labben
wget -O Solution.cs https://raw.githubusercontent.com/dbwebb-se/webtec2/refs/heads/main/lab/lab_02/Solution.cs
```

</details>
