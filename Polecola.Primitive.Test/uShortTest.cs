namespace Polecola.Primitive.Test;

/// <summary>
/// Contains unit tests for validating the accuracy and robustness of ushort-related extension methods.
/// </summary>
/// <remarks>
/// This class includes comprehensive tests targeting the conversion of ushort values to boolean arrays,
/// retrieving boolean states at specific indices, and modifying those states. It ensures that the associated
/// extension methods perform correctly under various test scenarios, maintaining expected behavior and data integrity.
/// </remarks>
[TestFixture]
public class UShortTest
{
    /// <summary>
    /// Generates a random 16-bit unsigned integer represented as a `ushort`.
    /// </summary>
    /// <remarks>
    /// This method utilizes a random number generator to produce a 32-bit integer,
    /// converts it into a boolean array, and extracts the least significant 16 bits
    /// to construct a `ushort`. This ensures the output is within the valid range of a `ushort`.
    /// </remarks>
    /// <returns>
    /// A randomly generated 16-bit unsigned integer (`ushort`) value.
    /// </returns>
    private static ushort RandomUShort() => Random.Shared.Next().ToBoolArray().Take(16).ToArray().ToUShort();

    /// <summary>
    /// Converts a 16-bit unsigned integer (`ushort`) to a boolean array representation.
    /// </summary>
    /// <remarks>
    /// The method interprets the binary representation of a `ushort` value and converts each bit into a corresponding
    /// boolean value within an array. The array's length is equivalent to the number of bits in a `ushort` (16 bits).
    /// This allows for bitwise operations on the numerical data in a more human-readable and manageable boolean format.
    /// </remarks>
    /// <returns>
    /// An array of booleans where each element represents a single bit from the binary representation of the input `ushort`.
    /// </returns>
    [Test]
    public void ToBoolArray()
    {
        var value = RandomUShort();
        var bools = value.ToBoolArray();
        var result = bools.ToUShort();
        Assert.That(result, Is.EqualTo(value));
        var bytes = bools.ToByteArray();
        Assert.That(bytes, Has.Length.EqualTo(2));
        var valueBack = bytes.ToUShort();
        Assert.That(valueBack, Is.EqualTo(value));
    }


    /// <summary>
    /// Retrieves the boolean value of a specific bit at the given index within a 16-bit unsigned integer.
    /// </summary>
    /// <remarks>
    /// This method accesses the value of a bit at a specified index in the binary representation of a `ushort`.
    /// The index must be within the valid range of 0 to 15, corresponding to the 16 bits of the `ushort`.
    /// If the bit is set to 1, the method returns true; otherwise, it returns false.
    /// </remarks>
    /// <param name="b">
    /// The 16-bit unsigned integer (`ushort`) from which the boolean value of a specific bit is to be retrieved.
    /// </param>
    /// <param name="index">
    /// The zero-based index of the bit to retrieve. This index must be within the valid range (0 to 15).
    /// </param>
    /// <returns>
    /// A boolean value representing the state of the bit at the specified index. Returns true if the bit is set to 1; otherwise, false.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if the provided index is outside the valid range (0 to 15).
    /// </exception>
    [Test]
    public void GetBoolAtIndex()
    {
        var value = RandomUShort();
        var bools = value.ToBoolArray();
        for (var index = 0; index < bools.Length; index++)
        {
            var boolAtIndex = bools[index];
            Assert.That(value.GetBoolAtIndex((uint)index), Is.EqualTo(boolAtIndex));
        }
    }

    /// <summary>
    /// Sets a specific boolean value at a given bit index within an unsigned 16-bit integer (`ushort`) and validates the correctness of the operation.
    /// </summary>
    /// <remarks>
    /// This method verifies the functionality of manipulating individual bits of a `ushort` by testing the `SetBoolAtIndex` operation.
    /// It modifies each bit of the given `ushort` based on the inverted boolean representation. The test ensures that changes at each bit
    /// index result in the expected output when comparing the modified value to the inverted version of the original value.
    /// This method provides assurance that bit-level manipulation within the `ushort` is functioning as intended.
    /// </remarks>
    [Test]
    public void SetBoolAtIndex()
    {
        var value = RandomUShort();
        var valueInverted = (ushort)~value;
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