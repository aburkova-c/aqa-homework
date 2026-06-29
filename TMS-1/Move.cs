namespace TMS_1;

public class Move

{
    public int Number { get; set; }
    public string Name { get; private set; } = string.Empty;

    public void ReadFromConsole()
    {
        var input = Console.ReadLine();
        if (int.TryParse(input, out var number))
        {
            Number = number;
            SetName();
        }
    }

    public void GenerateRandom()
    {
        var random = new Random();
        Number = random.Next(1, 4);
        SetName();
    }

    public bool IsValid()
    {
        return Number >= 1 && Number <= 3;
    }

    private void SetName()
    {
        Name = Number switch
        {
            1 => "Rock",
            2 => "Paper",
            3 => "Scissors",
            _ => string.Empty
        };
    }

}

// Описать класс хода Move со свойствами Number и Name.
// Добавить методы ReadFromConsole() для получения хода игрока, GenerateRandom() для случайного хода компьютера
// и IsValid() для проверки номера от 1 до 3.  