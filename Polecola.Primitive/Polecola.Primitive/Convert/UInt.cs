using System;
using System.Linq;

namespace Polecola.Primitive;

public static partial class Convert
{
    /// <summary>
    /// Converts a boolean array to an unsigned 32-bit integer.
    /// </summary>
    /// <param name="s">The boolean array to convert.</param>
    /// <returns>The converted unsigned 32-bit integer.</returns>
    public static uint ToUInt(this bool[] s)
    {
        const int bitsInUint = sizeof(uint) * 8;
        s = s.Length switch
        {
            > bitsInUint => s.TakeLast(bitsInUint).ToArray(),
            < bitsInUint => Enumerable.Repeat(false, bitsInUint - s.Length).Concat(s).ToArray(),
            _ => s
        };
        return s.Reverse().Aggregate<bool, uint>(0, (current, bit) => (current << 1) | (bit ? 1u : 0u));
    }
    public static uint ToUInt(this byte[] s) => BitConverter.ToUInt32(s, 0);
        
}