namespace TMS_1;

class Game
{
    private Player _player;
    private Player _computer;
    private int _roundsToPlay;
    private int _roundsPlayed;

    public Game(Player player, Player computer, int roundsToPlay)
    {
        _player = player;
        _computer = computer;
        _roundsToPlay =  roundsToPlay;
    }
    
    public int RoundsToPlay
    {
        get { return _roundsToPlay; }
        set
        {
            if (value > 0 && value < 100)
            {
                _roundsToPlay = value;
            }
        }
    }

    public bool UserWon { get; private set; }

    public bool ComputerWon { get; private set; }


    public void Play()
    {
        Console.WriteLine("This is Rock Paper Scissors.");
        Console.WriteLine("Enter your step:");

        UserWon = false;

        do
        {
            Console.WriteLine("1 - Rock");
            Console.WriteLine("2 - Paper");
            Console.WriteLine("3 - Scissors");
            Console.WriteLine("0 - Exit");

            _roundsPlayed++;

            var playerMove = new Move();
            playerMove.ReadFromConsole();

            if (playerMove.Number == 0)
            {
                return;
            }

            if (!playerMove.IsValid())
            {
                Console.WriteLine($"Invalid move: {playerMove}");
                continue;
            }



            var computerMove = new Move();
            computerMove.GenerateRandom();
            Console.WriteLine($"You chose: {playerMove.Name}");
            Console.WriteLine($"Computer chose: {computerMove.Name}");

            if (computerMove.Number == playerMove.Number)
            {
            }
            else if (playerMove.Number == 1 && computerMove.Number == 3 ||
                     playerMove.Number == 2 && computerMove.Number == 1 ||
                     playerMove.Number == 3 && computerMove.Number == 2)
            {
                UserWon = true;
            }
        } while (_roundsPlayed < RoundsToPlay);
    }
}

//  3. В Game.Play() заменить числовые переменные ходов объектами Move; получать значения ходов через методы класса Move
// 4.1 Game — игроков и количество раундов