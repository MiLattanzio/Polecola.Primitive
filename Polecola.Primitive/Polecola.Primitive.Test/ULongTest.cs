namespace Polecola.Primitive.Test;

/// <summary>
/// Provides unit tests to validate the behavior and consistency of unsigned long integer-related extension methods,
/// ensuring they function correctly across a variety of operational scenarios.
/// </summary>
/// <remarks>
/// This class is designed to rigorously test the conversion of unsigned long integers to boolean arrays,
/// as well as to verify the correctness of retrieving and setting boolean values at specific indices.
/// The tests are aimed to confirm the conformity of data transformations and modifications with expected outputs.
/// </remarks>
[TestFixture]
public class ULongTest
{
    /// <summary>
    /// Generates a random unsigned long integer by utilizing randomization, conversion to a boolean array,
    /// and subsequent reinterpretation as an unsigned long integer.
    /// </summary>
    /// <returns>A randomly generated unsigned long integer.</returns>
    public static ulong RandomULong() => Random.Shared.NextInt64().ToBoolArray().ToULong();

    /// <summary>
    /// Verifies the process of converting a 64-bit unsigned integer (ulong) to a boolean array and back, ensuring data integrity is maintained.
    /// </summary>
    /// <remarks>
    /// This test utilizes the `ToBoolArray` method to transform a ulong into a boolean array. It confirms that reconstructing the ulong via the `ToULong` method yields the original input.
    /// Additional validations include converting the boolean array into a byte array and confirming its length.
    /// The final check ensures that reconversion from the byte array to a ulong produces a consistent and accurate result.
    /// </remarks>
    [Test]
    public void ToBoolArray()
    {
        var value = RandomULong();
        var bools = value.ToBoolArray();
        var result = bools.ToULong();
        Assert.That(result, Is.EqualTo(value));
        var bytes = bools.ToByteArray();
        Assert.That(bytes, Has.Length.EqualTo(8));
        var valueBack = bytes.ToULong();
        Assert.That(valueBack, Is.EqualTo(value));
    }


    /// <summary>
    /// Confirms the functionality of retrieving a boolean value at a specified index from a given unsigned long (`ulong`) value.
    /// </summary>
    /// <remarks>
    /// This test validates the behavior of the `GetBoolAtIndex` extension method by converting a randomly generated `ulong` value
    /// into a boolean array representation. It then iterates through all bits of the boolean array, and for each index,
    /// it verifies that the boolean value obtained using `GetBoolAtIndex` matches the corresponding value in the array.
    /// This ensures the method retrieves the correct boolean representation of a specific bit in the original `ulong` value.
    /// </remarks>
    [Test]
    public void GetBoolAtIndex()
    {
        var value = RandomULong();
        var bools = value.ToBoolArray();
        for (var index = 0; index < bools.Length; index++)
        {
            var boolAtIndex = bools[index];
            Assert.That(value.GetBoolAtIndex((uint)index), Is.EqualTo(boolAtIndex));
        }
    }

    /// <summary>
    /// Validates the ability to set a specific boolean value at a designated index within the binary representation of an unsigned long integer.
    /// </summary>
    /// <remarks>
    /// The `SetBoolAtIndex` test ensures that a boolean value can be accurately set at a specific bit index in the binary format of an unsigned long integer.
    /// The functionality is tested by converting an unsigned long integer to a boolean array representation, modifying the boolean values at each index,
    /// and applying the changes back to the integer representation. The test checks the integrity of the modified value against its expected inverted result,
    /// confirming the method's correctness in manipulating individual bits in the underlying data structure.
    /// </remarks>
    [Test]
    public void SetBoolAtIndex()
    {
        var value = RandomULong();
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