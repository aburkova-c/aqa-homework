using TMS_1;

var player = new Player();
Console.WriteLine("What is your name?");
player.Name = Console.ReadLine();
if (string.IsNullOrEmpty(player.Name))
{
    player.Name = "Player";
}
Console.WriteLine($"Hello, {player.Name}! :)");

var game = new Game(); // object of type (class) Game
game.RoundsToPlay = 5;
game.Play();

if (game.UserWon)
{
    Console.WriteLine("You won!");
    player.AddPoint();
}
else
{
    Console.WriteLine("You lost");
}
Console.WriteLine($"{player.Name}, your score is {player.Score}! :)");