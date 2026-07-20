namespace Battleship;

record Shot(Position Position, Board Board, Ship? Ship)                                                                                   
{                                                                                                                                         
    public ShootResult Result => Ship is null ? ShootResult.Miss : ShootResult.Hit;                                                       
} 
