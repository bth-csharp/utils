using MyPlanner2.src;
using System.Reflection;

namespace MyPlanner2.Tests;

[TestFixture]
public class FileHandlerTest
{
    private const string READ_FILE = @"TestData/testReadTasks.txt";
    private const string APPEND_FILE = @"TestData/testAppendTask.txt";
    private const string WRITE_FILE = @"TestData/testWriteFile.txt";
    private const string LOCKED_FILE = @"TestData/lockedFile.txt";
    private const string CORRECT_LINE1 = "2,20,19,dbwebb,csharp,utveckla kurs,2025-06-05,true";
    private const string CORRECT_LINE2 = "vardagsrummet,städ2,damma,2025-06-05,false";
    private const string CORRECT_LINE3 = "1,4,0,oocsharp,kmom06,koda en lösning på kmom06,2025-06-24,false";
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
    public void TestReadLinesCorrect()
    {
        var filePath = Path.Combine(this._testDirectory, READ_FILE);
        var fileHandler = new FileHandler(filePath);
        string[] fileLines = fileHandler.Read();
        string[] content = [CORRECT_LINE1, CORRECT_LINE2];
        string message = $"Test that your FileHandler can read and contains {content[0]} and {content[1]}";

        Assert.That(fileLines.Length, Is.EqualTo(2));
        Assert.That(fileLines[0], Does.Contain(content[0]), message);
        Assert.That(fileLines[1], Does.Contain(content[1]), message);
    }

    [Test]
    public void TestReadLinesFileNotExists()
    {
        var filePath = Path.Combine(this._testDirectory, "fileNotExist.txt");
        var fileHandler = new FileHandler(filePath);
        string message = "Test that your FileHandler returns [] when file not found.";
        var result = fileHandler.Read();
        Assert.That(result, Is.Empty, message);
        Assert.That(result.Length, Is.EqualTo(0), message);
    }

    [Test]
    public void TestReadLinesIOError()
    {
        var filePath = Path.Combine(this._testDirectory, READ_FILE);
        var fileHandler = new FileHandler(filePath);
        string message = "Test that your FileHandler can read throws exception when file is used by another process.";
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            var result = fileHandler.Read();
            Assert.That(result, Is.Empty, message);
            Assert.That(result.Length, Is.EqualTo(0), message);
            // Assert.Throws<IOException>(() => fileHandler.Read(), message);
            // // eller
            // Assert.That(() => fileHandler.Read(), Throws.TypeOf<IOException>(), message);
        }
    }

    [Test]
    public void TestReadLinesUnauthorizedError()
    {
        var filePath = Path.Combine(this._testDirectory, LOCKED_FILE);
        var fileHandler = new FileHandler(filePath);
        string message = "Test that your FileHandler can read throws exception when file is used by another process.";
        var result = fileHandler.Read();
        Assert.That(result, Is.Empty, message);
        Assert.That(result.Length, Is.EqualTo(0), message);
    }

    [Test]
    public void TestWriteLineCorrect()
    {
        var filePath = Path.Combine(this._testDirectory, WRITE_FILE);
        var fileHandler = new FileHandler(filePath);
        string[] fileLines = [CORRECT_LINE1];
        fileHandler.Save(fileLines);

        string[] result = File.ReadAllLines(filePath);
        string message = $"Test that your FileHandler can write and read and contains {CORRECT_LINE1}.";

        Assert.That(result.Length, Is.EqualTo(1));
        Assert.That(result[0], Does.Contain(fileLines[0]), message);
    }

    [Test]
    public void TestSaveLinesIOError()
    {
        var filePath = Path.Combine(this._testDirectory, READ_FILE);
        var fileHandler = new FileHandler(filePath);
        string[] fileLines = [CORRECT_LINE3];
        string message = "Test that your FileHandler can read throws exception when file is used by another process.";
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            fileHandler.Save(fileLines);
        }
        System.Threading.Thread.Sleep(200);
        string[] result = File.ReadAllLines(filePath);
        Assert.That(result.Length, Is.EqualTo(2), message);
    }

    [Test]
    public void TestSaveLinesUnauthorizedError()
    {
        var filePath = Path.Combine(this._testDirectory, LOCKED_FILE);
        var fileHandler = new FileHandler(filePath);
        string[] fileLines = [CORRECT_LINE3];
        string message = "Test that your FileHandler can read throws exception when file is used by another process.";
        fileHandler.Save(fileLines);
        Assert.Throws<UnauthorizedAccessException>(() => File.ReadAllLines(filePath), message);
    }
}
