namespace Battleship;

class Board
{
    public int Rows { get; }
    public int Columns { get; }
    public Ship[] Ships { get; }

    public Board(int rows, int columns, Ship[] ships)
    {
        if (rows <= 0)
            throw new ArgumentOutOfRangeException(nameof(rows), rows, "Board rows count must be positive.");
        if (columns <= 0)
            throw new ArgumentOutOfRangeException(nameof(columns), columns, "Board columns count must be positive.");
        if (ships == null)
            throw new ArgumentNullException(nameof(ships));

        Rows = rows;
        Columns = columns;
        Ships = ships;

        foreach (var ship in ships)
        {
            if (!IsInside(ship.Position) || !IsInside(ship.EndPosition))
                throw new ArgumentException("Ship must be inside the board!");
        }
    }

    public bool IsInside(Position position)
    {
        return position.X >= 0 && position.X < Rows &&
               position.Y >= 0 && position.Y < Columns;
    }

    public bool HasShip(Position position)
    {
        return Ships.Any(ship => ship.IsOnPosition(position));
    }

    public Ship? FindShip(Position position)
    {
        return Ships.FirstOrDefault(ship => ship.IsOnPosition(position));
    }
}
