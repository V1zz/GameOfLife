namespace GameOfLife.Models.GameModels 
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; } 
        public Enums.CellStateEnum CellState { get; private set; }
    }
}