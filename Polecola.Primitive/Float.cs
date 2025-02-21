using System;
using System.Collections.Generic;

namespace Polecola.Primitive;

public static class Float
{
    /// <summary>
    /// Generates a sequence of float numbers starting from the specified start value, up to but not including the specified end value,
    /// incrementing or decrementing by a specified step value.
    /// </summary>
    /// <param name="start">The value at which to start the sequence.</param>
    /// <param name="end">The value at which to end the sequence. The sequence does not include this value.</param>
    /// <param name="step">The value by which each subsequent number in the sequence increases or decreases. Must not be zero.</param>
    /// <returns>A sequence of float values from start to end, incrementing or decrementing by the step value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the step value is zero.</exception>
    public static IEnumerable<float> Range(float start, float end, float step = float.Epsilon)
    {
        if (step == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(step), "Step cannot be zero.");
        }

        if ((!(step > 0) || !(start < end)) && (!(step < 0) || !(start > end))) yield break;
        for (var current = start; (step > 0 && current < end) || (step < 0 && current > end); current += step)
        {
            yield return current;
        }
    }

    /// <summary>
    /// Calculates the total number of steps required to traverse a sequence of float numbers
    /// starting from the specified start value, up to but not including the specified end value,
    /// with a given step value.
    /// </summary>
    /// <param name="start">The value at which the sequence starts.</param>
    /// <param name="end">The value at which the sequence ends. The count does not include this value.</param>
    /// <param name="step">The incremental or decremental value between each number in the sequence. Must not be zero.</param>
    /// <returns>The total count of steps required to traverse the sequence.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the step value is zero.</exception>
    public static ulong Count(float start, float end, float step = float.Epsilon)
    {
        if ((step > 0 && start >= end) || (step < 0 && start <= end))
        {
            return 0;
        }
        return (ulong)Math.Ceiling(Math.Abs((end - start) / step));
    }
    
    
}