﻿using System;
using System.Collections.Generic;

namespace Polecola.Primitive;

public static class Double
{
    /// <summary>
    /// Generates a sequence of double values starting from the specified start value, incrementing by the specified step, and ending before the specified end value.
    /// </summary>
    /// <param name="start">The starting value of the sequence.</param>
    /// <param name="end">The exclusive upper or lower bound of the sequence depending on the direction of the step.</param>
    /// <param name="step">The increment value for the sequence. Must be a non-zero value. Positive step generates an increasing sequence, and negative step generates a decreasing sequence.</param>
    /// <returns>A sequence of double values from start to end, incremented by step.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the step parameter is zero.</exception>
    public static IEnumerable<double> Range(double start, double end, double step = double.Epsilon)
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
    /// Counts the number of elements in the sequence generated by the specified start, end, and step values.
    /// </summary>
    /// <param name="start">The starting value of the sequence.</param>
    /// <param name="end">The exclusive upper or lower bound of the sequence depending on the direction of the step.</param>
    /// <param name="step">The increment value for the sequence. Must be a non-zero value. Positive step generates an increasing sequence, and negative step generates a decreasing sequence.</param>
    /// <returns>The count of elements in the sequence generated by the specified parameters.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the step parameter is zero.</exception>
    public static ulong Count(double start, double end, double step = double.Epsilon)
    {
        if ((step > 0 && start >= end) || (step < 0 && start <= end))
        {
            return 0;
        }
        return (ulong)Math.Ceiling(Math.Abs((end - start) / step));

    }

}