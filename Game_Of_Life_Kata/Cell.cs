using System.Data.Common;

namespace Game_Of_Life_Kata;

public class Location : IEquatable<Location>
{
    private readonly int _row;
    private readonly int _column;

    public Location(int row, int column)
    {
        _row = row;
        _column = column;
    }

    public bool Equals(Location? other)
    {
        if(other == null) return false;

        return _row == other._row && _column == other._column;
    }
}

public class Cell : IEquatable<Cell>
{
    private readonly Status _status;
    private readonly Location _location;

    public Cell(Status status, Location location)
    {
        _status = status;
        _location = location;
    }

    public bool CompareStatus(Status status)
    {
        return _status == status;
    }

    public bool Equals(Cell? other)
    {
        if(other == null) return false;
        return _status == other._status && _location.Equals(other._location);
    }
}