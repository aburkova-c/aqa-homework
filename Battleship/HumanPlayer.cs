namespace Battleship;

class HumanPlayer : IPlayer
{
    public string Name { get; set; } = "User";

    private int _roundCount;

    public Shot? Shoot(Board board, Func<Position, bool> isAlreadyShot)
    {
         while (true)                                                                                                                          
      {                                                                                                                                     
          _roundCount++;                                                                                                                    
          if (!TryReadFromConsole("X", _roundCount, out var x)) continue;                                                                   
          if (!TryReadFromConsole("Y", _roundCount, out var y)) continue;                                                                   
                                                                                                                                            
          var position = new Position(x, y);                                                                                                
                                                                                                                                            
          if (!board.IsInside(position))                                                                                                    
          {                                                                                                                                 
              Console.WriteLine("Invalid shot position!");                                                                                  
              continue;                                                                                                                     
          }                 
          
          if (isAlreadyShot(position))                                                                                                      
          {                                                                                                                                 
              Console.WriteLine("Already shot there!");                                                                                     
              continue;                                                                                                                     
          }                                                                                                                                 
                                                                                                                                            
          return new Shot(position, board, board.FindShip(position));                                                                       
      }   
    }

    private bool TryReadFromConsole(string coordinateName, int roundCount, out int coordinate)
    {
        Console.WriteLine($"Input your {coordinateName} coordinate for round {roundCount}:");
        var input = Console.ReadLine();
        if (!int.TryParse(input, out coordinate))
        {
            Console.WriteLine("Invalid input");
            return false;
        }

        return true;
    }

    public void WriteName()
    {
        Console.WriteLine($"Player: {Name}");
    }
}
