namespace Polecola.Primitive.Test;

/// <summary>
/// Implements unit tests for verifying the correctness and stability of short integer-related extension methods,
/// ensuring their functionality across various edge cases and scenarios.
/// </summary>
/// <remarks>
/// This class encompasses tests for operations such as converting short integers to boolean arrays,
/// retrieving specific boolean values at defined indices, and updating those values.
/// Tests aim to ensure compliance with expected outcomes and maintain data integrity
/// when using the associated extension methods.
/// </remarks>
[TestFixture]
public class ShortTest
{
    /// <summary>
    /// Generates a random 16-bit signed integer represented as a `short`.
    /// </summary>
    /// <remarks>
    /// This method creates a random 32-bit integer and converts it to a boolean array.
    /// It then truncates the boolean array to the least significant 16 bits and
    /// converts it into a `short` value, ensuring the resulting value is within
    /// the range representable by a `short`.
    /// </remarks>
    /// <returns>
    /// A randomly generated 16-bit signed integer (`short`) value.
    /// </returns>
    private static short RandomShort() => Random.Shared.Next().ToBoolArray().Take(16).ToArray().ToShort();

    /// <summary>
    /// Converts a short integer to a boolean array representation.
    /// </summary>
    /// <remarks>
    /// This method transforms the binary representation of a short integer into an array of booleans,
    /// where each boolean corresponds to a bit in the short. It utilizes an intermediate conversion
    /// to a byte array followed by a per-byte conversion to boolean arrays to achieve the desired result.
    /// </remarks>
    [Test]
    public void ToBoolArray()
    {
        var value = RandomShort();
        var bools = value.ToBoolArray();
        var result = bools.ToShort();
        Assert.That(result, Is.EqualTo(value));
        var bytes = bools.ToByteArray();
        Assert.That(bytes, Has.Length.EqualTo(2));
        var valueBack = bytes.ToShort();
        Assert.That(valueBack, Is.EqualTo(value));
    }


    /// <summary>
    /// Verifies the correct retrieval of a boolean value at a specified bit index within a short integer.
    /// </summary>
    /// <remarks>
    /// This method ensures that the `GetBoolAtIndex` extension accurately retrieves the boolean representation of a given bit.
    /// It converts a randomly generated `short` value into its boolean array representation. For each bit index, the boolean value retrieved
    /// using `GetBoolAtIndex` is compared with the corresponding value in the boolean array, confirming the consistency and correctness of the method.
    /// </remarks>
    [Test]
    public void GetBoolAtIndex()
    {
        var value = RandomShort();
        var bools = value.ToBoolArray();
        for (var index = 0; index < bools.Length; index++)
        {
            var boolAtIndex = bools[index];
            Assert.That(value.GetBoolAtIndex((uint)index), Is.EqualTo(boolAtIndex));
        }
    }

    /// <summary>
    /// Validates the ability to set a specific boolean value at a given bit index within a short integer representation.
    /// </summary>
    /// <remarks>
    /// This method tests the `SetBoolAtIndex` functionality by modifying a short integer's bit representation at various indices.
    /// It uses the original short value, inverts it for comparison, and iterates through its boolean representation to set new values.
    /// The test ensures that changes made at each index match the expected output when the integer is reconstructed from the modified representation.
    /// This guarantees the method's accuracy in manipulating individual bits in a short integer.
    /// </remarks>
    [Test]
    public void SetBoolAtIndex()
    {
        var value = RandomShort();
        var valueInverted = (short)~value;
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