using System;
using System.Collections.Generic;
using System.Numerics;
using Galaxy;
using Spectre.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        Game game = new Game();
        game.InitializeGame();
        game.RunGameLoop();
    }
}