using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Polecola.Primitive;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static partial class Convert
{
    /// <summary>
    /// Converts a boolean array to a short value.
    /// </summary>
    /// <param name="s">The boolean array to convert. If null, a default array of length sizeof(short)*8 will be created.</param>
    /// <returns>The converted short value.</returns>
    public static short ToShort(this bool[] s)
    {
        const int bitsInUint = sizeof(short) * 8;
        s = s.Length switch
        {
            > bitsInUint => s.TakeLast(bitsInUint).ToArray(),
            < bitsInUint => Enumerable.Repeat(false, bitsInUint - s.Length).Concat(s).ToArray(),
            _ => s
        };
        return s.Reverse().Aggregate<bool, short>(0, (current, bit) => (short)((current << 1) | (bit ? 1 : 0)));
    }

    /// <summary>
    /// Converts a boolean array to a short value.
    /// </summary>
    /// <param name="s">The boolean array to convert. If null, a default array of length sizeof(short)*8 will be created.</param>
    /// <returns>The converted short value.</returns>
    public static short ToShort(this byte[] s) => BitConverter.ToInt16(s, 0);
        
}