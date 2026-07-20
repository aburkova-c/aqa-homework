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

    public override bool IntersectsWith(Ship otherShip)
    {
        for (var y = Position.Y; y < Position.Y + Length; y++)
        {
            var currentPosition = new Position(Position.X, y);

            if (otherShip.IsOnPosition(currentPosition))
                return true;
        }

        return false;
    }

    public override Position EndPosition => new Position(Position.X, Position.Y + Length - 1);
}
