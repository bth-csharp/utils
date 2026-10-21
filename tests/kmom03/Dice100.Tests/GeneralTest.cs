using System.Text.RegularExpressions;

namespace Dice100.Tests;

public class GeneralTest
{
    private string _targetDir;

    [SetUp]
    public void Setup()
    {
        var testDir = TestContext.CurrentContext.TestDirectory;
        var rootDir = Path.GetFullPath(Path.Combine(testDir, "..", "..", "..", ".."));
        this._targetDir = Path.Combine(rootDir, "Dice100") ?? "";
    }

    [Test]
    public void RequiredFiles()
    {
        Assert.That(Directory.Exists(_targetDir), Is.True, $"Katalogen saknas: {_targetDir}");

        var requiredFiles = new[]
        {
            "Program.cs",
            "toplist.txt",
            "src/Die.cs",
            "src/FileHandler.cs",
            "src/Game.cs",
            "src/Menu.cs",
            "src/NumberOfPlayersException.cs",
            "src/DiceHand.cs",
            "src/Player.cs"
        };

        foreach (var file in requiredFiles)
        {
            var fullPath = Path.Combine(_targetDir, file);
            Assert.That(File.Exists(fullPath), Is.True, $"Filen saknas: {file}");
        }
        TestContext.Out.WriteLine("✅ Alla filer för kmom03 finns");
    }

    [Test]
    public void TextFileContainingAtLeastThreeStrings()
    {
        var filePath = Path.Combine(this._targetDir, "toplist.txt");

        Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {filePath}");

        var lines = File.ReadAllLines(filePath);
        var nonEmptyLines = lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();

        Assert.That(nonEmptyLines, Has.Count.GreaterThanOrEqualTo(3),
            $"Filen måste innehålla minst 3 strängar, hittade {nonEmptyLines.Count}.");
        TestContext.Out.WriteLine("✅ Filen toplist.txt innehåller minst 3 rader");
    }


    [Test]
    public void FileContainingNumberOfPlayersException()
    {
        var filePath = Path.Combine(this._targetDir, "src/NumberOfPlayersException.cs");

        Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {filePath}");

        var content = File.ReadAllText(filePath) ?? "";

        Assert.Multiple(() =>
        {
            Assert.That(content, Does.Contain("public class NumberOfPlayersException : Exception"),
                    $"Filen måste innehålla klassen 'NumberOfPlayersException'.");
            Assert.That(content, Does.Contain("public NumberOfPlayersException("),
                $"Filen måste innehålla metoden 'NumberOfPlayersException'.");
        });

        TestContext.Out.WriteLine("✅ NumberOfPlayersException är deklarerad ok");
    }

    [Test]
    public void RequiredClassDiagram()
    {
        Assert.That(Directory.Exists(_targetDir), Is.True, $"Katalogen saknas: {_targetDir}");

        var fullPath1 = Path.Combine(_targetDir, "..", "classdiagram.pdf");
        var fullPath2 = Path.Combine(_targetDir, "..", "classdiagram.png");

        bool exists = File.Exists(fullPath1) || File.Exists(fullPath2);

        Assert.That(exists, Is.True, "Klassdiagram saknas! Har du rätt filnamn?");
        Assert.That(
            (File.Exists(fullPath1) && !string.IsNullOrWhiteSpace(File.ReadAllText(fullPath1))) ||
            (File.Exists(fullPath2) && !string.IsNullOrWhiteSpace(File.ReadAllText(fullPath2))),
            Is.True, "Aj då, tom fil.");

        TestContext.Out.WriteLine("✅ Klassdiagram finns");
    }

    [Test]
    public void FilesNotContainingIO()
    {
        Assert.That(Directory.Exists(_targetDir), Is.True, $"Katalogen saknas: {_targetDir}");

        var requiredFiles = new[]
        {
            "src/Die.cs",
            "src/NumberOfPlayersException.cs",
            "src/DiceHand.cs",
            "src/AsciiArt.cs",
            "src/Game.cs",
            "src/Player.cs"
        };

        foreach (var file in requiredFiles)
        {
            var filePath = Path.Combine(_targetDir, file);
            Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {file}");
            var content = File.ReadAllText(filePath) ?? "";
            bool hasForbiddenWords = content.Contains("Console.Write") || content.Contains("Console.Read");
            Assert.That(hasForbiddenWords, Is.False,
            $"Filen {file} får INTE innehålla in- och utmatning.");
        }
        TestContext.Out.WriteLine("✅ Bara Menu och AsciArt innehåller I/O");
    }

