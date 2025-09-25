using System.Reflection;

namespace MyPlanner2Actions.Tests;

public class PlannerTest
{
    private MethodInfo[] _methods;

    [SetUp]
    public void Setup()
    {
    }

    [OneTimeSetUp]
    public void SetupBeforeTests()
    {
        Type type = typeof(MyPlanner2.src.Planner);
        _methods = type.GetMethods(
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.DeclaredOnly);

    }

    [Test]
    public void TestPlannerMethodsPrivate()
    {
        string[] methodNames = ["ReadTasksFromFile ", "SaveTasksToFile "];
        string message = $"Test that your Planner contains correct method names.";
        var actualMethods = _methods.Where(m => !m.IsSpecialName).ToList();
        foreach (var name in methodNames)
        {
            bool containsName = actualMethods.Any(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            Assert.That(containsName, Is.False, message + $"{name} should be private.");
        }
    }

    [Test]
    public void TestPlannerHasCorrectMethodNames()
    {
        string[] methodNames = ["ReadTasksFromFile", "SaveTasksToFile"];
        string path = Path.Combine("../../../..", "MyPlanner2", "src", "Planner.cs");
        string content = File.ReadAllText(path);
        string message = $"Test that your Planner contains ";
        bool methodReadOk = content.Contains(methodNames[0]);
        bool methodSaveOk = content.Contains(methodNames[1]);

        Assert.Multiple(() =>
        {
            Assert.That(methodReadOk, Is.True, message + $"{methodNames[0]}.");
            Assert.That(methodSaveOk, Is.True, message + $"{methodNames[1]}.");
        });

    }
    
    [Test]
    public void TestPlannerContainsInterface()
    {
        string interfaceDeclaration = "IFileHandler _myFileHandler";
        string interfaceUse = "_myFileHandler = new FileHandler(\"tasks.txt\")";
        string path = Path.Combine("../../../..", "MyPlanner2", "src", "Planner.cs");
        string content = File.ReadAllText(path);
        string message = $"Test that your Planner contains IFileHandler declaration.";
        bool interfaceOk = content.Contains(interfaceDeclaration);
        bool useOk = content.Contains(interfaceUse);

        Assert.That(interfaceOk, Is.True, message);
        message = $"Test that your Planner creates a correct FileHandler object.";
        Assert.That(useOk, Is.True, message);
    }
}
