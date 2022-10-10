namespace Game_Of_Life_Kata;

public class Universe
{
    private readonly Cell[,] _cells;

    public Universe(Cell[,] cells)
    {
        _cells = cells ?? throw new ArgumentNullException(nameof(cells));
    }

    public Cell[,] NextGeneration()
    {
        var maxRows = _cells.GetLength(0);
        var maxColumns = _cells.GetLength(1);
        var result = new Cell[maxRows, maxColumns];

        for (int rowIndex = 0; rowIndex < maxRows; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex <= maxColumns - 1; columnIndex++)
            {
                var liveNeighbours = 0;

                if (columnIndex - 1 >= 0 && _cells[rowIndex, columnIndex - 1].CompareStatus(Status.Alive))
                    liveNeighbours++;

                if (columnIndex + 1 <= maxColumns - 1 && _cells[rowIndex, columnIndex + 1].CompareStatus(Status.Alive))
                    liveNeighbours++;

                result[rowIndex, columnIndex] = new Cell(Status.Dead);

                if(rowIndex -1 >= 0 && _cells[rowIndex-1, columnIndex].CompareStatus(Status.Alive))
                    liveNeighbours++;

                if (rowIndex + 1 <= maxRows - 1 && _cells[rowIndex+1, columnIndex].CompareStatus(Status.Alive))
                    liveNeighbours++;

                if (liveNeighbours == 2 && _cells[rowIndex, columnIndex].CompareStatus(Status.Alive))
                    result[rowIndex, columnIndex] = new Cell(Status.Alive);
            }
            
        }


        return result;
    }
}