    [Test]
    public void CheckIfProgramIsOk()
    {
        var filePath = Path.Combine(this._targetDir, "Program.cs");

        Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {filePath}");

        var content = File.ReadAllText(filePath) ?? "";
        
        var nonEmptyLines = content
            .Split(Environment.NewLine)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToList();


        Assert.Multiple(() =>
        {
            Assert.That(content, Does.Contain("Player"), $"Ett meny objekt ska skapas");
            Assert.That(content, Does.Contain("Game game = "), $"Ett meny objekt ska skapas");
            Assert.That(content, Does.Contain("game.Run()"), $"Spelet ska startas");
            Assert.That(nonEmptyLines, Has.Count.GreaterThanOrEqualTo(4),
                $"Filen måste innehålla minst 4 strängar, hittade {nonEmptyLines.Count}.");
            Assert.That(nonEmptyLines, Has.Count.LessThanOrEqualTo(8),
                $"Filen måste innehålla max 8 strängar, hittade {nonEmptyLines.Count}.");
        });

        TestContext.Out.WriteLine("✅ Ett objekt av klassen Menu skapas och menyn körs igång");
    }

    [Test]
    public void DieContainingThis()
    {
        var filePath = Path.Combine(this._targetDir, "src/Die.cs");

        Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {filePath}");

        var content = File.ReadAllText(filePath) ?? "";

        var totalValueCount = Regex.Matches(content, "_value").Count;
        var thisValueCount = Regex.Matches(content, "this\\._value").Count;

        Assert.That(totalValueCount, Is.EqualTo(thisValueCount + 1),
        "_value ska endast användas direkt vid deklarationen — alla andra användningar ska vara this._value.");

        TestContext.Out.WriteLine("✅ Använd this för att referera till attribut i klassen Die ok");
    }

    [Test]
    public void DiceHandContainingThis()
    {
        var filePath = Path.Combine(this._targetDir, "src/DiceHand.cs");

        Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {filePath}");

        var content = File.ReadAllText(filePath) ?? "";

        var totalHandCount = Regex.Matches(content, "_hand").Count;
        var thisHandCount = Regex.Matches(content, "this\\._hand").Count;

        Assert.That(totalHandCount, Is.EqualTo(thisHandCount + 1),
        "_hand ska endast användas direkt vid deklarationen — alla andra användningar ska vara this._hand.");

        TestContext.Out.WriteLine("✅ Använd this för att referera till attribut i klassen DiceHand ok");
    }

    [Test]
    public void GameContainingOk()
    {
        var filePath = Path.Combine(this._targetDir, "src/Game.cs");

        Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {filePath}");

        var content = File.ReadAllText(filePath) ?? "";

        Assert.That(content, Does.Contain("Game()"), $"Ska ha en defaultkonstruktor utan inparametrar");
        Assert.That(content, Does.Contain("Run()"), $"Ska ha en metod som heter Play utan inparametrar");

        TestContext.Out.WriteLine("✅ Game innehåller defaultkonstruktor och Play-metod ok");
    }

    [Test]
    public void MenuContainingOk()
    {
        var filePath = Path.Combine(this._targetDir, "src/Menu.cs");

        Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {filePath}");

        var content = File.ReadAllText(filePath) ?? "";

        Assert.Multiple(() =>
        {
            Assert.That(content, Does.Contain("PrintRules()"), $"Metoden PrintRules ska finnas i Menu-klassen.");
            Assert.That(content, Does.Contain("PrintMenu()"), $"Metoden PrintMenu ska finnas i Menu-klassen.");
            Assert.That(content, Does.Not.Contain("new Game("), $"Menu-klassen ska inte ha ett Game-objekt.");
        });
        TestContext.Out.WriteLine("✅ Menu innehåller ett game objekt ok");
    }

    [Test]
    public void DiceHandContainingOk()
    {
        var filePath = Path.Combine(this._targetDir, "src/DiceHand.cs");

        Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {filePath}");

        var content = File.ReadAllText(filePath) ?? "";

        Assert.That(content, Does.Contain("GetHandAsString("), $"Ska innehålla GetHandAsString");
        Assert.That(content, Does.Contain("RollAll()"), $"Ska innehålla RollAll");
        Assert.That(content, Does.Contain("GetTotal()"), $"Ska innehålla GetTotal");

        TestContext.Out.WriteLine("✅ DiceHand innehåller defaultkonstruktor och GetAsciiHand iställer för PrintHand ok");
    }
}
