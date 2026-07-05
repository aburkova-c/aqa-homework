using TMS_1;

Console.WriteLine("What is your name?");
var name = Console.ReadLine();
if (string.IsNullOrEmpty(name))
{
    name = "Player";
}
var player = new Player(name);
var computer = new Player("Computer");

var game = new Game(player, computer, 5);
game.Play();

Console.WriteLine($"{player.Name}, your score is {player.Score}! :)");
    


// 4.1 Добавить конструкторы: Player должен принимать имя, GameResult — объекты ходов игрока и компьютера и текст результата, Game — игроков и количество раундов.
