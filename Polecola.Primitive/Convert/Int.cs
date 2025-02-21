using System;
using System.Linq;

namespace Polecola.Primitive;

/// <summary>
/// The Convert class provides static methods for converting different data types.
/// </summary>
public static partial class Convert
{
    /// <summary>
    /// Converts a boolean array to an integer.
    /// </summary>
    /// <param name="s">The boolean array to convert.</param>
    /// <returns>The integer value obtained from the boolean array.</returns>
    public static int ToInt(this bool[] s) {
        s = s.Length switch
        {
            > sizeof(int) * 8 => s[0..(sizeof(int)*8)],
            < sizeof(int) * 8 => Enumerable.Repeat(false, (sizeof(int)*8) - s.Length).Concat(s).ToArray(),
            _ => s
        };
        var b = 0;
        foreach (var t in s.Reverse())
        {
            b <<= 1;
            if (t) b |= 1;
        }
        return b;
    }

    /// <summary>
    /// Converts a boolean array to an integer.
    /// </summary>
    /// <param name="s">The boolean array to convert.</param>
    /// <returns>The resulting integer.</returns>
    public static int ToInt(this byte[] s) => BitConverter.ToInt32(s, 0);
}