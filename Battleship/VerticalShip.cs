namespace Battleship;

class VerticalShip : Ship
{
    public VerticalShip(Position position, int length) : base(position, length)
    {
    }

    public override bool IsOnPosition(Position position)
    {
        return position.X == Position.X && position.Y >= Position.Y && position.Y < Position.Y + Length;
    }

    public override Position EndPosition => new Position(Position.X, Position.Y + Length - 1);
}
