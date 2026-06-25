using TMS_1;

var game = new Game(); // object of type (class) Game

game.RoundsToPlay = 5;
game.Play();

if (game.UserWon)
{
    Console.WriteLine("You won");
}
else
{
    Console.WriteLine("You lost");
}
