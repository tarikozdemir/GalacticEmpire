using System.Numerics;
using Galaxy;
using Spectre.Console;
public class Game
{
    public List<SpaceShip> InitializeAvailableShips()
    {
        return new List<SpaceShip>
    {
        new SpaceShip("Falcon Scout", SpaceShipType.Scout, "Fast, low fuel consumption, weak armor", new List<Crew>(), 900, 1200, 10, 25, 10, "", 15000),
        new SpaceShip("Viper Probe", SpaceShipType.Scout, "Fast and quiet, advanced sensors", new List<Crew>(), 1100, 900, 8, 20, 8, "", 17000),
        new SpaceShip("Raven Scout", SpaceShipType.Scout, "Fast, low radar profile, limited weapon capacity", new List<Crew>(), 950, 1100, 15, 22, 9, "", 18500),
        new SpaceShip("Swift Talon", SpaceShipType.Scout, "Agile, short-range, basic scanning equipment", new List<Crew>(), 1000, 1000, 12, 24, 10, "", 16000),
        new SpaceShip("Comet Runner", SpaceShipType.Scout, "Lightweight, long-range, automatic escape module", new List<Crew>(), 1200, 900, 7, 18, 6, "", 19000),

        new SpaceShip("Phoenix Wing", SpaceShipType.Fighter, "Strong attack, medium armor, short-range", new List<Crew>(), 800, 1500, 20, 80, 45, "", 25000),
        new SpaceShip("Iron Claw", SpaceShipType.Fighter, "Strong attack and armor, limited maneuverability", new List<Crew>(), 750, 2000, 25, 100, 50, "", 28000),
        new SpaceShip("Red Falcon", SpaceShipType.Fighter, "Fast attack, low defense, heavy weapons", new List<Crew>(), 850, 1800, 15, 85, 40, "", 26000),
        new SpaceShip("Thunder Fist", SpaceShipType.Fighter, "Balanced attack and defense, advanced sensors", new List<Crew>(), 700, 1600, 18, 90, 48, "", 24500),
        new SpaceShip("Stormstrike", SpaceShipType.Fighter, "High attack power, medium armor, heavy guns", new List<Crew>(), 780, 1700, 22, 95, 47, "", 27000),

        new SpaceShip("Stormbringer", SpaceShipType.Frigate, "Balanced attack and defense, medium-range", new List<Crew>(), 600, 3500, 50, 150, 75, "", 45000),
        new SpaceShip("Vanguard", SpaceShipType.Frigate, "High armor, advanced sensors, long-range", new List<Crew>(), 580, 4000, 55, 140, 85, "", 48000),
        new SpaceShip("Defender", SpaceShipType.Frigate, "High defense, energy weapons", new List<Crew>(), 550, 4500, 60, 130, 90, "", 50000),
        new SpaceShip("Nightwatch", SpaceShipType.Frigate, "Stealth operations capable, high radar stealth", new List<Crew>(), 620, 3800, 45, 160, 70, "", 46500),
        new SpaceShip("Sentinel", SpaceShipType.Frigate, "Medium attack, strong armor, heavy missile capacity", new List<Crew>(), 590, 3900, 52, 145, 78, "", 47500),

        new SpaceShip("Titan Breaker", SpaceShipType.Destroyer, "High attack, medium armor, wide missile capacity", new List<Crew>(), 500, 6000, 80, 250, 120, "", 75000),
        new SpaceShip("Obliterator", SpaceShipType.Destroyer, "Intense attack, weak armor, long-range", new List<Crew>(), 520, 5500, 85, 280, 115, "", 78500),
        new SpaceShip("Maelstrom", SpaceShipType.Destroyer, "Strong attack and defense, limited speed", new List<Crew>(), 480, 6200, 90, 240, 125, "", 72000),
        new SpaceShip("Doom Hammer", SpaceShipType.Destroyer, "Strong energy weapons, heavy armor", new List<Crew>(), 490, 6500, 78, 270, 110, "", 79500),
        new SpaceShip("Thunderstorm", SpaceShipType.Destroyer, "Balanced attack and defense, automated drone defense", new List<Crew>(), 510, 5800, 75, 260, 118, "", 74500),

        new SpaceShip("Solaris", SpaceShipType.Cruiser, "Strong attack and defense, advanced sensors", new List<Crew>(), 400, 8000, 150, 450, 250, "", 120000),
        new SpaceShip("Star Galleon", SpaceShipType.Cruiser, "Durable armor, automatic drone defense", new List<Crew>(), 420, 8500, 160, 420, 240, "", 122000),
        new SpaceShip("Galactic Horn", SpaceShipType.Cruiser, "High attack capacity, short-range", new List<Crew>(), 430, 8200, 140, 460, 245, "", 124000),
        new SpaceShip("Vortex", SpaceShipType.Cruiser, "Balanced attack, advanced missile launchers", new List<Crew>(), 410, 8300, 155, 440, 230, "", 119500),
        new SpaceShip("Nebula Guard", SpaceShipType.Cruiser, "Intense defense, medium attack, long-range", new List<Crew>(), 390, 7900, 148, 430, 255, "", 121000),

        new SpaceShip("Fortress Max", SpaceShipType.Capital_Ship, "Strong defense, major fleet command center", new List<Crew>(), 300, 12000, 300, 600, 450, "", 250000),
        new SpaceShip("Leviathan", SpaceShipType.Capital_Ship, "Extremely durable armor, advanced missile defense", new List<Crew>(), 320, 13000, 350, 580, 460, "", 255000),
        new SpaceShip("Star Fortress", SpaceShipType.Capital_Ship, "Central base, balanced attack and defense", new List<Crew>(), 310, 12500, 310, 590, 440, "", 248000),
        new SpaceShip("Titan Citadel", SpaceShipType.Capital_Ship, "Large defensive walls, energy weapons", new List<Crew>(), 290, 14000, 280, 620, 470, "", 260000),
        new SpaceShip("Command Hub", SpaceShipType.Capital_Ship, "Fleet command and control center, automated defense", new List<Crew>(), 310, 13500, 330, 610, 480, "", 252000),

        new SpaceShip("Horizon", SpaceShipType.Freighter, "Large cargo capacity, low defense", new List<Crew>(), 250, 9000, 400, 150, 100, "", 80000),
        new SpaceShip("Cargo Whale", SpaceShipType.Freighter, "Large cargo capacity, durable armor", new List<Crew>(), 230, 10000, 450, 140, 110, "", 82000),
        new SpaceShip("Trade Wind", SpaceShipType.Freighter, "Fast, medium cargo capacity", new List<Crew>(), 260, 8500, 370, 160, 95, "", 78500),
        new SpaceShip("Merchant", SpaceShipType.Freighter, "Balanced transport, advanced radar", new List<Crew>(), 240, 9500, 420, 155, 105, "", 81500),
        new SpaceShip("Hauler", SpaceShipType.Freighter, "Large cargo capacity, automated defense", new List<Crew>(), 245, 9800, 430, 145, 108, "", 83000)

        // Add more predefined ships with different attributes and costs
    };
    }
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
        HashSet<Vector2> occupiedPositions = new HashSet<Vector2>();

