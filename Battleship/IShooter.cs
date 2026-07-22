namespace Battleship;

interface IShooter
{
    Shot? Shoot (Board board, Func<Position, bool> isAlreadyShot);
}
