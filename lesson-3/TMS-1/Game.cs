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

        do
        {
            Console.WriteLine("1 - Rock");
            Console.WriteLine("2 - Paper");
            Console.WriteLine("3 - Scissors");
            Console.WriteLine("0 - Exit");

            _roundsPlayed++;

            var userInput = Console.ReadLine(); // "5"

            int userChoice; // there is no value

            // parse user input = string into int 
            // put result to out result param
            // return if parse was successful

            if (!int.TryParse(userInput, out userChoice) || !(userChoice >= 0 && userChoice <= 3))
            {
                Console.WriteLine(userChoice);
                Console.WriteLine("Invalid input");
                continue;
            }

            if (userChoice == 0)
            {
                return;
            }

            var random = new Random();
            var computerChoice = random.Next(1, 4); // generate random number 1-3

            string userChoiceString;
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Rock");
                    userChoiceString = "Rock";
                    break;
                case 2:
                    userChoiceString = "Paper";
                    break;
                default:
                    userChoiceString = "Scissors";
                    break;
            }

            Console.WriteLine($"You chose {userChoiceString}");

            string computerChoiceString = computerChoice switch { 1 => "Rock", 2 => "Paper", _ => "Scissors" };

            Console.WriteLine($"Computer chose {computerChoiceString}");

            if (computerChoice == userChoice)
            {
            }
            else if (userChoice == 1 && computerChoice == 3 || userChoice == 2 && computerChoice == 1 ||
                     userChoice == 3 && computerChoice == 2)
            {
                UserWon = true;
            }
        } while (_roundsPlayed < RoundsToPlay);
    }
}