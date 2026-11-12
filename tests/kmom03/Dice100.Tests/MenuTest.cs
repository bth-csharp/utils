using Dice100.src;

namespace Dice100.Tests;
[TestFixture]
public class MenuTest
{
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        if (TestContext.CurrentContext.Result.FailCount == 0)
        {
            TestContext.Progress.WriteLine("✅ Alla testfall i Menu gick igenom.\n");
        }
        else
        {
            TestContext.Progress.WriteLine("❌ Något testfall gick fel i Menu.\n");
        }
    }

    [Test]
    public void TestShowRulesWritesToConsole()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        Menu.PrintRules();

        string output = writer.ToString();
        Assert.That(output.Length, Is.GreaterThan(100), "The rules text is too short min 100 characters required.");

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }

    [Test]
    public void TestShowMenuWritesToConsole()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        Menu.PrintMenu();

        string output = writer.ToString();
        Assert.That(output, Does.Contain("1."));
        Assert.That(output, Does.Contain("2."));
        Assert.That(output, Does.Contain("3."));
        Assert.That(output, Does.Contain("4."));

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }
}
