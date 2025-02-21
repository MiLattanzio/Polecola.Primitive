namespace Polecola.Primitive.Test;

/// <summary>
/// Provides unit tests for validating the correctness of integer-related extension methods,
/// focusing on operations such as bitwise manipulation and conversions.
/// </summary>
/// <remarks>
/// The UIntTest class includes tests that ensure the accuracy and reliability of
/// extension methods which convert integers to boolean arrays, retrieve specific boolean
/// values from integer representations, and modify individual bits within integers.
/// These tests are designed to handle a variety of scenarios to confirm proper behavior
/// under different conditions.
/// </remarks>
[TestFixture]
public class UIntTest
{
    /// <summary>
    /// Generates a random unsigned integer value using internal mechanisms for test purposes.
    /// </summary>
    /// <returns>
    /// A randomly generated unsigned integer value. The result is consistent with the test suite to ensure compatibility
    /// with associated extension methods, including boolean array conversions.
    /// </returns>
    private static uint RandomUInt() => Random.Shared.Next().ToBoolArray().ToUInt();

    /// <summary>
    /// Tests the conversion of an integer to a boolean array and back to an integer, verifying data integrity and consistency.
    /// </summary>
    /// <remarks>
    /// This method generates a random unsigned integer and converts it to a boolean array using the `ToBoolArray` extension method.
    /// It ensures that reconstructing the integer from the boolean array using `ToUInt` produces a value equal to the original integer.
    /// Additionally, the method confirms that converting the boolean array into a byte array provides the expected length, and converting
    /// the byte array back to an integer retains the original value.
    /// </remarks>
    [Test]
    public void ToBoolArray()
    {
        var value = RandomUInt();
        var bools = value.ToBoolArray();
        var result = bools.ToUInt();
        Assert.That(result, Is.EqualTo(value));
        var bytes = bools.ToByteArray();
        Assert.That(bytes, Has.Length.EqualTo(4));
        var valueBack = bytes.ToUInt();
        Assert.That(valueBack, Is.EqualTo(value));
    }


    /// <summary>
    /// Validates the correctness of retrieving the boolean value at a specified index from an integer.
    /// </summary>
    /// <remarks>
    /// This test method uses a randomly generated integer value and converts it into a boolean array using the `ToBoolArray` extension method.
    /// The method iterates over each index of the boolean array and verifies that the value retrieved by the `GetBoolAtIndex` extension method
    /// correctly matches the corresponding value in the array representation. This ensures that bitwise indexing and retrieval operations are
    /// consistent and accurate.
    /// </remarks>
    [Test]
    public void GetBoolAtIndex()
    {
        var value = RandomUInt();
        var bools = value.ToBoolArray();
        for (var index = 0; index < bools.Length; index++)
        {
            var boolAtIndex = bools[index];
            Assert.That(value.GetBoolAtIndex((uint)index), Is.EqualTo(boolAtIndex));
        }
    }

    /// <summary>
    /// Verifies the functionality of modifying individual bits of a `uint` by setting them to specific boolean values based on their index.
    /// </summary>
    /// <remarks>
    /// This method tests the `SetBoolAtIndex` functionality by creating a random `uint` value and its bitwise inverse. The test converts the original
    /// value to a boolean array and inverts the resulting array values. It then iterates through the inverted boolean array, applying each value
    /// to the corresponding bit index of the `uint` using the `SetBoolAtIndex` method. Finally, the test checks if the `uint` modified with the
    /// inverted boolean array matches the original inverted value to confirm the accuracy and integrity of the bit-set operation.
    /// </remarks>
    [Test]
    public void SetBoolAtIndex()
    {
        var value = RandomUInt();
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