using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;

namespace Polecola.Primitive;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static class Bool
{
    /// <summary>
    /// Gets the boolean value at the specified index in a byte.
    /// </summary>
    /// <param name="b">The byte value.</param>
    /// <param name="index">The index of the bit.</param>
    /// <returns>The boolean value at the specified index.</returns>
    public static bool GetBoolAtIndex(this byte b, uint index)
    {
        return (b & (1 << (int)index)) != 0;
    }

    /// <summary>
    /// Gets the boolean value at the specified index in a short.
    /// </summary>
    /// <param name="b">The short value.</param>
    /// <param name="index">The index of the bit.</param>
    /// <returns>The boolean value at the specified index.</returns>
    public static bool GetBoolAtIndex(this short b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[byteIndex].GetBoolAtIndex(bitIndex);
    }

    /// <summary>
    /// Retrieves the boolean value at the specified index from the given byte.
    /// </summary>
    /// <param name="b">The byte from which to retrieve the boolean value.</param>
    /// <param name="index">The index of the boolean value to retrieve.</param>
    /// <returns>The boolean value at the specified index.</returns>
    public static bool GetBoolAtIndex(this ushort b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[byteIndex].GetBoolAtIndex(bitIndex);
    }

    /// <summary>
    /// Retrieves the boolean value at a specific index of a byte.
    /// </summary>
    /// <param name="b">The byte value.</param>
    /// <param name="index">The index of the bit.</param>
    /// <returns>The boolean value at the specified index.</returns>
    public static bool GetBoolAtIndex(this int b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[byteIndex].GetBoolAtIndex(bitIndex);
    }

    /// <summary>
    /// Retrieves the Boolean value at the specified index in a byte.
    /// </summary>
    /// <param name="b">The byte value.</param>
    /// <param name="index">The index.</param>
    /// <returns>The Boolean value at the specified index.</returns>
    public static bool GetBoolAtIndex(this uint b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[byteIndex].GetBoolAtIndex(bitIndex);
    }


    /// <summary>
    /// Retrieves the bool value at the specified index from a byte.
    /// </summary>
    /// <param name="b">The byte value.</param>
    /// <param name="index">The index of the bool value to retrieve.</param>
    /// <returns>The bool value at the specified index.</returns>
    public static bool GetBoolAtIndex(this float b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[byteIndex].GetBoolAtIndex(bitIndex);
    }

    /// <summary>
    /// Retrieves the boolean value at the specified index from a byte value.
    /// </summary>
    /// <param name="b">The byte value.</param>
    /// <param name="index">The index of the boolean value to retrieve.</param>
    /// <returns>The boolean value at the specified index.</returns>
    public static bool GetBoolAtIndex(this long b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[byteIndex].GetBoolAtIndex(bitIndex);
    }

    /// <summary>
    /// Gets the value of the bit at the specified index in a byte.
    /// </summary>
    /// <param name="b">The byte value.</param>
    /// <param name="index">The index of the target bit (0-7).</param>
    /// <returns>The boolean value of the specified bit.</returns>
    public static bool GetBoolAtIndex(this ulong b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[byteIndex].GetBoolAtIndex(bitIndex);
    }

    /// <summary>
    /// Retrieves the boolean value at the specified index in the given byte.
    /// </summary>
    /// <param name="b">The byte value from which to retrieve the boolean.</param>
    /// <param name="index">The index of the boolean to retrieve, ranging from 0 to 7.</param>
    /// <returns>
    /// <c>true</c> if the boolean at the specified index is 1;
    /// otherwise, <c>false</c> if the boolean at the specified index is 0.
    /// </returns>
    public static bool GetBoolAtIndex(this double b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[byteIndex].GetBoolAtIndex(bitIndex);
    }

    /// <summary>
    /// Retrieves the value of a boolean at the specified index from a byte.
    /// </summary>
    /// <param name="b">The byte from which to retrieve the boolean value.</param>
    /// <param name="index">The index of the boolean value to retrieve.</param>
    /// <returns>The boolean value at the specified index in the byte.</returns>
    public static bool GetBoolAtIndex(this decimal b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[byteIndex].GetBoolAtIndex(bitIndex);
    }

    /// <summary>
    /// Gets the boolean value at the specified index from a byte value.
    /// </summary>
    /// <param name="b">The byte value.</param>
    /// <param name="index">The index of the boolean value to retrieve.</param>
    /// <returns>The boolean value at the specified index.</returns>
    public static bool GetBoolAtIndex(this char b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[byteIndex].GetBoolAtIndex(bitIndex);
    }

