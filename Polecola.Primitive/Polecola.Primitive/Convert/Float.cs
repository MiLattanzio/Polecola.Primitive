using System;

namespace Polecola.Primitive;

/// <summary>
/// The Convert class provides various conversion methods for different data types.
/// </summary>
public static partial class Convert
{
    /// <summary>
    /// Converts a boolean array to a float value.
    /// </summary>
    /// <param name="s">The boolean array.</param>
    /// <returns>The corresponding float value.</returns>
    public static float ToFloat(this bool[] s)
    {
        var bytes = ToByteArray(s);
        return BitConverter.ToSingle(bytes);
    }
}