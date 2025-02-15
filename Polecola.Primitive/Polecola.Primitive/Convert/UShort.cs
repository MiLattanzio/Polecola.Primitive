using System;
using System.Linq;

namespace Polecola.Primitive;

public static partial class Convert
{
    /// <summary>
    /// Converts a boolean array to an unsigned short integer.
    /// </summary>
    /// <param name="s">The boolean array to convert.</param>
    /// <returns>The converted unsigned short integer.</returns>
    public static ushort ToUShort(this bool[] s)
    {
        const int bitsInUint = sizeof(short) * 8;
        s = s.Length switch
        {
            > bitsInUint => s.TakeLast(bitsInUint).ToArray(),
            < bitsInUint => Enumerable.Repeat(false, bitsInUint - s.Length).Concat(s).ToArray(),
            _ => s
        };
        return s.Reverse().Aggregate<bool, ushort>(0, (current, bit) => (ushort)((current << 1) | (bit ? 1 : 0)));
    }

    /// <summary>
    /// Converts a boolean array to an unsigned short integer.
    /// </summary>
    /// <param name="s">The boolean array to convert.</param>
    /// <returns>The converted unsigned short integer.</returns>
    public static ushort ToUShort(this byte[] s) => BitConverter.ToUInt16(s, 0);
}