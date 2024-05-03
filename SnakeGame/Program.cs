using SnakeGame;
using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        GameBoard gameBoard = new GameBoard(40, 20);
        gameBoard.StartGame();
    }
}
