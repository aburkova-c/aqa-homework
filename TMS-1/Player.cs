namespace TMS_1;

public class Player
{
    public string Name { get; set; }
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