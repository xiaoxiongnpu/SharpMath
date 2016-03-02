﻿using System;
using System.Diagnostics;

namespace SharpMath.Geometry
{
    public class Point
    {
        private double[] _coordinateValues;

        public Point(uint dimension)
        {
            Dimension = dimension;
            _coordinateValues = new double[dimension];
        }

        public Point(params double[] coordinates)
        {
            Dimension = (uint)coordinates.Length;
            _coordinateValues = coordinates;
        }

        public uint Dimension { get; }
        public double this[uint index]
        {
            get
            {
                return _coordinateValues[index];
            }
            set
            {
                _coordinateValues[index] = value;
            }
        }

        /// <summary>
        ///     Gets the position <see cref="Vector"/> of this <see cref="Point"/>.
        /// </summary>
        public Vector PositionVector
        {
            get
            {
                var resultVector = new Vector(Dimension);
                for (uint i = 0; i < Dimension; ++i)
                    resultVector[i] = this[i];
                return resultVector;
            }
        }

        /// <summary>
        ///     Converts this <see cref="Point"/> into a <see cref="Point"/> of another dimension.
        /// </summary>
        /// <typeparam name="T">The <see cref="Point"/> type that the current <see cref="Point"/> should be converted to.</typeparam>
        /// <returns>This <see cref="Point"/> converted into the given type.</returns>
        public T Convert<T>() where T : Point, new() // Type parameter because we need to create an instance of that specific type
        {
            var resultPoint = new T();
            if (resultPoint.Dimension == Dimension)
                Debug.Print(
                    $"Point conversion method (Point{Dimension}.To<T>()) is currently used to convert a point into one of the same dimension. Please check if this has been your intention.");
            for (uint i = 0; i < resultPoint.Dimension; ++i)
                resultPoint[i] = this[i];
            return resultPoint;
        }

        public static Point Add(Point first, Point second)
        {
            if (first.Dimension != second.Dimension)
                throw new ArgumentException("The dimensions of the points do not equal each other.");

            var resultPoint = new Point(first.Dimension);
            for (uint i = 0; i < resultPoint.Dimension; ++i)
                resultPoint[i] = first[i] + second[i];
            return resultPoint;
        }

        public static Point Subtract(Point first, Point second)
        {
            if (first.Dimension != second.Dimension)
                throw new ArgumentException("The dimensions of the points do not equal each other.");

            var resultPoint = new Point(first.Dimension);
            for (uint i = 0; i < resultPoint.Dimension; ++i)
                resultPoint[i] = first[i] - second[i];
            return resultPoint;
        }
    }
}