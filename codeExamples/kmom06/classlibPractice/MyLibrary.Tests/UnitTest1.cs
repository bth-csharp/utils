using NUnit.Framework;
using MyLibrary;

namespace MyLibrary.Tests;

public class CalculatorTests
{
    [Test]
    public void Add_ReturnsCorrectSum()
    {
        Assert.That(Calculator.Add(6, 4), Is.EqualTo(10));
    }
}

