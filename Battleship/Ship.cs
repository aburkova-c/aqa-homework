namespace Battleship;

abstract class Ship
{
    // Координаты самой левой верхней палубы
    public Position Position { get; }
    public int Length { get; }
    private readonly HashSet<Position> _hits = new();

    protected Ship(Position position, int length)
    {
        if (length <= 0)
            throw new ArgumentOutOfRangeException(nameof(length), length, "Ship length must be positive");
        Position = position;
        Length = length;
    }

    public abstract bool IsOnPosition(Position position);
    public abstract bool IntersectsWith(Ship otherShip);
    public abstract Position EndPosition { get; }
    
    public void RegisterHit(Position position)                                                                                            
    {                                                                                                                                     
        if (!IsOnPosition(position))                                                                                                      
            throw new ArgumentException("Position is not on this ship.", nameof(position));                                               
        _hits.Add(position);                                                                                                              
    }                                                                                                                                     
                                                                                                                                            
    public bool IsSunk => _hits.Count >= Length;    
}
