namespace GameOfLife.Models.GameModels
{
    using System.Collections;
    using System.Collections.Generic;

    public sealed class Game : Interfaces.IGame<Grid, Rules, Cell>
    {
        private readonly Rules _rules;



        public Grid Initial { get; }

        public static Game GameInstance => new(Grid.Default, Rules.Instance);



        private Game( Grid grid, Rules rules )
        {
            this._rules = rules;
            this.Initial = grid;
        }



        public static Game Create(Grid grid, Rules rules)
            => (grid | rules) is not null ? new(grid, rules)
                                          : System.NullReferenceException();

        public IEnumerator<Grid> GetEnumerator()
        {
            var current = Initial;
            while (true)
            {
                yield return current;
                current = _rules.Apply(current);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}