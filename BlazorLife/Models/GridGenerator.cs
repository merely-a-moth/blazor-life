using System.Collections.Generic;

namespace BlazorLife.Models
{
    /// <summary>
    /// Populates a grid to a known state
    /// </summary>
    /// <remarks>
    /// This is not merely an action because we want to be able to hndle custom
    /// setup/teardown code such as connecting to a remote source.
    /// </remarks>
    public interface IGridGenerator
    {
        void Generate(IGrid grid);
    }

    public class RandomGridGenerator : IGridGenerator
    {
        private uint _width;
        private uint _height;

        public void Generate(IGrid grid)
        {
            var rand = new Random(DateTime.Now.Second);
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    var cell = grid.CellAt(x, y);
                    if (cell == null) continue;
                    if (rand.Next(0, 2) == 1) { cell.Live(); } else { cell.Die(); }
                }
            }
        }

        public RandomGridGenerator(uint  width, uint height)
        {
            _width = width;
            _height = height;
        }
    }

    /// <summary>
    /// Generates a grid containing a single glider
    /// </summary>
    public class GliderGridGenerator : IGridGenerator
    {
        public void Generate(IGrid grid)
        {
            grid.CellAt(1, 3)?.Live();
            grid.CellAt(2, 1)?.Live();
            grid.CellAt(2, 3)?.Live();
            grid.CellAt(3, 2)?.Live();
            grid.CellAt(3, 3)?.Live();
        }

        public GliderGridGenerator()
        {
        }
    }
}
