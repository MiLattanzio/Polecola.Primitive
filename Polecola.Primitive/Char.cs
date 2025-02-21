using System;
using System.Collections.Generic;
using System.Linq;

namespace Polecola.Primitive;

public static class Char
{
    private const char Step = (char)0x1;

    /// <summary>
    /// Generates a sequence of characters within the specified range, starting from the given start character
    /// and ending with the given end character, using the specified step value.
    /// </summary>
    /// <param name="start">The starting character of the range.</param>
    /// <param name="end">The ending character of the range.</param>
    /// <param name="step">The increment or decrement to apply between characters in the range. Defaults to 1. Must not be zero.</param>
    /// <returns>An <see cref="IEnumerable{char}"/> sequence of characters from the start to the end, incremented or decremented by the step value.</returns>
    /// <exception cref="ArgumentException">Thrown when the step is zero.</exception>
    public static IEnumerable<char> Range(char start, char end, char step = Step)
    {
        if (step == 0)
            throw new ArgumentException("Step cannot be zero.", nameof(step));

        if (step > 0)
        {
            for (var current = start; current < end; current = (char)(current + step))
            {
                yield return current;
            }
        }
        else
        {
            for (var current = start; current > end; current = (char)(current + step))
            {
                yield return current;
            }
        }
    }

    /// <summary>
    /// Counts the number of characters in a sequence generated within the specified range,
    /// starting from the given start character and ending with the given end character,
    /// using the specified step value.
    /// </summary>
    /// <param name="start">The starting character of the range. Defaults to <see cref="char.MinValue"/>.</param>
    /// <param name="end">The ending character of the range. Defaults to <see cref="char.MaxValue"/>.</param>
    /// <param name="step">The increment or decrement to apply between characters in the range. Defaults to 1. Must not be zero.</param>
    /// <returns>The total number of characters in the sequence.</returns>
    /// <exception cref="ArgumentException">Thrown when the step is zero.</exception>
    public static int Count(char start = char.MinValue, char end = char.MaxValue, char step = Step) => Range(start, end, step).Count();
}