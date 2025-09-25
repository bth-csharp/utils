namespace Die100.Tests;
using Dice100.src;
using System.Reflection;

[TestFixture]
public class FileHandlerTest
{
    private const string READ_FILE1 = @"TestData/testReadFile1.txt";
    private const string READ_FILE2 = @"TestData/testReadFile2.txt";
    private const string APPEND_FILE = @"TestData/testAppendFile.txt";
    private const string WRITE_FILE = @"TestData/testWriteFile.txt";
    private const string CORRECT_LINE1 = "5, Testperson1, 103, 15";
    private const string CORRECT_LINE2 = "3, Testperson2, 108, 25";
    private const string CORRECT_LINE3 = "3, Testperson3, 103, 16";
    private string _testDirectory;

    [OneTimeSetUp]
    public void SetupBeforeTests()
    {
        this._testDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "./";
        var filePath = Path.Combine(_testDirectory, WRITE_FILE);
        File.Delete(filePath);
    }

    [OneTimeTearDown]
    public void TearDownAfterTests()
    {
        var directoryPath = Path.Combine(_testDirectory, "TestData");
        Directory.Delete(directoryPath, true);
    }

    [Test]
    public void TestReadLineCorrect()
    {
        string filePath = Path.Combine(_testDirectory, READ_FILE1);
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), READ_FILE1, SearchOption.AllDirectories);
        string[] fileLines = FileHandler.ReadFromFile(files[0]);
        string[] content = CORRECT_LINE1.Split(",");
        string message = $"Test that your FileHandler can read and contains {content[0]}, {content[1]}, {content[2]} and {content[3]}";

        Assert.That(fileLines.Length, Is.EqualTo(1));
        Assert.That(fileLines[0], Does.Contain(content[0]).And.Contain(content[1]).And.Contain(content[2]).And.Contain(content[3]), message);
    }

    [Test]
    public void TestReadLinesCorrect()
    {
        var filePath = Path.Combine(this._testDirectory, READ_FILE2);
        string[] fileLines = FileHandler.ReadFromFile(filePath);
        string[] content = CORRECT_LINE1.Split(",");
        string message = $"Test that your FileHandler can read and contains {content[0]}, {content[1]}, {content[2]} and {content[3]}";

        Assert.That(fileLines.Length, Is.EqualTo(3));
        Assert.That(fileLines[0], Does.Contain(content[0]).And.Contain(content[1]).And.Contain(content[2]).And.Contain(content[3]), message);
        content = CORRECT_LINE2.Split(",");
        message = $"Test that your FileHandler can read and contains {content[0]}, {content[1]}, {content[2]} and {content[3]}";
        Assert.That(fileLines[1], Does.Contain(content[0]).And.Contain(content[1]).And.Contain(content[2]).And.Contain(content[3]), message);
        content = CORRECT_LINE3.Split(",");
        message = $"Test that your FileHandler can read and contains {content[0]}, {content[1]}, {content[2]} and {content[3]}";
        Assert.That(fileLines[2], Does.Contain(content[0]).And.Contain(content[1]).And.Contain(content[2]).And.Contain(content[3]), message);
    }

    [Test]
    public void TestWriteLineCorrect()
    {
        var filePath = Path.Combine(this._testDirectory, WRITE_FILE);
        string[] fileLines = { CORRECT_LINE1 };
        FileHandler.SaveToFile(filePath, fileLines);

        string result = File.ReadAllText(filePath).Trim();
        string[] content = CORRECT_LINE1.Split(",");
        string message = $"Test that your FileHandler can write and read and contains {content[0]}, {content[1]}, {content[2]} and {content[3]}";

        Assert.That(result.Length, Is.EqualTo(23));
        Assert.That(result, Does.Contain(content[0]).And.Contain(content[1]).And.Contain(content[2]).And.Contain(content[3]), message);
    }

    [Test]
    public void TestAppendLinesCorrect()
    {
        var filePath = Path.Combine(this._testDirectory, APPEND_FILE);
        string[] fileLines = { CORRECT_LINE2, CORRECT_LINE3 };
        FileHandler.SaveToFile(filePath, fileLines);

        string[] resultLines = File.ReadAllLines(filePath);
        string[] content = CORRECT_LINE1.Split(",");
        string message = $"Test that your FileHandler can append and read and contains {content[0]}, {content[1]}, {content[2]} and {content[3]}";

        Assert.That(resultLines.Length, Is.EqualTo(3));
        Assert.That(resultLines[0], Does.Contain(content[0]).And.Contain(content[1]).And.Contain(content[2]).And.Contain(content[3]), message);
        content = CORRECT_LINE2.Split(",");
        message = $"Test that your FileHandler can append and read and contains {content[0]}, {content[1]}, {content[2]} and {content[3]}";
        Assert.That(resultLines[1], Does.Contain(content[0]).And.Contain(content[1]).And.Contain(content[2]).And.Contain(content[3]), message);
        content = CORRECT_LINE3.Split(",");
        message = $"Test that your FileHandler can append and read and contains {content[0]}, {content[1]}, {content[2]} and {content[3]}";
        Assert.That(resultLines[2], Does.Contain(content[0]).And.Contain(content[1]).And.Contain(content[2]).And.Contain(content[3]), message);
    }
}
