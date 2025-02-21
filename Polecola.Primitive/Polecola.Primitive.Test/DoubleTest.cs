namespace Polecola.Primitive.Test;

[TestFixture]
public class DoubleTest
{
    /// <summary>
    /// Validates the conversion of a double precision floating-point number to a boolean array and back.
    /// </summary>
    /// <remarks>
    /// This method performs the following checks:
    /// - Converts a double value to a boolean array using the `ToBoolArray` method.
    /// - Converts the resulting boolean array back to a double and asserts equality with the original value.
    /// - Converts the boolean array to a byte array and verifies its length.
    /// - Converts the byte array back to a double and asserts equality with the original value.
    /// </remarks>
    [Test]
    public void ToBoolArrayTest()
    {
        var value = Random.Shared.NextDouble();
        var bools = value.ToBoolArray();
        var result = bools.ToDouble();
        Assert.That(result, Is.EqualTo(value));
        var bytes = bools.ToByteArray();
        Assert.That(bytes, Has.Length.EqualTo(8));
        var valueBack = bytes.ToDouble();
        Assert.That(valueBack, Is.EqualTo(value));
    }

    /// <summary>
    /// Validates the retrieval of a boolean value at a specific index in a boolean array representation of a double-precision floating-point number.
    /// </summary>
    /// <remarks>
    /// This method involves the following steps:
    /// - Converts a double value to a boolean array using the `ToBoolArray` method.
    /// - Iterates over the boolean array to access each value by index.
    /// - Uses the `GetBoolAtIndex` method to retrieve the boolean value at the corresponding index.
    /// - Verifies that the value retrieved by the `GetBoolAtIndex` method matches the expected value from the boolean array.
    /// </remarks>
    [Test]
    public void GetBoolAtIndexTest()
    {
        var value = Random.Shared.NextDouble();
        var bools = value.ToBoolArray();
        for (var index = 0; index < bools.Length; index++)
        {
            var boolAtIndex = bools[index];
            Assert.That(value.GetBoolAtIndex((uint)index), Is.EqualTo(boolAtIndex));
        }
        bools[0] = !bools[0];
        var newValue = bools.ToDouble();
        Assert.That(newValue, Is.Not.EqualTo(value));
        value = value.SetBoolAtIndex(0, bools[0]);
        Assert.That(value, Is.EqualTo(newValue));
    }

    [Test]
    public void RangeTest()
    {
        var start = Random.Shared.NextDouble();
        var end = start + (double.Epsilon * Random.Shared.Next());
        var i = 0ul;
        var current = 0d;
        foreach (var value in Double.Range(start, end))
        {
            Assert.That(value, Is.GreaterThan(current));
            current = value;
            i++;
        }
        var count = Double.Count(start, end);
        Assert.That(count, Is.EqualTo(i));
    }
}