namespace Game_Of_Life_Kata;

public class Cell : IEquatable<Cell>
{
    private readonly Status _status;

    public Cell(Status status)
    {
        _status = status;
    }

    public bool CompareStatus(Status status)
    {
        return _status == status;
    }

    public bool Equals(Cell? other)
    {
        if(other == null) return false;
        return _status == other._status;
    }
}