namespace Battleship;

class ComputerPlayer : IPlayer
{
    public Shot Shoot(Board board, Func<Position, bool> isAlreadyShot)                                                                        
    {                                                                                                                                         
        var random = new Random();                                                                                                            
        Position position;                                                                                                                    
        do                                                                                                                                    
        {                                                                                                                                     
            position = board.GeneratePosition(random);                                                                                        
        } while (isAlreadyShot(position));                                                                                                    
                                                                                                                                            
        return new Shot(position, board, board.FindShip(position));                                                                           
    } 

    public void WriteName()
    {
        Console.WriteLine("Robot");
    }
}
