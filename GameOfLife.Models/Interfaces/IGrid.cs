namespace GameOfLife.Models.Interfaces
{
    public interface IGrid<TCell> : IEnumerable<TCell>
    {
        int RowsCount { get; }
        int ColumnsCount { get; } 
    }
}
