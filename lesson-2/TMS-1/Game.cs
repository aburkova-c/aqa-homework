class Game
{
    public void Start()
    {
        Console.WriteLine("Hello! this is Rock Paper Scissors.");
        Console.WriteLine("How many rounds do you want to play?");

        var roundCount = 0;

        while (true)
        {
            Console.WriteLine("Enter number of rounds (1-10)");

            var roundsInput = Console.ReadLine();

            if (!int.TryParse(roundsInput, out roundCount) ||
                roundCount < 1 || roundCount > 10)
            {
                Console.WriteLine("Select a number between 1 and 10");
                continue;
            }

            break;
        }

        Console.WriteLine("Enter your step");

        int gamesCounter = 0;
        int userWins = 0;
        int computerWins = 0;
        int draws = 0;

        var random = new Random();

        while (gamesCounter < roundCount)
        {
            Console.WriteLine($"Round {gamesCounter + 1} of {roundCount}");

            Console.WriteLine("1 - Rock");
            Console.WriteLine("2 - Paper");
            Console.WriteLine("3 - Scissors");
            Console.WriteLine("4 - Kolodec");
            Console.WriteLine("0 - Exit");

            var userInput = Console.ReadLine();

            int userChoice;

            if (!int.TryParse(userInput, out userChoice) ||
                userChoice < 0 || userChoice > 4)
            {
                Console.WriteLine("Invalid input, please try again");
                continue;
            }

            if (userChoice == 0)
            {
                return;
            }

            var computerChoice = random.Next(1, 5);

            string userChoiceString = userChoice switch
            {
                1 => "Rock",
                2 => "Paper",
                3 => "Scissors",
                _ => "Kolodec"
                
            };

            Console.WriteLine($"You chose {userChoiceString}");

            string computerChoiceString = computerChoice switch
            {
                1 => "Rock",
                2 => "Paper",
                3 => "Scissors",
                _ => "Kolodec"
            };

            Console.WriteLine($"Computer chose {computerChoiceString}");

            if (computerChoice == userChoice)
            {
                Console.WriteLine("Draw");
                draws++;
            }
            else if (
                (userChoice == 1 && computerChoice == 3) ||  // Rock beats Scissors
                (userChoice == 2 && computerChoice == 1) ||  // Paper beats Rock
                (userChoice == 2 && computerChoice == 4) ||  // Paper beats Kolodec
                (userChoice == 3 && computerChoice == 2) ||  // Scissors beats Paper
                (userChoice == 4 && computerChoice == 3) ||  // Kolodec beats Scissors
                (userChoice == 4 && computerChoice == 1)     // Kolodec beats Rock
            )
            {
                Console.WriteLine("You win");
                userWins++;
            }
            else
            {
                Console.WriteLine("You lose");
                computerWins++;
            }
            Console.WriteLine("--------------------");
            Console.WriteLine($"Score:");
            Console.WriteLine($"Player: {userWins}");
            Console.WriteLine($"Computer: {computerWins}");
            Console.WriteLine($"Draws: {draws}");
            Console.WriteLine("--------------------");
            gamesCounter++;
        }

        Console.WriteLine("Game over");
        Console.WriteLine($"Your wins: {userWins}");
        Console.WriteLine($"Computer wins: {computerWins}");
        Console.WriteLine($"Draws: {draws}");

        if (userWins > computerWins)
        {
            Console.WriteLine("🥳 You won the game 🥳 ");
        }
        else if (computerWins > userWins)
        {
            Console.WriteLine(" 🤖Computer won the game 🤖");
        }
        else
        {
            Console.WriteLine("Final result: draw 🍬");
        }
    }
}