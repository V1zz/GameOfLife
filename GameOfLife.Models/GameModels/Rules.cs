namespace GameOfLife.Models.GameModels
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Rules : Interfaces.IRules<Grid, Cell>
    {
        public static Rules Instance => new();



        public Grid Apply (Grid oldGrid)
        {
            var newGrid = new Cell[oldGrid.RowsCount, oldGrid.ColumnsCount];

            for (int row = 0; row < oldGrid.RowsCount; row++)
                for (int col = 0; col < oldGrid.ColumnsCount; col++)
                    newGrid[row, col] = CalculateCellStatus(oldGrid, row, col);

            return Grid.Create(newGrid);
        }


        private Cell CalculateCellStatus( Grid current, 
                                          int row,
                                          int col )
        {
            // get all neighbours
            var cellNeighbours = GetCellNeighbours( current, row, col );

            // get alive cells from neighbours
            var aliveCellNeighboursCount = cellNeighbours.Count(x => x == Cell.CellState.Alive);

            // get current cell
            var currentCell = current.Grid[row, col];

            // get result
            var newCell = currentCell switch
            {
                Cell.CellState.Alive when aliveCellNeighboursCount == 2 
                                       || aliveCellNeighboursCount == 3 => Cell.CellState.Alive,

                Cell.CellState.Dead when aliveCellNeighboursCount == 3 => Cell.CellState.Alive,

                _ => Cell.CellState.Dead
            };

            return newCell;
        }

        private IEnumerable<Cell> GetCellNeighbours ( Grid current
                                                  int row,
                                                  int col)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    if ((i && j) == 0) continue;

                    var nRow = Normalize(row + i, current.RowsCount);
                    var nCol = Normalize(col + j, current.ColumnsCount);

                    yield return current.Grid[nRow, nCol];
                }
            }
        }

        private int Normalize(int current, int total)
            =>
                (current + total) % total;
    }
}

