namespace Battleship;

class Game
{
    private readonly IPlayer _human = new HumanPlayer();
    private readonly IPlayer _computer = new ComputerPlayer();

    public int UserHitCount { get; private set; }
    public int ComputerHitCount { get; private set; }

    public List<Shot> Shots { get; } = new List<Shot>();

    private bool AlreadyShot(Board board, Position position)
    {
        return Shots.Any(shot => shot.Board == board && shot.Position.Equals(position)); 
    }

    public void Play(Board board)
    {
        var opponentBoard = GenerateOpponentBoard(board);

        while (true)
        {
            Shot? userShot;
            try
            {
                userShot = _human.Shoot(opponentBoard, position => AlreadyShot(opponentBoard, position));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            catch (ShotPositionOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            if (userShot == null)
                continue;

            Shots.Add(userShot);                                                                                                                
            userShot.Ship?.RegisterHit(userShot.Position);                                                                                      
            Console.WriteLine($"User: {userShot.Position.X}, Y: {userShot.Position.Y}");   
            
            PrintResult(userShot.Result, "User");
            if (userShot.Ship is not null)
                UserHitCount++;

            var computerShot = _computer.Shoot(board, position => AlreadyShot(board, position))!;
            Shots.Add(computerShot);                                                                                                            
            computerShot.Ship?.RegisterHit(computerShot.Position);                                                                              
            Console.WriteLine($"Computer shoots at X = {computerShot.Position.X}, Y = {computerShot.Position.Y}");      

            PrintResult(computerShot.Result, "Computer");
            if (computerShot.Ship is not null)
                ComputerHitCount++;

            Console.WriteLine($"Score: User = {UserHitCount}, Computer = {ComputerHitCount}");

            PrintStatistics(board);
        }
    }

    private static void PrintResult(ShootResult result, string shooterName)
    {
        switch (result)
        {
            case ShootResult.Hit:
                Console.WriteLine($"{shooterName} Hit!");
                break;
            case ShootResult.Miss:
                Console.WriteLine($"{shooterName} Missed!");
                break;
            case ShootResult.InvalidShot:
                Console.WriteLine($"{shooterName} made an invalid shot!");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(result));
        }
    }

    private void PrintStatistics(Board board)
    {
        var groupsByBoard = Shots.GroupBy(s => s.Board);
        foreach (var group in groupsByBoard)
        {
            var totalShots = group.Count();
            var hits = group.Count(s => s.Ship != null);
            var boardName = group.Key == board ? "playerBoard" : "computerBoard";
            var missedHits = group.Count(s => s.Ship == null);
            var missedAtLeastOnce = group.Any(s => s.Ship == null);
            var firstHitShot = group.FirstOrDefault(s => s.Ship != null);
            var allHitPositions = group.Where(s => s.Ship != null).Select(s => s.Position);

            if (firstHitShot == null)                                                                                                           
            {                                                                                                                                   
                Console.WriteLine($"{boardName}: waiting for the first hit!");                                                                  
            }                                                                                                                                   
            else                                                                                                                                
            {                                                                                                                                   
                Console.WriteLine($"{boardName}: first hit shot: X = {firstHitShot.Position.X}, Y = {firstHitShot.Position.Y}");                
            }  

            var hitsCoordinatesText = string.Join(", ", allHitPositions.Select(p => $"({p.X},{p.Y})"));
            Console.WriteLine(
                $"Statistics: Total Shots: {totalShots}, Hits: {hits}, MissedHits: {missedHits}, Board Name: {boardName}, Missed once: {missedAtLeastOnce}, All hits: {hitsCoordinatesText}");
        }
    }

    private Board GenerateOpponentBoard(Board playerBoard)
    {
        var random = new Random();
        var isHorizontal = random.Next(2) == 0;

        Ship ship;
        if (isHorizontal)
        {
            var shipLength = random.Next(1, playerBoard.Rows + 1);
            var x = random.Next(0, playerBoard.Rows - shipLength + 1);
            var y = random.Next(0, playerBoard.Columns);
            ship = new HorizontalShip(new Position(x, y), shipLength);
        }
        else
        {
            var shipLength = random.Next(1, playerBoard.Columns + 1);
            var x = random.Next(0, playerBoard.Rows);
            var y = random.Next(0, playerBoard.Columns - shipLength + 1);
            ship = new VerticalShip(new Position(x, y), shipLength);
        }

        return new Board(playerBoard.Rows, playerBoard.Columns, new[] { ship });
    }
}
