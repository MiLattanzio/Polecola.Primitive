namespace Polecola.Primitive.Test;

/// <summary>
/// Test class to validate the functionality of character-related operations, particularly
/// how characters are interpreted and manipulated as binary or boolean representations.
/// </summary>
/// <remarks>
/// This class contains test methods to assess the accuracy of converting characters to boolean arrays,
/// manipulating specific bits within the boolean array, and reconstructing the character from such arrays,
/// confirming the integrity of the transformation at each step.
/// </remarks>
[TestFixture]
public class CharTest
{
    /// <summary>
    /// Converts a char value to a boolean array representation.
    /// </summary>
    /// <remarks>
    /// This method transforms the binary representation of a char value into an array of booleans,
    /// where each boolean corresponds to a specific bit in the char's internal binary structure.
    /// The length of the resulting array is determined by the bit-width of a char in memory.
    /// </remarks>
    [Test]
    public void ToBoolArray()
    {
        foreach (var b in Enumerable.Range(char.MinValue, char.MaxValue))
        {
            var value = (char)b;
            Assert.That(b, Is.EqualTo(value));
            var bools = value.ToBoolArray();
            var result = bools.ToChar();
            Assert.That(result, Is.EqualTo(value));
            var bytes = bools.ToByteArray();
            Assert.That(bytes, Has.Length.EqualTo(2));
            var valueBack = bytes.ToChar();
            Assert.That(valueBack, Is.EqualTo(value));
        }
    }

    [Test]
    public void GetBoolAtIndex()
    {
        var bytes = new byte[] { 0x0, 0x0 };
        Random.Shared.NextBytes(bytes);
        var value = bytes.ToChar();
        var bools = value.ToBoolArray();
        for (var index = 0; index < bools.Length; index++)
        {
            var boolAtIndex = bools[index];
            Assert.That(value.GetBoolAtIndex((uint)index), Is.EqualTo(boolAtIndex));
        }
    }

  
    [Test]
    public void SetBoolAtIndex()
    {
        var bytes = new byte[] { 0x0, 0x0 };
        Random.Shared.NextBytes(bytes);
        var value = bytes.ToChar();
        var valueInverted = (char)~value;
        var bools = value.ToBoolArray();
        var boolsInverted = bools.Select(x => !x).ToArray();
        for (var index = 0; index < boolsInverted.Length; index++)
        {
            var boolAtIndex = boolsInverted[index];
            value = value.SetBoolAtIndex((uint)index, boolAtIndex);
        }
        Assert.That(valueInverted, Is.EqualTo(value));
    }
}