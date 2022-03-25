namespace GameOfLife.Models.Interfaces
{
    public interface IGame<TGrid, TRules, TCell> : IEnumerable<TGrid>
        where TGrid : IGrid<ICell>
        where TRules : IRules<IGrid, ICell>
    {
        TGrid Initial { get; }
    }
}

    
