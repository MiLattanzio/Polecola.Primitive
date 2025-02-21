namespace Polecola.Primitive;

/// <summary>
/// Provides conversion methods for various data types.
/// </summary>
public static partial class Convert
{
    /// <summary>
    /// Converts a boolean array to a decimal number.
    /// </summary>
    /// <param name="s">The boolean array to convert.</param>
    /// <returns>The decimal representation of the boolean array.</returns>
    public static decimal ToDecimal(this bool[] s){
        var bytes = ToByteArray(s);
        return ToDecimal(bytes);
    }

    /// <summary>
    /// Converts a boolean array into a decimal number.
    /// </summary>
    /// <param name="s">The boolean array to be converted.</param>
    /// <returns>The decimal representation of the boolean array.</returns>
    public static decimal ToDecimal(this byte[] s) => new (ToIntArray(s));
}