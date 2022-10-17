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
        var newRow = new List<Cell>();

        for (var i = 0; i < maxColumns; i++)
            newRow.Add(new Cell(Status.Dead));

        var resultGrid = new List<List<Cell>>();

        for (var columnIndex = 1; columnIndex < maxColumns - 1; columnIndex++)
        {
            if (_cells[0, columnIndex - 1].CompareStatus(Status.Alive) &&
                _cells[0, columnIndex].CompareStatus(Status.Alive) &&
                _cells[0, columnIndex + 1].CompareStatus(Status.Alive))
                newRow[columnIndex] = new Cell(Status.Alive);
        }
        if (newRow.Any(x => x.CompareStatus(Status.Alive)))
            resultGrid.Add(newRow);

        for (int rowIndex = 0; rowIndex < maxRows; rowIndex++)
        {
            var cellRow = new List<Cell>();
            for (var i = 0; i < maxColumns; i++)
                cellRow.Add(new Cell(Status.Dead));

            for (int columnIndex = 0; columnIndex <= maxColumns - 1; columnIndex++)
            {
                var liveNeighbours = CountLiveNeighbours(rowIndex, columnIndex);

                if (liveNeighbours == 2 && _cells[rowIndex, columnIndex].CompareStatus(Status.Alive))
                    cellRow[columnIndex] = new Cell(Status.Alive);

                if (liveNeighbours == 3 && _cells[rowIndex, columnIndex].CompareStatus(Status.Dead))
                    cellRow[columnIndex] = new Cell(Status.Alive);
            }

            resultGrid.Add(cellRow);

        }

        newRow.Clear();
        for (var i = 0; i < maxColumns; i++)
            newRow.Add(new Cell(Status.Dead));

        for (var columnIndex = 1; columnIndex < maxColumns - 1; columnIndex++)
        {
            if (_cells[maxRows - 1, columnIndex - 1].CompareStatus(Status.Alive) &&
                _cells[maxRows - 1, columnIndex].CompareStatus(Status.Alive) &&
                _cells[maxRows - 1, columnIndex + 1].CompareStatus(Status.Alive))
                newRow[columnIndex] = new Cell(Status.Alive);
        }
        if (newRow.Any(x => x.CompareStatus(Status.Alive)))
            resultGrid.Add(newRow);


        var arrays = new Cell[resultGrid.Count, resultGrid[0].Count];
        for (int i = 0; i < resultGrid.Count; i++)
        {
            for (int j = 0; j < resultGrid[i].Count; j++)
            {
                arrays[i, j] = resultGrid[i][j];
            }
        }

        return arrays;
    }

    private int CountLiveNeighbours(int rowIndex, int columnIndex)
    {
        var liveNeighbours = 0;
        var maxColumns = _cells.GetLength(1);
        var maxRows = _cells.GetLength(0);

        // Check cell above and left
        if (rowIndex - 1 >= 0 && columnIndex - 1 >= 0 &&
            _cells[rowIndex - 1, columnIndex - 1].CompareStatus(Status.Alive))
            liveNeighbours++;

        // Check cell directly above
        if (rowIndex - 1 >= 0 && _cells[rowIndex - 1, columnIndex].CompareStatus(Status.Alive))
            liveNeighbours++;

        // Check cell above and right
        if (rowIndex - 1 >= 0 && columnIndex + 1 < maxColumns &&
            _cells[rowIndex - 1, columnIndex + 1].CompareStatus(Status.Alive))
            liveNeighbours++;

        // Check cell to the left
        if (columnIndex - 1 >= 0 && _cells[rowIndex, columnIndex - 1].CompareStatus(Status.Alive))
            liveNeighbours++;

        // Check cell to the right
        if (columnIndex + 1 < maxColumns && _cells[rowIndex, columnIndex + 1].CompareStatus(Status.Alive))
            liveNeighbours++;

        // Check cell below and left
        if (rowIndex + 1 < maxRows && columnIndex - 1 >= 0 &&
            _cells[rowIndex + 1, columnIndex - 1].CompareStatus(Status.Alive))
            liveNeighbours++;

        // Check cell directly below
        if (rowIndex + 1 <= maxRows - 1 && _cells[rowIndex + 1, columnIndex].CompareStatus(Status.Alive))
            liveNeighbours++;

        // Check cell below and right
        if (rowIndex + 1 < maxRows && columnIndex + 1 < maxColumns &&
            _cells[rowIndex + 1, columnIndex + 1].CompareStatus(Status.Alive))
            liveNeighbours++;

        return liveNeighbours;
    }
}