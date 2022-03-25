namespace GameOfLife.Models.Interfaces
{

    public interface IGrid<TCell> : System.Collections.Generic.IEnumerable<TCell>
    {
        int RowsCount { get; }
        int ColumnsCount { get; } 
    }
}
