using System.Diagnostics.Tracing;
using System.Drawing;

namespace BlazorLife.Models
{
    /// <summary>
    /// Interface to individual cells of a grid
    /// </summary>
    public interface IGridCell
    {
        /// <summary>
        /// The cell's position in the grid
        /// </summary>
        Point Coordinate { get; }

        /// <summary>
        /// Returns true if this cell is currently alive, false if this cell is dead.
        /// </summary>
        bool IsAlive { get; }

        Point CellAbove();
        Point CellBelow();
        Point CellLeft();
        Point CellRight();
        Point CellNW();
        Point CellNE();
        Point CellSW();
        Point CellSE();

        /// <summary>
        /// Set cell to living
        /// </summary>
        void Live();

        /// <summary>
        /// Set cell to die
        /// </summary>
        void Die();

    }

    /// <summary>
    /// implementation of a grid cell
    /// </summary>
    public class GridCell : IGridCell
    {
        /// <summary>
        /// The cell's position in the grid
        /// </summary>
        public Point Coordinate { get; protected set; }

        public bool IsAlive { get; protected set; }

        /// <summary>
        /// Get the coordinate of the cell above this one
        /// </summary>
        public Point CellAbove()
        {
            return new Point(Coordinate.X, Coordinate.Y - 1);
        }

        /// <summary>
        /// Get the coordinate of the cell below this one
        /// </summary>
        public Point CellBelow()
        {
            return new Point(Coordinate.X, Coordinate.Y + 1);
        }

        /// <summary>
        /// Get the coordinate of the cell left this one
        /// </summary>
        public Point CellLeft()
        {
            return new Point(Coordinate.X - 1, Coordinate.Y);
        }

        /// <summary>
        /// Get the coordinate of the cell right this one
        /// </summary>
        public Point CellRight()
        {
            return new Point(Coordinate.X + 1, Coordinate.Y);
        }
        public Point CellNW()
        {
            return new Point(Coordinate.X - 1, Coordinate.Y - 1);
        }
        public Point CellNE()
        {
            return new Point(Coordinate.X + 1, Coordinate.Y - 1);
        }
        public Point CellSW()
        {
            return new Point(Coordinate.X - 1, Coordinate.Y + 1);
        }
        public Point CellSE()
        {
            return new Point(Coordinate.X + 1, Coordinate.Y + 1);
        }

        public void Live()
        {
            IsAlive = true;
        }

        public void Die()
        {
            IsAlive = false;
        }

        public GridCell(Point coordinate)
        {
            Coordinate = coordinate;
            IsAlive = false;
        }
        public GridCell(int x, int y) : this(new Point(x, y)) { }
        public GridCell() : this(0, 0) { }
    }
}
