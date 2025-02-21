namespace Polecola.Primitive.Test;

[TestFixture]
public class DecimalTest
{
    /// <summary>
    /// Validates the conversion of a decimal number to a boolean array and back.
    /// </summary>
    /// <remarks>
    /// This method performs the following checks:
    /// - Converts a decimal number to a boolean array using the `ToBoolArray` method.
    /// - Converts the resulting boolean array back to a decimal and asserts equality with the original value.
    /// - Converts the boolean array to a byte array and verifies its length.
    /// - Converts the byte array back to a decimal and asserts equality with the original value.
    /// </remarks>
    [Test]
    public void ToBoolArrayTest()
    {
        var value = (decimal)Random.Shared.NextDouble();
        var bools = value.ToBoolArray();
        var result = bools.ToDecimal();
        Assert.That(result, Is.EqualTo(value));
        var bytes = bools.ToByteArray();
        Assert.That(bytes, Has.Length.EqualTo(16));
        var valueBack = bytes.ToDecimal();
        Assert.That(valueBack, Is.EqualTo(value));
    }

    /// <summary>
    /// Validates the retrieval of a boolean value from a specific index in the representation of a decimal number as a boolean array.
    /// </summary>
    /// <remarks>
    /// This method performs the following operations:
    /// - Converts a decimal number to a boolean array using the `ToBoolArray` method.
    /// - Iterates through each index of the boolean array.
    /// - Retrieves the boolean value at each index using the `GetBoolAtIndex` method.
    /// - Asserts that the value returned by `GetBoolAtIndex` matches the value at the corresponding index in the boolean array.
    /// </remarks>
    [Test]
    public void GetBoolAtIndexTest()
    {
        var value = (decimal)Random.Shared.NextDouble();
        var bools = value.ToBoolArray();
        for (var index = 0; index < bools.Length; index++)
        {
            var boolAtIndex = bools[index];
            Assert.That(value.GetBoolAtIndex((uint)index), Is.EqualTo(boolAtIndex));
        }
        bools[0] = !bools[0];
        var newValue = bools.ToDecimal();
        Assert.That(newValue, Is.Not.EqualTo(value));
        value = value.SetBoolAtIndex(0, bools[0]);
        Assert.That(value, Is.EqualTo(newValue));
    }
}