        // Place players ensuring unique positions
        for (int i = 0; i < playerCount; i++)
        {
            string playerName = AnsiConsole.Ask<string>($"What is the [green]name[/] of player [bold]{i + 1}[/]?");
            var player = new Player(playerName, 100, playerColors[i % playerColors.Length]);
            players.Add(player);
            PlacePlayer(player, occupiedPositions);
        }

        // Place planets ensuring unique positions
        for (int i = 0; i < playerCount * 2; i++)
        {
            Vector2 position;
            do
            {
                position = new Vector2(Random.Shared.Next(0, spaceSize), Random.Shared.Next(0, spaceSize));
            } while (occupiedPositions.Contains(position));

            var planet = new Planet($"Planet {i + 1}", position);
            planets.Add(planet);
            PlacePlanet(planet, occupiedPositions);
        }

        DisplaySpace();  // Display updated space
    }

    private void PlacePlayer(Player player, HashSet<Vector2> occupiedPositions)
    {
        Vector2 position;
        do
        {
            position = new Vector2(Random.Shared.Next(0, spaceSize), Random.Shared.Next(0, spaceSize));
        } while (!space[(int)position.X, (int)position.Y].IsEmpty || occupiedPositions.Contains(position));

        space[(int)position.X, (int)position.Y].Player = player;
        occupiedPositions.Add(position); // Mark this position as occupied
    }

    private void PlacePlanet(Planet planet, HashSet<Vector2> occupiedPositions)
    {
        Vector2 position = planet.Position;
        if (!occupiedPositions.Contains(position) && position.X >= 0 && position.X < spaceSize && position.Y >= 0 && position.Y < spaceSize)
        {
            space[(int)position.X, (int)position.Y].Planet = planet;
            occupiedPositions.Add(position); // Mark this position as occupied
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
        List<SpaceShip> availableShips = InitializeAvailableShips();  // This should ideally be part of the game's initialization

        while (gameRunning)
        {
            foreach (var player in players)
            {
                if (!player.IsAlive) continue;
                PerformPlayerTurn(player, availableShips);
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

    private void PerformPlayerTurn(Player player, List<SpaceShip> availableShips)
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
                    if (player.Fleets.Count > 0)
                    {
                        Planet target = SelectTargetPlanet(player);
                        SendFleet(player, target);
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------");
                        AnsiConsole.Write(new Markup($"{player.Name} does not have any fleet to send."));
                        AnsiConsole.WriteLine();
                    }
                    break;
                }
            case "Call Back Fleet":
                {
                    if (player.Fleets.Count > 0)
                    {
                        Planet target = SelectTargetPlanet(player);
                        CallBackFleet(player, target);
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------");
                        AnsiConsole.Write(new Markup($"{player.Name} does not have any fleet to call back."));
                        AnsiConsole.WriteLine();
                    }
                    break;
                }

            case "Fleet Options":
                {
                    FleetOptions(player, availableShips);
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

    private void FleetOptions(Player player, List<SpaceShip> availableShips)
    {
        var fleetActions = new SelectionPrompt<string>()
            .Title("Select an action for your fleet:")
            .PageSize(10)
            .AddChoices(new[] {
            "Create a Fleet", "Disband a Fleet", "List Fleets", "Purchase Ship"
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
            case "Purchase Ship":
                PurchaseShip(player, availableShips);
                break;
            default:
                Console.WriteLine("Invalid option selected.");
                break;
        }
    }

    public void PurchaseShip(Player player, List<SpaceShip> availableShips)
    {
        Console.WriteLine("Available Ships for Purchase:");
        foreach (var ship in availableShips)
        {
            ship.DisplaySpaceShipInfo();
        }

        var selectedShip = AnsiConsole.Prompt(
            new SelectionPrompt<SpaceShip>()
            .Title("Select a ship to purchase:")
            .PageSize(20)
            .UseConverter(s => s.Type + " => " + s.Name + " - " + s.Cost + " Gold")
            .AddChoices(availableShips));

        if (player.Gold >= selectedShip.Cost)
        {
            player.Gold -= selectedShip.Cost;  // Deduct the cost from player's gold
            player.Spaceships.Add(selectedShip);  // Add the ship to the player's fleet
            Console.WriteLine($"{player.Name} purchased {selectedShip.Name} for {selectedShip.Cost} Gold.");
        }
        else
        {
            Console.WriteLine("Not enough gold to purchase this ship.");
        }
    }

    private void CreateFleet(Player player)
    {
        if (player.Spaceships.Count > 0)
        {
            List<SpaceShip> selectedShips = new List<SpaceShip>();
            var shipSelection = AnsiConsole.Prompt(
                new MultiSelectionPrompt<SpaceShip>()
                    .Title($"Select ships to form a new fleet for {player.Name}:")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more ships)[/]")
                    .InstructionsText("[grey](Press [blue]<space>[/] to toggle a ship, " +
                "[green]<enter>[/] to accept)[/]")
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
        else
        {
            Console.WriteLine("You do not have any ships to create a fleet.");
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

        player.Spaceships.AddRange(selectedFleet.Ships);
        Console.WriteLine($"Fleet disbanded, {selectedFleet.Ships.Count} ships returned to general inventory.");
    }

    private void ListFleets(Player player)
    {
        if (player.Fleets.Count == 0)
        {
            Console.WriteLine($"{player.Name} has no fleets.");
            Console.WriteLine($"Available Ships of {player.Name}:");
            if (player.Spaceships.Count == 0)
            {
                Console.WriteLine("No available ships.");
            }
            else
            {
                foreach (var ship in player.Spaceships)
                {
                    ship.DisplaySpaceShipInfo();
                }
            }
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