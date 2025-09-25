using MyPlanner2.src;
using System.Reflection;

namespace MyPlanner2Actions.Tests;

[TestFixture]
public class IFileHandlerTest
{
    [Test]
    public void TestIFileHandler()
    {

        string path = Path.Combine("../../../..", "MyPlanner2", "src", "IFileHandler.cs");
        string content = File.ReadAllText(path);
        string message = $"Test that your IFileHandler exists and contains Read and Save.";
        bool interfaceOk = content.Contains("interface IFileHandler");
        bool readOk = content.Contains("string[] Read();");
        bool saveOk = content.Contains("void Save(string[] lines);");

        Assert.Multiple(() =>
        {
            Assert.That(interfaceOk, Is.True, message);
            Assert.That(readOk, Is.True, message);
            Assert.That(saveOk, Is.True, message);
        });

    }

    [Test]
    public void TestIFileHandlerContainsDocumentation()
    {

        string path = Path.Combine("../../../..", "MyPlanner2", "src", "IFileHandler.cs");
        string content = File.ReadAllText(path);
        string message = $"Test that your IFileHandler contains documentation.";
        int countSummaryTags = content.Split("/// <summary>").Length - 1;
        int countParamTags = content.Split("/// <param name=\"lines\">").Length - 1;

        Assert.Multiple(() =>
        {
            Assert.That(countSummaryTags, Is.EqualTo(3), message);
            Assert.That(countParamTags, Is.EqualTo(1), message + " param tag is missing.");
        });

    }
}