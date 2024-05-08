﻿using System;
using System.Collections.Generic;
using System.Numerics;
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
    private Cell[,] space;
    private int spaceSize = 20;
    private List<Planet> planets = new List<Planet>();
    private List<Player> players = new List<Player>();
    private bool gameRunning = true;
    private int currentRound = 1;  // Round tracking

    private ConsoleColor[] playerColors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White };

    public Game()
    {
        space = new Cell[spaceSize, spaceSize];
        InitializeSpace();
    }

    private void InitializeSpace()
    {
        for (int i = 0; i < spaceSize; i++)
        {
            for (int j = 0; j < spaceSize; j++)
            {
                space[i, j] = new Cell();
            }
        }
    }
    public void InitializeGame()
    {
        int playerCount = AskPlayerCount();
        for (int i = 0; i < playerCount; i++)
        {
            string playerName = AnsiConsole.Ask<string>($"What is the [green]name[/] of player [bold]{i + 1}[/]?");
            var player = new Player(playerName, 100, 100, playerColors[i % playerColors.Length]);
            players.Add(player);
            PlacePlayer(player);
        }

        for (int i = 0; i < playerCount * 2; i++)
        {
            Vector2 position = new Vector2(Random.Shared.Next(0, spaceSize), Random.Shared.Next(0, spaceSize));
            var planet = new Planet($"Planet {i + 1}", position);
            planets.Add(planet);
            PlacePlanet(planet);
        }
        DisplaySpace();  // Display updated space
    }

    private void PlacePlayer(Player player)
    {
        Vector2 position;
        do
        {
            position = new Vector2(Random.Shared.Next(0, spaceSize), Random.Shared.Next(0, spaceSize));
        } while (!space[(int)position.X, (int)position.Y].IsEmpty);

        space[(int)position.X, (int)position.Y].Player = player;
    }

    private void PlacePlanet(Planet planet)
    {
        Vector2 position = planet.Position;
        if (position.X >= 0 && position.X < spaceSize && position.Y >= 0 && position.Y < spaceSize)
        {
            space[(int)position.X, (int)position.Y].Planet = planet;
        }
    }

    private void DisplaySpace()
    {
        for (int i = 0; i < spaceSize; i++)
        {
            for (int j = 0; j < spaceSize; j++)
            {
                Console.ForegroundColor = space[i, j].Color;
                Console.Write(space[i, j].DisplayChar + " ");
                Console.ResetColor();
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

    public void RunGameLoop()
    {
        while (gameRunning)
        {
            foreach (var player in players)
            {
                if (!player.IsAlive) continue;
                PerformPlayerTurn(player);
                DisplaySpace();  // Display space  
            }
            EvaluateRound();
            currentRound++;  // Advance to the next round
            Console.WriteLine($"Round {currentRound} begins");
            // var livePlayers = players.Where(player => player.IsAlive).ToList();
            // if (livePlayers.Count == 1)
            // {
            //     Console.WriteLine($"{livePlayers[0].Name} is the last survivor and wins the game!");
            //     gameRunning = false;
            // }
        }
    }

    private void PerformPlayerTurn(Player player)
    {
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
                    SendFleet(player, target);
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
                    FleetOptions(player);
                    break;
                }
            default: break;
        }
    }

    private void EvaluateRound()
    {
        // Evaluate end of round conditions, update resources, check victory, etc.
        Console.WriteLine("Evaluating end of round conditions...");
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
        }
        else
        {
            AnsiConsole.Write(new Markup($"[{target.Color}]{target.Name} has been occupied by {target.OccupiedBy.Name}. Please select another target.[/]"));
            AnsiConsole.WriteLine();
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

    private void FleetOptions(Player player)
    {
        var fleetActions = new SelectionPrompt<string>()
            .Title("Select an action for your fleet:")
            .PageSize(10)
            .AddChoices(new[] {
            "Create a Fleet", "Disband a Fleet", "List Fleets"
            });

        string chosenAction = AnsiConsole.Prompt(fleetActions);

        switch (chosenAction)
        {
            case "Create a Fleet":
                CreateFleet(player);
                break;
            case "Disband a Fleet":
                DisbandFleet(player);
                break;
            case "List Fleets":
                ListFleets(player);
                break;
            default:
                Console.WriteLine("Invalid option selected.");
                break;
        }
    }

    private void CreateFleet(Player player)
    {
        List<SpaceShip> selectedShips = new List<SpaceShip>();

        // Assuming `player.Spaceships` contains a list of all the player's available ships
        var shipSelection = AnsiConsole.Prompt(
            new MultiSelectionPrompt<SpaceShip>()
                .Title($"Select ships to form a new fleet for {player.Name}:")
                .PageSize(10)
                .AddChoices(player.Spaceships)); // Adjust as per your data structure

        selectedShips.AddRange(shipSelection);

        if (selectedShips.Count > 0)
        {
            Fleet newFleet = new Fleet(selectedShips);
            player.Fleets.Add(newFleet); // Add to player's fleet list
            Console.WriteLine($"New fleet created with {selectedShips.Count} ships.");
        }
        else
        {
            Console.WriteLine("No ships were selected.");
        }
    }

    private void DisbandFleet(Player player)
    {
        if (player.Fleets.Count == 0)
        {
            Console.WriteLine($"{player.Name} has no fleets to disband.");
            return;
        }

        var fleetSelection = AnsiConsole.Prompt(
            new SelectionPrompt<Fleet>()
                .Title($"Select a fleet to disband:")
                .PageSize(10)
                .AddChoices(player.Fleets));

        Fleet selectedFleet = fleetSelection;
        player.Fleets.Remove(selectedFleet);

        // Assuming player.Spaceships is a List containing all the player's available ships
        player.Spaceships.AddRange(selectedFleet.Ships);
        Console.WriteLine($"Fleet disbanded, {selectedFleet.Ships.Count} ships returned to general inventory.");
    }

    private void ListFleets(Player player)
    {
        if (player.Fleets.Count == 0)
        {
            Console.WriteLine($"{player.Name} has no fleets.");
        }
        else
        {
            foreach (var fleet in player.Fleets)
            {
                fleet.DisplayFleetInfo();
            }
        }
    }


}