namespace Battleship;

class HorizontalShip : Ship
{
    public HorizontalShip(Position position, int length) : base(position, length)
    {
    }

    public override bool IsOnPosition(Position position)
    {
        return position.Y == Position.Y && position.X >= Position.X && position.X < Position.X + Length;
    }

    public override Position EndPosition => new Position(Position.X + Length - 1, Position.Y);
}
