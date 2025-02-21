namespace Polecola.Primitive.Test;

/// <summary>
/// Contains a suite of tests to verify the functionality and accuracy of integer-related
/// extension methods, including conversion to boolean arrays, retrieval, and modification
/// of specific bit values.
/// </summary>
/// <remarks>
/// This class is designed to validate operations that involve converting integers to
/// boolean arrays, retrieving specific boolean values, and setting boolean values at
/// specified indices within an integer. The tests ensure data consistency and correct
/// behavior of the extension methods under various conditions.
/// </remarks>
[TestFixture]
public class IntTest
{
    /// <summary>
    /// Tests the conversion of an integer to a boolean array and back to an integer, verifying consistency.
    /// </summary>
    /// <remarks>
    /// This method converts a randomly generated integer value into a boolean array using the `ToBoolArray` extension method.
    /// It then reconstructs the integer from the boolean array and asserts that the reconstructed integer matches the original value.
    /// Additionally, it converts the boolean array to a byte array, verifies the byte array length, and ensures that converting
    /// the byte array back to the original integer maintains consistency.
    /// </remarks>
    [Test]
    public void ToBoolArray()
    {
        var value = Random.Shared.Next();
        var bools = value.ToBoolArray();
        var result = bools.ToInt();
        Assert.That(result, Is.EqualTo(value));
        var bytes = bools.ToByteArray();
        Assert.That(bytes, Has.Length.EqualTo(4));
        var valueBack = bytes.ToInt();
        Assert.That(valueBack, Is.EqualTo(value));
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
        var value = Random.Shared.Next();
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
        var value = Random.Shared.Next();
        var valueInverted = ~value;
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