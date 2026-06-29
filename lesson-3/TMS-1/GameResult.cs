namespace TMS_1;

public class GameResult
{
    public Move PlayerMove { get; set; }
    public Move ComputerMove { get; set; }
    public string ResultText { get; set; } = string.Empty;

    public void Print()
    {
        Console.WriteLine($"Player chose: {PlayerMove.Name}");
        Console.WriteLine($"Computer chose: {ComputerMove.Name}");
        Console.WriteLine($"Result: {ResultText}");
    }
}

// Описать класс результата раунда GameResult со свойствами для хода игрока, хода компьютера и текста результата.
// Добавить метод Print(), выводящий информацию о раунде.