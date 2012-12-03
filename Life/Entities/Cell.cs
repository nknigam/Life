using System;

namespace Life.Entities
{
    /// <summary>
    /// structure to hold x and y indices of grid cell
    /// </summary>
    struct CoOrdinates
    {
        public int X;
        public int Y;
        public CoOrdinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Cell
    {
        public Boolean IsActive { get; set; }

        public Cell(Boolean isActive)
        {
            IsActive = isActive;
        }

        /// <summary>
        /// ToString implementation of cell
        /// </summary>
        /// <returns>retuns string representation of cell</returns>
        public override string ToString()
        {
            return (IsActive ? " X " : " - ");
        }

    }
}
