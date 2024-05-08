using System;
using System.Collections.Generic;
using Galaxy;
using Spectre.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        /*
        // Creating a list of crew members
        List<Crew> crews = new List<Crew>
        {
            new Crew("Captain", 1),
            new Crew("Engineer", 5),
            new Crew("Pilot", 2)
        };

        // Creating a new spaceship object
        SpaceShip spaceShip = new SpaceShip("F16", "Fighter", crews, 100, 100, 100, 100, 100, "Attack");

        // Displaying information about the spaceship
        spaceShip.DisplaySpaceShipInfo();
        */
        Game game = new Game();
        game.InitializeGame();
        game.RunGameLoop();
    }
}

public class Game
{
    private List<Planet> planets = new List<Planet>();
    private List<Player> players = new List<Player>();
    private bool gameRunning = true;
    private int spaceSize = 20;
    private char[,] space;
    private Planet[,] planetPosition;
    private Player[,] playerPosition;
    private ConsoleColor[] playerColors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White };


    public Game()
    {
        space = new char[spaceSize, spaceSize];
        planetPosition = new Planet[spaceSize, spaceSize];
        playerPosition = new Player[spaceSize, spaceSize];
        ClearSpace();
    }
    public void InitializeGame()
    {
        int playerCount = AskPlayerCount();
        for (int i = 0; i < playerCount; i++)
        {
            string playerName = AnsiConsole.Ask<string>($"What is the [green]name[/] of player [bold]{i + 1}[/]?");
            var player = new Player(playerName, 100, 100, playerColors[i % playerColors.Length]);
            players.Add(player);
            UpdateSpace();  // Update grid with all player positions
            DisplayPlayerStatus(player);
        }

        for (int i = 0; i < playerCount * 2; i++)
        {
            var planet = new Planet("planet" + (i + 1), spaceSize);
            planets.Add(planet);
            UpdateSpace();  // Update grid with all planet positions
            // DisplayPlanetStatus(planet);
        }
        DisplaySpace();  // Display updated space
    }

    public void ClearSpace()
    {
        for (int i = 0; i < spaceSize; i++)
        {
            for (int j = 0; j < spaceSize; j++)
            {
                space[i, j] = '.';
                planetPosition[i, j] = null;  // Clear planet references
                playerPosition[i, j] = null;  // Clear player references
            }
        }
    }

    private void UpdateSpace()
    {
        ClearSpace();  // Clear previous positions
        foreach (var planet in planets)
        {
            space[(int)planet.Position.X, (int)planet.Position.Y] = '@';  // Represent planet with '@'
            planetPosition[(int)planet.Position.X, (int)planet.Position.Y] = planet;  // Reference player in space
        }

        foreach (var player in players)
        {
            if (player.IsAlive)
            {
                space[(int)player.Position.X, (int)player.Position.Y] = 'P';  // Represent player with 'P'
                playerPosition[(int)player.Position.X, (int)player.Position.Y] = player;  // Reference player in space
            }
        }
    }

    private void DisplaySpace()
    {
        for (int i = 0; i < spaceSize; i++)
        {
            for (int j = 0; j < spaceSize; j++)
            {
                if (playerPosition[i, j] != null)
                {
                    Console.ForegroundColor = playerPosition[i, j].Color;  // Set player specific color
                }
                if (planetPosition[i, j] != null)
                {
                    Console.ForegroundColor = planetPosition[i, j].Color;  // Set planet specific color
                }
                Console.Write(space[i, j] + " ");
                Console.ResetColor();  // Reset color for other cells
            }
            Console.WriteLine();
        }
    }

    private int AskPlayerCount()
    {
        return AnsiConsole.Prompt(
        new TextPrompt<int>("How many players will play the game?")
        .DefaultValue(2)
        .PromptStyle("green")
        .ValidationErrorMessage("[red]That's not a valid count[/]")
        .Validate(age =>
        {
            return age switch
            {
                <= 1 => ValidationResult.Error("[red]There must at least be 2 players[/]"),
                >= 6 => ValidationResult.Error("[red]There must at most be 5 players[/]"),
                _ => ValidationResult.Success(),
            };
        }));
    }

    private void DisplayPlayerStatus(Player player)
    {
        Console.WriteLine("------------ PLAYER STATUS -------------");
        Console.ForegroundColor = player.Color;
        //Console.WriteLine($"[{player.Color.ToString().ToLower()}]{player.Name} is located at [{player.Position.X},{player.Position.Y}].[/]");
        Console.WriteLine($"{player.Name} is located at [{player.Position.X},{player.Position.Y}].");
        Console.ResetColor();  // Reset text color to default
        Console.WriteLine("-------------- GAME GRID ---------------");
        DisplaySpace();  // Display the updated game grid
        Console.WriteLine("----------------------------------------");
    }

    public void RunGameLoop()
    {
        while (gameRunning)
        {
            foreach (var player in players)
            {
                if (!player.IsAlive) continue;

                // Ask for the user's favorite fruit
                var input = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title($"[{player.Color.ToString().ToLower()}]{player.Name}, What do you want to do?[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(new[]
                    {
                        "Send Fleet", "Call Back Fleet", "Fleet Options",
                    }));

                switch (input)
                {
                    case "Send Fleet":
                        {
                            Planet target = SelectTargetPlanet(player);
                            if (target.OccupiedBy == null || target.OccupiedBy == player)
                            {
                                SendFleet(player, target);
                            }
                            break;
                        }
                    case "Call Back Fleet":
                        {
                            Planet target = SelectTargetPlanet(player);
                            CallBackFleet(player, target);
                            break;
                        }

                    case "Fleet Options":
                        {
                            // Work in progress
                            break;
                        }
                    default: break;
                }
                UpdateSpace();  // Update space after fleet action
                DisplaySpace();  // Display space  
            }
            // var livePlayers = players.Where(player => player.IsAlive).ToList();
            // if (livePlayers.Count == 1)
            // {
            //     Console.WriteLine($"{livePlayers[0].Name} is the last survivor and wins the game!");
            //     gameRunning = false;
            // }
        }
    }

    private Planet SelectTargetPlanet(Player player)
    {
        var selectedPlanet = AnsiConsole.Prompt(
            new SelectionPrompt<Planet>()
            .Title($"[{player.Color.ToString().ToLower()}]{player.Name}, Select a target planet:[/]")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more planets)[/]")
            .AddChoices(planets));
        Console.WriteLine("----------------------------------------");
        return selectedPlanet;
    }

    private void SendFleet(Player player, Planet target)
    {
        Console.WriteLine("----------------------------------------");
        if (target.OccupiedBy == null)
        {
            target.OccupiedBy = player;
            target.Color = player.Color;
            AnsiConsole.Write(new Markup($"{player.Name} occupied [{target.Color}]{target.Name}.[/]"));
            AnsiConsole.WriteLine();
        }
        else if (target.OccupiedBy == player)
        {
            AnsiConsole.Write(new Markup($"[{target.Color}]{target.Name} has been occupied by you. Please select another target.[/]"));
            AnsiConsole.WriteLine();
            // target = SelectTargetPlanet(player);
            // SendFleet(player, target);
        }
        else
        {
            AnsiConsole.Write(new Markup($"[{target.Color}]{target.Name} has been occupied by you. Please select another target.[/]"));
            AnsiConsole.WriteLine();
            // target = SelectTargetPlanet(player);
            // SendFleet(player, target);
        }
    }

    private void CallBackFleet(Player player, Planet target)
    {
        if (target.OccupiedBy == player)
        {
            target.OccupiedBy = null;
            target.Color = ConsoleColor.White;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{player.Name} called your fleet back from {target.Name}");
        }
        else
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{player.Name} do not have any fleet in {target.Name}");
        }
    }
}