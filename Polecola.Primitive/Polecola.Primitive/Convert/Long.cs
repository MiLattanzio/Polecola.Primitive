using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Polecola.Primitive;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static partial class Convert
{
    /// <summary>
    /// Converts a binary array to a long integer.
    /// </summary>
    /// <param name="s">The binary array to convert.</param>
    /// <returns>The converted long integer.</returns>
    public static long ToLong(this bool[] s) {
        s = s.Length switch
        {
            > sizeof(long) * 8 => s[0..(sizeof(long)*8)],
            < sizeof(long) * 8 => Enumerable.Repeat(false, (sizeof(long)*8) - s.Length).Concat(s).ToArray(),
            _ => s
        };
        long b = 0;
        foreach (var t in s.Reverse())
        {
            b <<= 1;
            if (t) b |= 1;
        }
        return b;
    }

    /// <summary>
    /// Converts a byte array to a long integer.
    /// </summary>
    /// <param name="b">The byte array to convert.</param>
    /// <returns>The converted long integer.</returns>
    public static long ToLong(this byte[] b) => BitConverter.ToInt64(b, 0);
}