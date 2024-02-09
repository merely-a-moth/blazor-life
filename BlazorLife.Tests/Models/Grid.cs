using BlazorLife.Models;

namespace BlazorLife.Tests.Models
{
    [TestClass]
    public class Grid_CellAtShould
    {
        private readonly Grid _grid;
        public Grid_CellAtShould()
        {
            _grid = new Grid("TestGrid");
        }

        [TestMethod]
        public void Should_add_created_cells_when_not_found()
        {
            var testCell = _grid.CellAt(99, 99);

            Assert.IsTrue(_grid.Cells.Count == 1);
            Assert.IsTrue(_grid.CellAt(99, 99) == testCell);
        }
    }
}
