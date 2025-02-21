namespace Polecola.Primitive.Test;

/// <summary>
/// Provides unit tests to validate the behavior and reliability of long integer-related extension methods,
/// ensuring they function correctly under various scenarios.
/// </summary>
/// <remarks>
/// This class focuses on testing operations such as conversion of long integers to boolean arrays,
/// retrieval of specific boolean values at given indices, and modification of these values.
/// The tests ensure adherence to expected behaviors and data integrity when employing the provided extension methods.
/// </remarks>
[TestFixture]
public class LongTest
{
    /// <summary>
    /// Tests the conversion of a long integer to a boolean array and back to a long integer, ensuring correctness and integrity of the process.
    /// </summary>
    /// <remarks>
    /// This method uses the `ToBoolArray` extension method to convert a randomly generated long integer into a boolean array.
    /// It then reconstructs the long integer from the boolean array using the `ToLong` method, asserting that the output matches the original value.
    /// The functionality is further validated by converting the boolean array to a byte array and confirming the proper length of the byte array.
    /// Finally, the method verifies that converting the byte array back to the original long integer yields a consistent result.
    /// </remarks>
    [Test]
    public void ToBoolArray()
    {
        var value = Random.Shared.NextInt64();
        var bools = value.ToBoolArray();
        var result = bools.ToLong();
        Assert.That(result, Is.EqualTo(value));
        var bytes = bools.ToByteArray();
        Assert.That(bytes, Has.Length.EqualTo(8));
        var valueBack = bytes.ToLong();
        Assert.That(valueBack, Is.EqualTo(value));
    }


    /// <summary>
    /// Confirms the functionality of retrieving a boolean value at a specified index from a long value.
    /// </summary>
    /// <remarks>
    /// This method tests the `GetBoolAtIndex` extension method by converting a randomly generated `long` value into a boolean array.
    /// It then iterates through each bit index of the array, comparing the boolean value at each index retrieved using
    /// the `GetBoolAtIndex` method to the corresponding value in the boolean array. This ensures that the `GetBoolAtIndex`
    /// method accurately retrieves the boolean representation of a specific bit within the `long` value.
    /// </remarks>
    [Test]
    public void GetBoolAtIndex()
    {
        var value = Random.Shared.NextInt64();
        var bools = value.ToBoolArray();
        for (var index = 0; index < bools.Length; index++)
        {
            var boolAtIndex = bools[index];
            Assert.That(value.GetBoolAtIndex((uint)index), Is.EqualTo(boolAtIndex));
        }
    }

    /// <summary>
    /// Validates the functionality of setting a specific boolean value at a given bit index within an integer representation.
    /// </summary>
    /// <remarks>
    /// This test ensures that the `SetBoolAtIndex` method correctly modifies a boolean representation of an integer at a specific index.
    /// The process involves taking an integer, inverting its value for testing, and iterating through its boolean array.
    /// For each index, the boolean value is modified and applied back to the integer, verifying that the resulting value matches
    /// the expected inverted result. This test confirms the method's capability to accurately manipulate individual bits within an integer.
    /// </remarks>
    [Test]
    public void SetBoolAtIndex()
    {
        var value = Random.Shared.NextInt64();
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