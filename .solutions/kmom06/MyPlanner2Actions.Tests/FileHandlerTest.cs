using MyPlanner2.src;
using System.Reflection;
using System.Threading.Tasks;

namespace MyPlanner2Actions.Tests;

[TestFixture]
public class FileHandlerTest
{
    private const string READ_FILE = @"TestData/testReadTasks.txt";
    private const string APPEND_FILE = @"TestData/testAppendTask.txt";
    private const string WRITE_FILE = @"TestData/testWriteFile.txt";
    private const string WRITE_FILE2 = @"TestData/testWriteFile2.txt";
    private const string LOCKED_FILE = @"TestData/lockedFile.txt";
    private const string CORRECT_LINE1 = "2,20,19,dbwebb,csharp,utveckla kurs,2025-06-05,true";
    private const string CORRECT_LINE2 = "vardagsrummet,städ2,damma,2025-06-05,false";
    private const string CORRECT_LINE3 = "1,4,0,oocsharp,kmom06,koda en lösning på kmom06,2025-06-24,false";
    private string _testDirectory;
    private MethodInfo[] _methods;

    [OneTimeSetUp]
    public void SetupBeforeTests()
    {
        this._testDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "./";
        var filePath = Path.Combine(_testDirectory, WRITE_FILE);
        File.Delete(filePath);
        filePath = Path.Combine(_testDirectory, WRITE_FILE2);
        File.Delete(filePath);
        Type type = typeof(MyPlanner2.src.FileHandler);
        _methods = type.GetMethods(
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.DeclaredOnly);

    }

    [OneTimeTearDown]
    public void TearDownAfterTests()
    {
        var directoryPath = Path.Combine(_testDirectory, "TestData");
        Directory.Delete(directoryPath, true);
    }

    [Test]
    public void TestFileHandlerContainsAsyncAndAwait()
    {

        string path = Path.Combine("../../../..", "MyPlanner2", "src", "FileHandler.cs");
        string content = File.ReadAllText(path);
        string message = $"Test that your FileHandler contains async 2 times.";
        int countAsync = content.Split("async").Length - 1;
        int countAwait = content.Split("await").Length - 1;

        Assert.That(countAsync, Is.EqualTo(2), message);
        message = $"Test that your FileHandler contains await 2 times.";
        Assert.That(countAwait, Is.GreaterThanOrEqualTo(2), message);
    }

    [Test]
    public void TestFileHandlerContainsTask()
    {

        string path = Path.Combine("../../../..", "MyPlanner2", "src", "FileHandler.cs");
        string content = File.ReadAllText(path);
        string message = $"Test that your FileHandler contains Task SaveAsync.";
        bool taskSaveOk = content.Contains("Task SaveAsync(string[] lines)");
        bool taskReadOk = content.Contains("Task<string[]> ReadAsync()");

        Assert.That(taskSaveOk, Is.True, message);
        message = $"Test that your FileHandler contains Task<string[]> ReadAsync.";
        Assert.That(taskReadOk, Is.True, message);
    }

    [Test]
    public void TestFileHandlerImplementsInterface()
    {

        string path = Path.Combine("../../../..", "MyPlanner2", "src", "FileHandler.cs");
        string content = File.ReadAllText(path);
        string message = $"Test that your FileHandler implements IFileHandler.";
        bool interfaceOk = content.Contains(": IFileHandler");

        Assert.That(interfaceOk, Is.True, message);
    }

    [Test]
    public void TestFileHandlerContainsFourMethods()
    {
        string message = $"Test that your FileHandler contains at least 4 _methods.";
        Assert.That(_methods.Count, Is.GreaterThanOrEqualTo(4), message);
    }

    [Test]
    public void TestFileHandlerHasCorrectMethodNames()
    {
        string[] methodNames = ["Read", "Save", "ReadAsync", "SaveAsync"];
        string message = $"Test that your FileHandler contains correct method names.";
        var actualMethods = _methods.Where(m => !m.IsSpecialName).ToList();
        foreach (var name in methodNames)
        {
            bool containsName = actualMethods.Any(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            Assert.That(containsName, Is.True, message + $"Missing: {name}");
        }
    }
}
