class Program
{
    public static void Main()
    {
        var shipPosition = new Position(2, 1);
        
        var ship = new Ship(shipPosition, 2);
        
        var board = new Board(5, 5, ship);

        var game = new Game();
        
        game.Play(board);
    }
}




class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Ship
{
    // Координаты самой левой верней палубы
    public Position Position { get; private set; }     
    public int Length { get; private set; }     
    
    public Ship(Position position, int length)
    {
        Position = position;
        Length = length;
    }
}

class Board
{
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    
    public Ship Ship { get; private set; }

    public Board(int rows, int columns, Ship ship)
    {
        Rows = rows;
        Columns = columns;
        Ship = ship;
    }

    public bool IsInside(Position position)
    {
        return position.X >= 0 && position.X < Rows && position.Y >= 0 && position.Y < Columns;
    }

    public bool HasShip(Position position)
    {
        return position.Y == Ship.Position.Y && position.X >= Ship.Position.X && position.X < Ship.Position.X + Ship.Length;
    }
}

class Game
{
    public void Play(Board board)
    {
        while (true)
        {
            Position shotPosition;
            
            Console.WriteLine("X Coordinate:");
            var xInput = Console.ReadLine();
            if (!int.TryParse(xInput, out var xPosition))
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            
            Console.WriteLine();
            
            Console.WriteLine("Y Coordinate:");
            var yInput = Console.ReadLine();
            if (!int.TryParse(yInput, out var yPosition))
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            
            shotPosition = new  Position(xPosition, yPosition);

            if (!board.IsInside(shotPosition))
            {
                Console.WriteLine("Invalid shot position!");
                continue;
            }

            if (board.HasShip(shotPosition))
            {
                Console.WriteLine("Hit!");
            }
            else
            {
                Console.WriteLine("Miss!");
            }
        }
    }
}

// Ship
// Board 
// Position
// Game

// Rows = 5

// 0 1 2 3 4 
// ------------X
// X X X X X 
// X X S S X   
// X X X X X 
// X X X X X 
// X X X X X 
// Y