namespace GameOfLife.Models.Interfaces
{
    public interface IRules<TGrid, TCell>
        where TGrid : IGrid<TCell>
    {
        TGrid Apply(TGrid oldGrid);
    }
}