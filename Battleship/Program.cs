class Program
{
    public static void Main()
    {
        try
        {
            var shipPosition = new Position(2, 1);
            var ship = new Ship(shipPosition, 2); //x123234
            var board = new Board(5, 5, ship);
            var game = new Game();
            game.Play(board);
        }
        
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        } 

        try
        {
            var badShip = new Ship(new Position(0, 0), -1);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Ok, here is the test-error message: {e.Message}");
        }
    }
}


class Position
{
    public int X { get; set; }
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
}

class Ship
{
    // Координаты самой левой верней палубы
    public Position Position { get; } //null
    public int Length { get; } //12

    public Ship(Position position, int length)
    {
        if (position == null)
            throw new ArgumentNullException(nameof(position));
        if (length <= 0)
            throw new ArgumentOutOfRangeException(nameof(length), length, "Ship length must be positive");
        
        Position = position;
        Length = length;
    }
}

class Board
{
    public int Rows { get; }
    public int Columns { get; }
    public Ship Ship { get; }

    public Board(int rows, int columns, Ship ship)
    {
       if (rows <= 0)
           throw new ArgumentOutOfRangeException(nameof(rows), rows, "Board rows count must be positive.");
       if (columns <= 0)
           throw new ArgumentOutOfRangeException(nameof(columns), columns, "Board columns count must be positive.");
       if  (ship == null)
           throw new ArgumentNullException(nameof(ship));
       
        Rows = rows;
        Columns = columns;
        Ship = ship;
        
        var shipStart = ship.Position;
        var shipEnd = new Position(ship.Position.X + ship.Length - 1, ship.Position.Y);
        
        if (!IsInside(shipStart) || !IsInside(shipEnd))
            throw new ArgumentException("Ship must be inside the board!");
    }

    public bool IsInside(Position position)
    {
        return position.X >= 0 && position.X < Rows &&
               position.Y >= 0 && position.Y < Columns;
    }

    public bool HasShip(Position position)
    {
        return position.Y == Ship.Position.Y &&
               position.X >= Ship.Position.X &&
               position.X < Ship.Position.X + Ship.Length;
    }

    public Ship? FindShip(Position position)
    {
        if (HasShip(position))
            return Ship;
        return null;
    }
}

class Shot
{
    public Position Position { get; }
    public Board Board { get; }
    public Ship? Ship { get; }

    public Shot(Position position, Board board, Ship? ship)
    {
        if (board == null)
            throw new ArgumentNullException(nameof(board));
        if (position == null)
            throw new ArgumentNullException(nameof(position));
        Position = position;
        Board = board;
        Ship = ship;
    }
}

class Game
{
    public int UserHitCount { get; private set; }
    public int ComputerHitCount { get; private set; }

    public List<Shot> Shots { get; } = new List<Shot>();

    private bool AlreadyShot(Board board, Position position)
    {
        return Shots.Any(shot => shot.Board == board && shot.Position.X == position.X && shot.Position.Y == position.Y);
    }
   
    private Shot MakeShot(Board board, Position position)   
    {
        if (AlreadyShot(board, position))
        {
            throw new InvalidOperationException("Already shot a shot!");
        }  
        
        var hitShip = board.FindShip(position);
        var shot = new Shot(position, board, hitShip);
        Shots.Add(shot);
        return shot;
    }

public void Play(Board board)
    {
        var opponentBoard = GenerateOpponentBoard(board);
        var random = new Random();
        var roundCount = 0;


        while (true)
        {
            roundCount++;
            if (!TryReadFromConsole("X", roundCount, out var xPosition))
                continue;

            Console.WriteLine();

            if (!TryReadFromConsole("Y", roundCount, out var yPosition))
                continue;

            Position shootPosition;
            try
            {
                shootPosition = new Position(xPosition, yPosition);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            if (!opponentBoard.IsInside(shootPosition))
            {
                Console.WriteLine("Invalid shoot position!");
                continue;
            }

            Shot userShot;
            try
            {
                userShot = MakeShot(opponentBoard, shootPosition);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            Console.WriteLine($"User: {userShot.Position.X}, Y: {userShot.Position.Y}");
            
            if (userShot.Ship is null)
            {
                Console.WriteLine("User missed!");
            }
            else
            {
                Console.WriteLine("User Hit!");
                UserHitCount++;
            }

            Position computerShootPosition;
            do
            {
                var computerX = random.Next(0, board.Rows);
                var computerY = random.Next(0, board.Columns);
                computerShootPosition = new Position(computerX, computerY);
            } while (
                AlreadyShot(board, computerShootPosition));

            Console.WriteLine($"Computer shoots at X = {computerShootPosition.X}, Y = {computerShootPosition.Y}");

            var computerShot = MakeShot(board, computerShootPosition);
            
            if (computerShot.Ship is null)
            {
                Console.WriteLine("Computer Missed!");
            }
            else
            {
                Console.WriteLine("Computer Hit!");
                ComputerHitCount++;
            }
            
            Console.WriteLine($"Score: User = {UserHitCount}, Computer = {ComputerHitCount}");
            
            var groupsByBoard = Shots.GroupBy(s => s.Board);
            foreach (var group in  groupsByBoard)
            {
                var totalShots = group.Count();
                var hits = group.Count(s => s.Ship != null);
                var boardName = group.Key == board ? "playerBoard" : "computerBoard"  ;
                var missedhits = group.Count(s => s.Ship == null);
                var ifMissOnce = group.Any(s => s.Ship == null);
                var firstAccessShoot = group.FirstOrDefault(s => s.Ship != null);
                var listOfAllHits = group.Where(s => s.Ship != null).Select(s => s.Position );
                if (firstAccessShoot == null)
                {
                    Console.WriteLine("We are waiting for your access shoot!");
                }
                else
                {
                    Console.WriteLine($"First access Shoot: X = {firstAccessShoot.Position.X}, Y = {firstAccessShoot.Position.Y}");
                }

                var hitsCoordinatesText = string.Join(", ", listOfAllHits.Select(p => $"({p.X},{p.Y})"));  
                Console.WriteLine(
                    $"Statistics: Total Shoots: {totalShots},  Hits: {hits}, MissedHits: {missedhits}, Board Name: {boardName}, Missed once: {ifMissOnce}, All hits: {hitsCoordinatesText}");
            }
        }
        
    }

    private Board GenerateOpponentBoard(Board playerBoard)
    {
        var random = new Random();
        var shipLength = random.Next(1, playerBoard.Rows + 1);

        var x = random.Next(0, playerBoard.Rows - shipLength + 1);
        var y = random.Next(0, playerBoard.Columns);

        var shipPosition = new Position(x, y);
        var ship = new Ship(shipPosition, shipLength);

        return new Board(playerBoard.Rows, playerBoard.Columns, ship);

    }


private bool TryReadFromConsole(string coordinateName, int roundCount, out int coordinate)
    {
        Console.WriteLine($"Input your {coordinateName} coordinate for round {roundCount}:");
        var input = Console.ReadLine();
        if (!int.TryParse(input, out coordinate))
        {
            Console.WriteLine("Invalid input");
            return false;
        }
        
        return true;
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