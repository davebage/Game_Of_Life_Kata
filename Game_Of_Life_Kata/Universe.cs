namespace Game_Of_Life_Kata;

public class Universe
{
    //private const int FIRSTROW = 0;
    //private const int FIRSTCOLUMN = 0;
    private readonly List<Cell> _cells;

    public Universe(List<Cell> cells)
    {
        _cells = cells ?? throw new ArgumentNullException(nameof(cells));
    }

    public int GetLiveNeighbours(Location cellLocation)
    {
        cellLocation.
    }

    //private void GenerateRow(List<List<Cell>> resultGrid, int rowIndex)
    //{
    //    var newRow = new List<Cell>();

    //    for (var i = 0; i < _cells.GetLength(1); i++)
    //        newRow.Add(new Cell(Status.Dead));

    //    for (var columnIndex = 1; columnIndex < _cells.GetLength(1) - 1; columnIndex++)
    //    {
    //        if (_cells[rowIndex, columnIndex - 1].CompareStatus(Status.Alive) &&
    //            _cells[rowIndex, columnIndex].CompareStatus(Status.Alive) &&
    //            _cells[rowIndex, columnIndex + 1].CompareStatus(Status.Alive))
    //            newRow[columnIndex] = new Cell(Status.Alive);
    //    }
    //    if (newRow.Any(x => x.CompareStatus(Status.Alive)))
    //        resultGrid.Insert(rowIndex, newRow);
    //}

    //private void GenerateColumn(List<List<Cell>> resultGrid, int columnIndex)
    //{
    //    var newColumn = new List<Cell>();
    //    for (var i = 0; i < resultGrid.Count; i++)
    //        newColumn.Add(new Cell(Status.Dead));

    //    for (var rowIndex = 1; rowIndex < _cells.GetLength(0) - 1; rowIndex++)
    //    {
    //        if (_cells[rowIndex - 1, columnIndex].CompareStatus(Status.Alive) &&
    //            _cells[rowIndex, columnIndex].CompareStatus(Status.Alive) &&
    //            _cells[rowIndex + 1, columnIndex].CompareStatus(Status.Alive))
    //            newColumn[rowIndex] = new Cell(Status.Alive);
    //    }

    //    if (newColumn.Any(x => x.CompareStatus(Status.Alive)))
    //    {
    //        for (int newColumnIndex = 0; newColumnIndex < resultGrid.Count; newColumnIndex++)
    //            resultGrid[newColumnIndex].Insert(columnIndex+1, newColumn[newColumnIndex]);
    //    }

    //}

    public List<Cell> NextGeneration()
    {
        var result = new List<Cell>();

        for (int cellCount = 0; cellCount < _cells.Count; cellCount++)
        {
            result.Add(new Cell(Status.Dead, new Location(0, cellCount)));
        }

        return result;
        //    var maxRows = _cells.GetLength(0);
        //    var maxColumns = _cells.GetLength(1);

        //    var resultGrid = new List<List<Cell>>();

        //    // Process main grid
        //    for (int rowIndex = 0; rowIndex < maxRows; rowIndex++)
        //    {
        //        var cellRow = new List<Cell>();
        //        for (var i = 0; i < maxColumns; i++)
        //            cellRow.Add(new Cell(Status.Dead));

        //        for (int columnIndex = 0; columnIndex <= maxColumns - 1; columnIndex++)
        //        {
        //            var liveNeighbours = CountLiveNeighbours(rowIndex, columnIndex);

        //            if (liveNeighbours == 2 && _cells[rowIndex, columnIndex].CompareStatus(Status.Alive))
        //                cellRow[columnIndex] = new Cell(Status.Alive);

        //            if (liveNeighbours == 3 && _cells[rowIndex, columnIndex].CompareStatus(Status.Dead))
        //                cellRow[columnIndex] = new Cell(Status.Alive);
        //        }

        //        resultGrid.Add(cellRow);

        //    }

        //    GenerateRow(resultGrid, FIRSTROW);
        //    GenerateRow(resultGrid, maxRows - 1);
        //    GenerateColumn(resultGrid, FIRSTCOLUMN);
        //    GenerateColumn(resultGrid, maxColumns - 1);
        //    return Transform(resultGrid);
    }

    //private Cell[,] Transform(List<List<Cell>> resultGrid)
    //{
    //    var universeCells = new Cell[resultGrid.Count, resultGrid[0].Count];
    //    for (int rowIndex = 0; rowIndex < resultGrid.Count; rowIndex++)
    //    {
    //        for (int columnIndex = 0; columnIndex < resultGrid[rowIndex].Count; columnIndex++)
    //        {
    //            universeCells[rowIndex, columnIndex] = resultGrid[rowIndex][columnIndex];
    //        }
    //    }

    //    return universeCells;
    //}

    //private int CountLiveNeighbours(int rowIndex, int columnIndex)
    //{
    //    var liveNeighbours = 0;
    //    var maxColumns = _cells.GetLength(1);
    //    var maxRows = _cells.GetLength(0);

    //    // Check cell above and left
    //    if (rowIndex - 1 >= 0 && columnIndex - 1 >= 0 &&
    //        _cells[rowIndex - 1, columnIndex - 1].CompareStatus(Status.Alive))
    //        liveNeighbours++;

    //    // Check cell directly above
    //    if (rowIndex - 1 >= 0 && _cells[rowIndex - 1, columnIndex].CompareStatus(Status.Alive))
    //        liveNeighbours++;

    //    // Check cell above and right
    //    if (rowIndex - 1 >= 0 && columnIndex + 1 < maxColumns &&
    //        _cells[rowIndex - 1, columnIndex + 1].CompareStatus(Status.Alive))
    //        liveNeighbours++;

    //    // Check cell to the left
    //    if (columnIndex - 1 >= 0 && _cells[rowIndex, columnIndex - 1].CompareStatus(Status.Alive))
    //        liveNeighbours++;

    //    // Check cell to the right
    //    if (columnIndex + 1 < maxColumns && _cells[rowIndex, columnIndex + 1].CompareStatus(Status.Alive))
    //        liveNeighbours++;

    //    // Check cell below and left
    //    if (rowIndex + 1 < maxRows && columnIndex - 1 >= 0 &&
    //        _cells[rowIndex + 1, columnIndex - 1].CompareStatus(Status.Alive))
    //        liveNeighbours++;

    //    // Check cell directly below
    //    if (rowIndex + 1 <= maxRows - 1 && _cells[rowIndex + 1, columnIndex].CompareStatus(Status.Alive))
    //        liveNeighbours++;

    //    // Check cell below and right
    //    if (rowIndex + 1 < maxRows && columnIndex + 1 < maxColumns &&
    //        _cells[rowIndex + 1, columnIndex + 1].CompareStatus(Status.Alive))
    //        liveNeighbours++;

    //    return liveNeighbours;
    //}
}