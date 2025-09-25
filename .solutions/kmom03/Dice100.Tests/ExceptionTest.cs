namespace Die100.Tests;
using Dice100.src;

public class ExceptionTest
{
    [Test]
    public void TestIfNumberOfDieExceptionExists()
    {
        NumberOfDieException noOfEx = new NumberOfDieException("");
        Assert.That(noOfEx, Is.InstanceOf<NumberOfDieException>());
    }
}
