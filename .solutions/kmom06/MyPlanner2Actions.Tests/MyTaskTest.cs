using MyPlanner2.src;
using System.Reflection;

namespace MyPlanner2Actions.Tests;

[TestFixture]
public class MyTaskTest
{
    [Test]
    public void TestMyTaskIsAbstract()
    {

        string path = Path.Combine("../../../..", "MyPlanner2", "src", "MyTask.cs");
        string content = File.ReadAllText(path);
        string message = $"Test that your MyTask is abstract.";
        bool abstractOk = content.Contains("public abstract class MyTask");

        Assert.That(abstractOk, Is.True, message);
    }

    [Test]
    public void TestIFileHandlerContainsTwoAbstractMethods()
    {

        string path = Path.Combine("../../../..", "MyPlanner2", "src", "MyTask.cs");
        string content = File.ReadAllText(path);
        string message = $"Test that your MyTask contains two abstract methods.";
        bool abstractOk1 = content.Contains("public abstract string GetDescription();");
        bool abstractOk2 = content.Contains("public abstract List<string> GetFieldInfo();");

        Assert.Multiple(() =>
        {
            Assert.That(abstractOk1, Is.True, message);
            Assert.That(abstractOk2, Is.True, message);
        });

    }
}