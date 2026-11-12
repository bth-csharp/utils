using System.Text.RegularExpressions;

namespace Dice100.Tests;

public class GeneralTest
{
    private string _targetDir = "";

    [SetUp]
    public void Setup()
    {
        var workflowDir = Environment.GetEnvironmentVariable("PROJECT_ROOT");

        if (!string.IsNullOrEmpty(workflowDir))
        {
            // Körs i GitHub Actions
            this._targetDir = Path.Combine(workflowDir, "kmom03", "Dice100");
        }
        else
        
        {
            var testDir = TestContext.CurrentContext.TestDirectory;
            var rootDir = Path.GetFullPath(Path.Combine(testDir, "..", "..", "..", ".."));
            this._targetDir = Path.Combine(rootDir, "Dice100") ?? "";
        }
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
        TestContext.Out.WriteLine("✅ Bara Menu innehåller I/O");
    }

    [TestCase("Player")]
    [TestCase("Game game = ")]
    [TestCase("game.Run()")]
    [TestCase("using Dice100.src")]
    public void MainProgramContaining(string name)
    {
        var filePath = Path.Combine(this._targetDir, "Program.cs");

        Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {filePath}");

        var content = File.ReadAllText(filePath) ?? "";

        Assert.That(content, Does.Contain(name),
        $"{name} ska endast användas i huvudprogrammet 'Program.cs'.");

        TestContext.Out.WriteLine($"✅ Program.cs innehåller klasserna Player och Game ok");
    }

    [TestCase("Die")]
    [TestCase("DiceHand")]
    [TestCase("FileHandler")]
    [TestCase("static")]
    [TestCase("void")]
    [TestCase("main")]
    public void MainProgramNotContaining(string name)
    {
        var filePath = Path.Combine(this._targetDir, "Program.cs");

        Assert.That(File.Exists(filePath), Is.True, $"Filen saknas: {filePath}");

        var content = File.ReadAllText(filePath) ?? "";

        Assert.That(content, Does.Not.Contain(name),
        $"{name} ska INTE användas i huvudprogrammet 'Program.cs'.");

        TestContext.Out.WriteLine($"✅ Program.cs har ok innehåll");
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
            Assert.That(content, Does.Contain("public static void PrintRules()"), $"Metoden PrintRules ska finnas i Menu-klassen.");
            Assert.That(content, Does.Contain("public static void PrintMenu()"), $"Metoden PrintMenu ska finnas i Menu-klassen.");
            Assert.That(content, Does.Not.Contain("new Game("), $"Menu-klassen ska inte ha ett Game-objekt.");
            Assert.That(content, Does.Contain("public static class Menu"), $"Menu-klassen ska inte ha ett Game-objekt.");
        });
        TestContext.Out.WriteLine("✅ Menu verkar ok");
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