    /// <summary>
    /// Retrieves the boolean value at the specified index from a byte.
    /// </summary>
    /// <param name="b">The byte value.</param>
    /// <param name="index">The index of the boolean value to retrieve. The index is zero-based.</param>
    /// <returns>The boolean value at the specified index.</returns>
    public static bool GetBoolAtIndex(this BigInteger b, uint index)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return bytes[(int)byteIndex].GetBoolAtIndex(bitIndex);
    }
        
    /// <summary>
    /// Sets the value of a specified bit at the given index in a byte.
    /// </summary>
    /// <param name="b">The byte value.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated byte value with the specified bit set.</returns>
    public static byte SetBoolAtIndex(this byte b, uint index, bool value)
    {
        if (value) return (byte)(b | (1 << (int)index));
        return (byte)(b & ~(1 << (int)index));
    }
        
    /// Sets the value of the bit at the given index in a character.
    /// <param name="b">The character value.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated character value with the specified bit set.</returns>
    public static char SetBoolAtIndex(this char b, uint index, bool value)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        bytes[byteIndex] = bytes[byteIndex].SetBoolAtIndex(bitIndex, value);
        return bytes.Select(x => x.ToBoolArray()).SelectMany(x =>x).ToArray().ToChar();
    }

    /// <summary>
    /// Sets the value of a specified bit at the given index in a decimal number.
    /// </summary>
    /// <param name="b">The decimal number.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated decimal number with the specified bit set.</returns>
    public static decimal SetBoolAtIndex(this decimal b, uint index, bool value)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        bytes[byteIndex] = bytes[byteIndex].SetBoolAtIndex(bitIndex, value);
        return bytes.ToDecimal();
    }
        
    /// <summary>
    /// Sets the value of a specified bit at the given index in a 64-bit double-precision floating-point number.
    /// </summary>
    /// <param name="b">The double value.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated double value with the specified bit set.</returns>
    public static double SetBoolAtIndex(this double b, uint index, bool value)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        bytes[byteIndex] = bytes[byteIndex].SetBoolAtIndex(bitIndex, value);
        return BitConverter.ToDouble(bytes);
    }
        
    /// <summary>
    /// Sets the value of a specified bit at the given index in a float.
    /// </summary>
    /// <param name="b">The float value.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated float value with the specified bit set.</returns>
    public static float SetBoolAtIndex(this float b, uint index, bool value)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        bytes[byteIndex] = bytes[byteIndex].SetBoolAtIndex(bitIndex, value);
        return BitConverter.ToSingle(bytes);
    }
        
    /// <summary>
    /// Sets the value of a specified bit at the given index in a boolean array and returns the updated boolean array as an integer.
    /// </summary>
    /// <param name="b">The original integer value representing a boolean array.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated boolean array as an integer.</returns>
    public static int SetBoolAtIndex(this int b, uint index, bool value)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        bytes[byteIndex] = bytes[byteIndex].SetBoolAtIndex(bitIndex, value);
        return bytes.Select(x => x.ToBoolArray()).SelectMany(x =>x).ToArray().ToInt();
    }
        
    /// <summary>
    /// Sets the value of a specified bit at the given index in a long.
    /// </summary>
    /// <param name="b">The long value.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated long value with the specified bit set.</returns>
    public static long SetBoolAtIndex(this long b, uint index, bool value)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        bytes[byteIndex] = bytes[byteIndex].SetBoolAtIndex(bitIndex, value);
        return bytes.Select(x => x.ToBoolArray()).SelectMany(x =>x).ToArray().ToLong();
    }
        
    /// <summary>
    /// Sets the value of a specified bit at the given index in a short.
    /// </summary>
    /// <param name="b">The short value.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated short value with the specified bit set.</returns>
    public static short SetBoolAtIndex(this short b, uint index, bool value)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        bytes[byteIndex] = bytes[byteIndex].SetBoolAtIndex(bitIndex, value);
        return bytes.Select(x => x.ToBoolArray()).SelectMany(x => x).ToArray().ToShort();
    }
        
    /// <summary>
    /// Sets the value of a specified bit at the given index in an unsigned 32-bit integer.
    /// </summary>
    /// <param name="b">The unsigned 32-bit integer value.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated unsigned 32-bit integer value with the specified bit set.</returns>
    public static uint SetBoolAtIndex(this uint b, uint index, bool value)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        bytes[byteIndex] = bytes[byteIndex].SetBoolAtIndex(bitIndex, value);
        return bytes.Select(x => x.ToBoolArray()).SelectMany(x => x).ToArray().ToUInt();
    }
        
    /// <summary>
    /// Sets the value of a specified bit at the given index in a ulong value.
    /// </summary>
    /// <param name="b">The ulong value.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated ulong value with the specified bit set.</returns>
    public static ulong SetBoolAtIndex(this ulong b, uint index, bool value)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        bytes[byteIndex] = bytes[byteIndex].SetBoolAtIndex(bitIndex, value);
        return bytes.Select(x => x.ToBoolArray()).SelectMany(x =>x).ToArray().ToULong();
    }
        
    /// <summary>
    /// Sets the value of a specified bit at the given index in a ushort.
    /// </summary>
    /// <param name="b">The ushort value.</param>
    /// <param name="index">The index of the bit to set.</param>
    /// <param name="value">The value to set the bit to.</param>
    /// <returns>The updated ushort value with the specified bit set.</returns>
    public static ushort SetBoolAtIndex(this ushort b, uint index, bool value)
    {
        var bytes = b.ToByteArray();
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        bytes[byteIndex] = bytes[byteIndex].SetBoolAtIndex(bitIndex, value);
        return bytes.Select(x => x.ToBoolArray()).SelectMany(x => x).ToArray().ToUShort();
    }
}