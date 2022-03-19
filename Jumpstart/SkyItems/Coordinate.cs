using System;

namespace Jumpstart
{
    public struct Coordinate
    {
        private uint X { get; set; }
        private uint Y { get; set; }
        private uint Z { get; set; }

        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }

        public string Info(string position)
        {
            return $"The {position} coordinates:" +
                   $"\n OX = {X}\n OY = {Y}" +
                   $"\n OZ = {Z}";
        }

        public Coordinate(uint x, uint y, uint z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Method finds the distance between 2 points in space.
        /// </summary>
        /// <param name="startPoint">Current position.</param>
        /// <param name="destinationPoint">Destination position.</param>
        /// <returns></returns>
        public double DistanceBetweenTwoPoints(Coordinate startPoint, Coordinate destinationPoint)
        {
            return Math.Sqrt((Math.Pow((destinationPoint.X - startPoint.X), 2) +
                              Math.Pow((destinationPoint.Y - startPoint.Y), 2) +
                              Math.Pow((destinationPoint.Z - startPoint.Z), 2)));
        }
    }
}
