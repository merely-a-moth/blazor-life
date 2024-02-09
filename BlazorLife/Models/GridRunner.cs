namespace BlazorLife.Models
{
    public interface IGridRunner
    {
        void Reset();
        void Step();
        void Run(uint numSteps);
    }
    public class GridRunner : IGridRunner
    {
        protected IGrid grid { get; set; }
        protected IGridRule rule { get; set; }

        public void Reset() 
        {
            this.grid.ApplyToAll((cell) =>
            {
                cell.Die();
                return true;
            });
        }
        public void Step() 
        {
            rule.Apply(grid);
        }
        public void Run(uint numSteps) { 
            for (uint i = 0; i < numSteps; i++)
            {
                Step();
            }
        }

        public GridRunner(IGrid grid, IGridRule rule)
        {
            this.grid = grid;
            this.rule = rule;
        }
    }
}
