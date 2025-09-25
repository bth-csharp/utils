using MyPlanner2.src;
using System.Reflection;

namespace MyPlanner2Actions.Tests;

[TestFixture]
public class PrivateTaskTest
{
    [Test]
    public void TestPrivateTaskImplementsAbstract()
    {

        string path = Path.Combine("../../../..", "MyPlanner2", "src", "PrivateTask.cs");
        string content = File.ReadAllText(path);
        string message = $"Test that your PrivateTask implement the abstract methods.";
        bool getDescriptionOk = content.Contains("override string GetDescription");
        bool getFieldInfoOk = content.Contains("override List<string> GetFieldInfo");

        Assert.Multiple(() =>
        {
            Assert.That(getDescriptionOk, Is.True, message);
            Assert.That(getFieldInfoOk, Is.True, message);
        });

    }
}