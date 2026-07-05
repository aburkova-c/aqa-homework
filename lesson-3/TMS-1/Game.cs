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
    private void PrintCurrentScore()
    {
        Console.WriteLine($"Score: {_player.Name}: {_player.Score} - {_computer.Name}: {_computer.Score}");
    }

    private void PrintFinalResult()
    {
        Console.WriteLine("Final score:");
        PrintCurrentScore();

        if (_player.Score > _computer.Score)
        {
            Console.WriteLine($"Winner: {_player.Name} 🥳");
        }
        else if (_computer.Score > _player.Score)
        {
            Console.WriteLine($"Winner: {_computer.Name} 🤖");
        }
        else
        {
            Console.WriteLine("Draw!");
        }
    }

    public void Play()
    {
        Console.WriteLine("This is Rock Paper Scissors.");
        Console.WriteLine("Enter your step:");

        while (_roundsToPlay > _roundsPlayed)
        {
            Console.WriteLine("1 - Rock");
            Console.WriteLine("2 - Paper");
            Console.WriteLine("3 - Scissors");

            var playerMove = new Move();
            playerMove.ReadFromConsole();
            
            if (!playerMove.IsValid())
            {
                Console.WriteLine($"Invalid move: {playerMove.Number}");
                continue;
            }
            
            _roundsPlayed++;

            var computerMove = new Move();
            computerMove.GenerateRandom();

            var result = GetRoundResult(playerMove, computerMove);
            result.Print(_roundsPlayed);
            PrintCurrentScore();
        }

        PrintFinalResult();

    }

   

    private GameResult GetRoundResult(Move playerMove, Move computerMove)
    {
        string resultText;
        if (playerMove.Number == computerMove.Number)
        {
            resultText = "Draw!";
        }
        else if (playerMove.Number == 1 && computerMove.Number == 3 ||
                 playerMove.Number == 2 && computerMove.Number == 1 ||
                 playerMove.Number == 3 && computerMove.Number == 2)
        {
            resultText = "Player Won!";
            _player.AddPoint();
        }
        else
        {
            resultText = "Computer Won!";
            _computer.AddPoint();
        }
        return new GameResult(playerMove, computerMove, resultText);
    }

}

//  3. В Game.Play() заменить числовые переменные ходов объектами Move; получать значения ходов через методы класса Move
// 4.1 Game — игроков и количество раундов
// 4.3 Если Move.IsValid() возвращает false (во время проверки в методе game.Play()), ход не засчитывается: ход компьютера не генерируется, счёт и номер раунда не изменяются.
// 4.5 Добавить в Game отдельный метод, который принимает ходы игрока и компьютера, определяет результат раунда, начисляет очко победителю и возвращает GameResult.
// 4.7 Изменить метод Game.Play(), который запускает игру на заданное количество раундов, переданное в конструктор. Ход игрока получать через ReadFromConsole(), ход компьютера — через GenerateRandom(). И убрали поддержку 0
// 4.8 8. После каждого раунда выводить его номер, оба хода, результат и текущий счёт. После последнего раунда вывести итоговый счёт и имя победителя либо сообщение о ничьей.