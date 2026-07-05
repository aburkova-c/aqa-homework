namespace TMS_1;

public class Player
{
    public Player(string name)
    {
        Name = name;
    }
    
    public string Name { get; private set; }
    public int Score { get; private set; }

    public void AddPoint()
    {
        Score++;
    }
    
    public void RemovePoint()
    {
        Score--;
    }
    
}

// Описать класс игрока Player со свойствами Name и Score.
// Добавить методы AddPoint() для увеличения счёта и ResetScore() для обнуления.  
// 4.1 Добавить конструкторы: Player должен принимать имя