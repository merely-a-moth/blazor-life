using System.Drawing;

namespace BlazorLife.Models
{
    public interface IGrid
    {
        int Generation { get; }
        string Name { get; }

        uint Width { get; }
        uint Height { get; }

        public IDictionary<Point, IGridCell> Cells { get; }

        IGridCell? CellAt(int x, int y);
        IList<TReturn> ApplyToAll<TReturn>(Func<IGridCell, TReturn> funcToApply);
    }
    public class Grid : IGrid
    {
        public int Generation { get; protected set; }
        public string Name { get; protected set; }

        public uint Width { get; protected set; }
        public uint Height { get; protected set; }

        public IDictionary<Point, IGridCell> Cells { get; protected set; }

        public IGridCell? CellAt(int x, int y)
        {
            var coordinate = new Point(x, y);
            Cells.TryGetValue(coordinate, out var cell);
            if (cell == null)
            {
                cell = new GridCell(x, y);
                Cells.Add(coordinate, cell);

                UpdateDimensions(coordinate);
            }

            return cell;
        }
        public IList<TReturn> ApplyToAll<TReturn>(Func<IGridCell, TReturn> funcToApply)
        {
            var results = new List<TReturn>();
            foreach (var cell in Cells.Values)
            {
                results.Add(funcToApply(cell));
            }
            return results;
        }

        public Grid(string name, uint width = 20, uint height = 20)
        {
            Name = name;
            Generation = 0;
            Cells = new Dictionary<Point, IGridCell>();

            Width = width; 
            Height = height;
        }

        private void UpdateDimensions(Point coord)
        {
            if (coord.Y > Height) { Height = (uint)coord.Y; }
            if (coord.X > Width) { Width = (uint)coord.X; }
        }
    }
}
