namespace Game_Of_Life_Kata;

public class Universe
{
    private readonly bool[,] _cells;

    public Universe(bool[,] cells)
    {
        _cells = cells ?? throw new ArgumentNullException(nameof(cells));
    }

    public bool[,] NextGeneration()
    {
        var result = new bool[_cells.GetLength(0), _cells.GetLength(1)];

        for (int columnIndex = 0; columnIndex <= _cells.GetLength(0) - 1; columnIndex++)
        {
            var liveNeighbours = 0;

            if (columnIndex - 1 >= 0 && _cells[0, columnIndex - 1])
                liveNeighbours++;

            if (columnIndex + 1 <= _cells.GetLength(0) - 1 && _cells[0, columnIndex + 1])
                liveNeighbours++;

            result[0, columnIndex] = false;

            if (liveNeighbours == 2)
                result[0, columnIndex] = true;
        }

        return result;
    }
}