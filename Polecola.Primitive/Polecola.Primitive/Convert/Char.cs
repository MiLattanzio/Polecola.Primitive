using System;
using System.Linq;

namespace Polecola.Primitive;

/// <summary>
/// Provides conversion utilities for various data types.
/// </summary>
public static partial class Convert
{
    /// <summary>
    /// Converts a binary array to a character.
    /// </summary>
    /// <param name="s">The binary array to convert.</param>
    /// <returns>The character representation of the binary array.</returns>
    public static char ToChar(this bool[] s) {
        s = s.Length switch
        {
            > sizeof(char) * 8 => s[0..(sizeof(char)*8)],
            < sizeof(char) * 8 => Enumerable.Repeat(false, (sizeof(char)*8) - s.Length).Concat(s).ToArray(),
            _ => s
        };
        var b = (char)0;
        foreach (var t in s.Reverse())
        {
            b <<= 1;
            if (t) b |= (char)1;
        }
        return b;
    }
    
    public static char ToChar(this byte[] b) => BitConverter.ToChar(b, 0);
}