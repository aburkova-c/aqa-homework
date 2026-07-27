namespace Battleship;

class Program
{
    public static void Main()
    {
        try
        {
            var board = new Board(5, 5, new Ship[]
            {
                new HorizontalShip(new Position(1, 1), 2),
                new VerticalShip(new Position(2, 3), 2)
            });

            var game = new Game();

            game.Play(board);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
