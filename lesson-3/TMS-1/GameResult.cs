namespace TMS_1;

public class GameResult
{
    public GameResult(Move playerMove, Move computerMove, string resultText)
    {
        PlayerMove = playerMove;
        ComputerMove = computerMove;
        ResultText = resultText;
    }
    
    public Move PlayerMove { get; private set; }
    public Move ComputerMove { get; private set; }
    public string ResultText { get; private set; } = string.Empty;

    public void Print()
    {
        Console.WriteLine($"Player chose: {PlayerMove.Name}");
        Console.WriteLine($"Computer chose: {ComputerMove.Name}");
        Console.WriteLine($"Result: {ResultText}");
    }
    public void Print(int roundNumber)
    {
        Console.WriteLine($"Round: {roundNumber}");
        Print();
    }
}

// 3.4. Описать класс результата раунда GameResult со свойствами для хода игрока, хода компьютера и текста результата.
// Добавить метод Print(), выводящий информацию о раунде.
// 4.1 Добавить конструкторы: GameResult — объекты ходов игрока и компьютера и текст результата
// 4.6 Перегрузить GameResult.Print(): сохранить метод без параметров и добавить версию, принимающую номер раунда. Новая версия должна дополнительно выводить номер текущего раунда.