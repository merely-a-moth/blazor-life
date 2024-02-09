using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace BlazorLife.Models
{
    public interface IGridRule
    {
        public void Apply(IGrid grid);
    }

    public class GridRule : IGridRule
    {
        protected enum CellState
        {
            Alive = 1,
            Dead = 0
        }

        protected CellState UpdateCellLife(IGrid grid, IGridCell cell)
        {
            // how many living neighbors?
            Point[] neighborCoordinates = [
                cell.CellAbove(), 
                cell.CellBelow(), 
                cell.CellLeft(), 
                cell.CellRight(),
                cell.CellNW(),
                cell.CellNE(),
                cell.CellSW(),
                cell.CellSE()
            ];
            int livingNeighbors = 0;
            foreach (Point neighborPoint in neighborCoordinates)
            {
                if (!grid.Cells.ContainsKey(neighborPoint)) continue;
                var neighbor = grid.Cells[neighborPoint];
                if (neighbor is null) continue;
                if (neighbor.IsAlive) { livingNeighbors++; }
            }

            if (cell.IsAlive)
            {
                if (livingNeighbors >= 2 && livingNeighbors <= 3)
                    return CellState.Alive;
                else
                    return CellState.Dead;
            }
            else if (livingNeighbors == 3)
            {
                return CellState.Alive;
            }
            return CellState.Dead;
            
        }

        public void Apply(IGrid grid)
        {
            var stateFunc = (IGridCell cell) => Tuple.Create(cell, UpdateCellLife(grid, cell) == CellState.Alive ? true : false);
            var results = grid.ApplyToAll(stateFunc);

            foreach (var result in results)
            {
                var cell = result.Item1;
                if (result.Item2)
                {
                    cell.Live();
                }
                else
                {
                    cell.Die();
                }
            }
        }
    }
}
