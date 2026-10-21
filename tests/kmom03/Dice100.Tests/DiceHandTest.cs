namespace Die100.Tests;
using Dice100.src;

public class DiceHandTest
{
    [Test]
    public void TestCreateDiceHandCheck5Dice()
    {
        DiceHand hand = new DiceHand();
        Assert.That(hand.GetTotal(), Is.GreaterThanOrEqualTo(0), "The sum of DiceHand should be 0 <= value <= 30 after RollAll.");
        Assert.That(hand.GetTotal(), Is.LessThanOrEqualTo(30), "The sum of DiceHand should be 0 <= value <= 30 after RollAll.");
    }

    [Test]
    public void TestRollAllDiceHand()
    {
        DiceHand hand = new DiceHand();

        hand.RollAll();
        
        Assert.That(hand.GetTotal(), Is.GreaterThanOrEqualTo(0), "The sum of DiceHand should be 0 <= value <= 30 after RollAll.");
        Assert.That(hand.GetTotal(), Is.LessThanOrEqualTo(30), "The sum of DiceHand should be 0 <= value <= 30 after RollAll.");
    }

    [Test]
    public void TestGetHandAsStringNoAscii()
    {
        DiceHand hand = new DiceHand();
        string result = hand.GetHandAsString();

        Assert.That(result.Length, Is.EqualTo(9), "The string should length 9.");
    }
}
