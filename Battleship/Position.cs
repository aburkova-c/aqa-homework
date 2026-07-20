namespace Battleship;

readonly struct Position 
{
    public int X { get; }
    public int Y { get; }

    public Position(int x, int y)
    {
        if (x < 0)
            throw new ArgumentOutOfRangeException(nameof(x), x, "X cannot be negative");
        if (y < 0)
            throw new ArgumentOutOfRangeException(nameof(y), y, "Y cannot be negative");
        X = x;
        Y = y;
    }
    public override bool Equals(object? obj) => obj is Position other && X == other.X && Y == other.Y;                                    
    public override int GetHashCode() => HashCode.Combine(X, Y);                                                                          
    public override string ToString() => $"({X}, {Y})";  
}
