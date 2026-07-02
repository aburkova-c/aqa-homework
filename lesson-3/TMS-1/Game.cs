namespace TMS_1;

class Game
{
    private int _roundsPlayed = 0;
    private int _roundsToPlay;

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
        ComputerWon = false;

        do
        {
            Console.WriteLine("1 - Rock");
            Console.WriteLine("2 - Paper");
            Console.WriteLine("3 - Scissors");
            Console.WriteLine("0 - Exit");

            _roundsPlayed++;

            var userMove = new Move();
            userMove.ReadFromConsole();

            if (userMove.Number == 0)
            {
                return;
            }

            if (!userMove.IsValid())
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            var computerMove = new Move();
            computerMove.GenerateRandom();

            Console.WriteLine($"You chose {userMove.Name}");
            Console.WriteLine($"Computer chose {computerMove.Name}");

            if (computerMove.Number == userMove.Number)
            {
                Console.WriteLine("Draw!");
            }
            else if (userMove.Number == 1 && computerMove.Number == 3 ||
                     userMove.Number == 2 && computerMove.Number == 1 ||
                     userMove.Number == 3 && computerMove.Number == 2)
            {
                UserWon = true;
                Console.WriteLine("You won this round!");
            }

            else
            {
                ComputerWon = true;
                Console.WriteLine("Computer won  this round!");
            }

        } while (_roundsPlayed < RoundsToPlay);
    }
}