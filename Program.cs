using System;
using System.Collections.Generic;
using Galaxy;

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
            Console.WriteLine($"What is the name of player {i + 1}?");
            string playerName = Console.ReadLine()!;
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
            planetPosition[(int)planet.Position.X, (int)planet.Position.Y] = planet;  // Reference player in grid
        }

        foreach (var player in players)
        {
            if (player.IsAlive)
            {
                space[(int)player.Position.X, (int)player.Position.Y] = 'P';  // Represent player with 'P'
                playerPosition[(int)player.Position.X, (int)player.Position.Y] = player;  // Reference player in grid
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
        while (true)
        {
            Console.WriteLine("How many players will play the game?");
            if (int.TryParse(Console.ReadLine(), out int playerCount) && playerCount >= 2)
            {
                return playerCount;
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Invalid input. Player count cannot be less than 2.");
        }
    }

    private void DisplayPlayerStatus(Player player)
    {
        Console.ForegroundColor = player.Color;  // Set text color to player specific color
        Console.WriteLine("--------------- PLAYER STATUS ---------------");
        Console.WriteLine($"{player.Name} is located at [{player.Position.X},{player.Position.Y}].");
        Console.ResetColor();  // Reset text color to default
        Console.WriteLine("----------------- GAME GRID -----------------");
        DisplaySpace();  // Display the updated game grid
        Console.WriteLine("-------------------------------------------------");
    }

    public void RunGameLoop()
    {
        while (gameRunning)
        {
            foreach (var player in players)
            {
                if (!player.IsAlive) continue;

                Console.ForegroundColor = player.Color;  // Set text color to player specific color
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"{player.Name}, What do you want to do? (1- Send Fleet, 2- Call Back Fleet):");
                Console.ResetColor();  // Reset text color
                var input = Console.ReadLine();
                Console.ForegroundColor = player.Color;  // Set text color to player specific color
                if (int.TryParse(input, out int actionChoice) && (actionChoice == 1 || actionChoice == 2))
                {
                    Planet target = SelectTargetPlanet(player);
                    if (actionChoice == 1)
                    {
                        if (target.OccupiedBy == null || target.OccupiedBy == player)
                        {
                            SendFleet(player, target);
                        }
                    }
                    else
                    {
                        CallBackFleet(player, target);
                    }
                    UpdateSpace();  // Update space after fleet action
                    DisplaySpace();  // Display space
                }
                else
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Invalid input. Please enter (1- Send Fleet, 2- Call Back Fleet)");
                }
                Console.ResetColor();  // Reset text color
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
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Select a target planet:");
        int index = 1;
        Dictionary<int, Planet> targetOptions = new Dictionary<int, Planet>();
        foreach (var planet in planets)
        {
            if (planet.OccupiedBy == null)
            {
                Console.ResetColor();  // Reset text color
                Console.WriteLine($"{index} - {planet.Name}");
                targetOptions[index] = planet;
                Console.ForegroundColor = player.Color;  // Set text color to planet specific color
            }
            else if (planet.OccupiedBy == player)
            {
                Console.WriteLine($"{index} - {planet.Name}");
                targetOptions[index] = planet;
            }
            else continue;
            index++;
        }
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && targetOptions.ContainsKey(choice))
        {
            return targetOptions[choice];
        }
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Invalid selection. Please try again.");
        return null;
    }

    private void SendFleet(Player player, Planet target)
    {
        if (target.OccupiedBy != null)
        {
            Console.WriteLine("-------------------------------------------------");
            if (target.OccupiedBy != player)
            {
                Console.WriteLine($"{target.Name} has been occupied by {target.OccupiedBy.Name}. Please select another target.");
            }
            else
            {
                Console.WriteLine($"{target.Name} has been occupied by you. Please select another target.");
            }
            SelectTargetPlanet(player);
        }
        else
        {
            target.OccupiedBy = player;
            target.Color = player.Color;
        }
    }
    private void CallBackFleet(Player player, Planet target)
    {
        if (target.OccupiedBy == player)
        {
            target.OccupiedBy = null;
            target.Color = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"You do not have any fleet in {target.Name}");
        }
    }
}