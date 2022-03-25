namespace GameOfLife.Models.Interfaces
{

    public interface IGame<TGrid, TRules, TCell> : System.Collections.Generic.IEnumerable<TGrid>
        where TGrid : IGrid<TCell>
        where TRules : IRules<TGrid, TCell>
    {
        TGrid Initial { get; }
    }
}

    
