using System;
using System.Collections.Generic;

namespace Galaxy
{
    public class FleetManager
    {
        private List<SpaceShip> availableShips;

        public FleetManager(List<SpaceShip> ships)
        {
            availableShips = ships ?? new List<SpaceShip>();
        }

        public void PurchaseShip(Player player)
        {
            Console.WriteLine("Available Ships for Purchase:");
            for (int i = 0; i < availableShips.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableShips[i].Name} - {availableShips[i].Cost} Gold");
            }

            Console.Write("Choose a ship to purchase: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= availableShips.Count)
            {
                var selectedShip = availableShips[index - 1];

                if (player.Gold >= selectedShip.Cost)
                {
                    player.Gold -= selectedShip.Cost;
                    player.Spaceships.Add(selectedShip);
                    Console.WriteLine($"You purchased {selectedShip.Name}!");
                }
                else
                {
                    Console.WriteLine("Not enough gold to purchase this ship.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void CreateFleet(Player player)
        {
            Console.WriteLine("Creating a new fleet. Select spaceships:");
            for (int i = 0; i < player.Spaceships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.Spaceships[i].Name}");
            }

            List<SpaceShip> fleetShips = new();
            while (true)
            {
                Console.Write("Select a ship to add (or press Enter to finish): ");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (int.TryParse(input, out int shipIndex) && shipIndex >= 1 && shipIndex <= player.Spaceships.Count)
                {
                    fleetShips.Add(player.Spaceships[shipIndex - 1]);
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }

            if (fleetShips.Count > 0)
            {
                var newFleet = new Fleet(fleetShips);
                player.Fleets.Add(newFleet);
                Console.WriteLine("New fleet created!");
            }
            else
            {
                Console.WriteLine("No ships selected for the fleet.");
            }
        }

        public void DisbandFleet(Player player)
        {
            if (player.Fleets.Count == 0)
            {
                Console.WriteLine("No fleets to disband.");
                return;
            }

            Console.WriteLine("Select a fleet to disband:");
            for (int i = 0; i < player.Fleets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Fleet {i + 1}");
            }

            if (int.TryParse(Console.ReadLine(), out int fleetIndex) && fleetIndex >= 1 && fleetIndex <= player.Fleets.Count)
            {
                player.Fleets.RemoveAt(fleetIndex - 1);
                Console.WriteLine("Fleet disbanded.");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
    }
}
