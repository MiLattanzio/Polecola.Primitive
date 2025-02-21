using System;

namespace Polecola.Primitive;

public static partial class Convert
{
    /// <summary>
    /// Converts a binary array to a double value.
    /// </summary>
    /// <param name="s">The binary array to convert.</param>
    /// <returns>The converted double value.</returns>
    public static double ToDouble(this bool[] s){
        var bytes = ToByteArray(s);
        return BitConverter.ToDouble(bytes);
    }

    /// <summary>
    /// Converts a byte array to a double value.
    /// </summary>
    /// <param name="s">The byte array to convert.</param>
    /// <returns>The converted double value.</returns>
    public static double ToDouble(this byte[] s) => BitConverter.ToDouble(s);
}