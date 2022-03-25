namespace GameOfLife.Models.GameModels
{
    using System.Collections;
    using System.Collections.Generic;

    public sealed class Grid : Interfaces.IGrid<Cell>
    {
        public Cell[,] Grid { get; }


        public int RowsCount => Grid.GetLength(0);

        public int ColumnsCount => Grid.GetLength(1);


        public Grid Instance => new(new Cell[25, 25]);



        private Grid(Cell[,] grid)
        {
            this.Grid = grid;
        }



        public static Grid Create(Cell[,] grid) => grid != null ? new(grid) 
                                                                : System.NullReferenceException(nameof(grid);

        public IEnumerator<Cell> GetEnumerator()
        {
            for (int row = 0; row < RowsCount; row++)
                for (int col = 0; col < ColumnsCount; col++)
                    yield return Grid[row, col];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}