namespace Polecola.Primitive.Test;

public class ByteTest
{
    /// <summary>
    /// Tests the conversion of a byte to a boolean array and back to a byte, ensuring data consistency.
    /// </summary>
    /// <remarks>
    /// This method iterates through all possible values of a byte, converts each value into a boolean array
    /// using the extension method `ToBoolArray`, and then converts the boolean array back to a byte using the
    /// `ToByte` extension method. The test ensures that the resultant byte matches the original input value.
    /// </remarks>
    [Test]
    public void ToBoolArray()
    {
        foreach (var b in Enumerable.Range(byte.MinValue, byte.MaxValue))
        {
           var value = (byte)b;
           Assert.That(b, Is.EqualTo(value));
           var bools = value.ToBoolArray();
           var result = bools.ToByte();
           Assert.That(result, Is.EqualTo(value));
           var bytes = bools.ToByteArray();
           Assert.That(bytes, Has.Length.EqualTo(1));
           Assert.That(bytes[0], Is.EqualTo(value));
        }
    }


    /// <summary>
    /// Validates the correctness of retrieving the boolean value at a specified index from a byte.
    /// </summary>
    /// <remarks>
    /// This method generates a random byte, converts it to a boolean array using the `ToBoolArray` extension method,
    /// and iterates over each index of the boolean array. It ensures that the value retrieved by the `GetBoolAtIndex`
    /// extension method matches the corresponding value in the boolean array. This test verifies that the index-based
    /// retrieval from the byte is accurate and consistent with its boolean array representation.
    /// </remarks>
    [Test]
    public void GetBoolAtIndex()
    {
        var bytes = new byte[] { 0x0 };
        Random.Shared.NextBytes(bytes);
        var value = bytes[0];
        var bools = value.ToBoolArray();
        for (var index = 0; index < bools.Length; index++)
        {
            var boolAtIndex = bools[index];
            Assert.That(value.GetBoolAtIndex((uint)index), Is.EqualTo(boolAtIndex));
        }
    }

    /// <summary>
    /// Verifies that a byte value can be updated by setting individual bits to specified boolean values based on their index.
    /// </summary>
    /// <remarks>
    /// This method initializes a byte, then inverts its bits. Each bit of the original byte is converted to a boolean array,
    /// and the inverse array is iterated over. For each index, the corresponding boolean value is applied to the byte using
    /// the `SetBoolAtIndex` method. The test ensures the final byte matches the inverted original value, validating the correctness
    /// of the `SetBoolAtIndex` implementation.
    /// </remarks>
    [Test]
    public void SetBoolAtIndex()
    {
        var bytes = new byte[] { 0x0 };
        Random.Shared.NextBytes(bytes);
        var value = bytes[0];
        var valueInverted = (byte)~value;
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