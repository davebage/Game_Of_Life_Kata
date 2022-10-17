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

        
        
        // START - Add new top row
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

        // Process main grid
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

        // START - Add new bottom row
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



        // START - Add new left column
        var newColumn = new List<Cell>();
        for (var i = 0; i < resultGrid.Count; i++)
            newColumn.Add(new Cell(Status.Dead));

        for (var rowIndex = 1; rowIndex < maxRows - 1; rowIndex++)
        {
            if (_cells[rowIndex - 1, 0].CompareStatus(Status.Alive) &&
               _cells[rowIndex, 0].CompareStatus(Status.Alive) &&
               _cells[rowIndex + 1, 0].CompareStatus(Status.Alive))
                newColumn[rowIndex] = new Cell(Status.Alive);
        }

        if (newColumn.Any(x => x.CompareStatus(Status.Alive)))
        {
            for(int newColumnIndex = 0; newColumnIndex < resultGrid.Count; newColumnIndex++)
                resultGrid[newColumnIndex].Insert(0, newColumn[newColumnIndex]);
        }

        newColumn.Clear();
        for (var i = 0; i < resultGrid.Count; i++)
            newColumn.Add(new Cell(Status.Dead));

        for (var rowIndex = 1; rowIndex < maxRows - 1; rowIndex++)
        {
            if (_cells[rowIndex - 1, maxColumns-1].CompareStatus(Status.Alive) &&
                _cells[rowIndex, maxColumns-1].CompareStatus(Status.Alive) &&
                _cells[rowIndex + 1, maxColumns-1].CompareStatus(Status.Alive))
                newColumn[rowIndex] = new Cell(Status.Alive);
        }

        if (newColumn.Any(x => x.CompareStatus(Status.Alive)))
        {
            for (int newColumnIndex = 0; newColumnIndex < resultGrid.Count; newColumnIndex++)
                resultGrid[newColumnIndex].Add(newColumn[newColumnIndex]);
        }

        return Transform(resultGrid);
    }

    private Cell[,] Transform(List<List<Cell>> resultGrid)
    {
        var universeCells = new Cell[resultGrid.Count, resultGrid[0].Count];
        for (int rowIndex = 0; rowIndex < resultGrid.Count; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < resultGrid[rowIndex].Count; columnIndex++)
            {
                universeCells[rowIndex, columnIndex] = resultGrid[rowIndex][columnIndex];
            }
        }

        return universeCells;
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