namespace TMS_1;

public class Move

{
    public int Number { get; set; }

    public string Name => Number switch
    {
        1 => "Rock",
        2 => "Paper",
        3 => "Scissors",
        _ => string.Empty
    };
    

    public void ReadFromConsole()
    {
        var input = Console.ReadLine();
        if (int.TryParse(input, out var number))
        {
            Number = number;
        }
    }

    public void GenerateRandom()
    {
        var random = new Random();
        Number = random.Next(1, 4);
    }

    public bool IsValid(int min = 1, int max = 3)
    {
        return Number >= min && Number <= max;
    }


}

// 3.Описать класс хода Move со свойствами Number и Name.
// Добавить методы ReadFromConsole() для получения хода игрока, GenerateRandom() для случайного хода компьютера и IsValid() для проверки номера от 1 до 3.  
// 4.2 Метод Move.IsValid() должен поддерживать проверку произвольного диапазона. По умолчанию допустимыми считать значения от 1 до 3 (если в исходном коде уже реализован "Колодец", то до 4). Использовать параметры со значениями по умолчанию.
// 4.4 Сделать свойство Name класса Move вычисляемым, используя switch expression.
