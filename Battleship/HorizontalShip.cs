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

    public override bool IntersectsWith(Ship otherShip)
    {
        for (var x = Position.X; x < Position.X + Length; x++)
        {
            var currentPosition = new Position(x, Position.Y);
            if (otherShip.IsOnPosition(currentPosition))
                return true;
        }

        return false;
    }

    public override Position EndPosition => new Position(Position.X + Length - 1, Position.Y);
}
