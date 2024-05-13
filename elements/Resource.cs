using System;
using System.Collections.Generic;

namespace Galaxy
{
    public class Resource
    {
        public ResourceType Type { get; set; } // Enum representing the type of resource
        public string? Description { get; set; }
        public int Cost { get; set; } // Cost per unit
        public int Weight { get; set; } // Weight per unit
        public int Quantity { get; set; } // Available quantity

        // Constructor
        public Resource(ResourceType type, string description, int quantity)
        {
            Type = type;
            Description = description;
            // Retrieve cost and weight based on type
            if (ResourceTypeProperties.TryGetValue(type, out var properties))
            {
                Cost = properties.Cost;
                Weight = properties.Weight;
            }
            else
            {
                Cost = 0; // Default cost
                Weight = 0; // Default weight
            }
            Quantity = quantity;
        }

        public Resource()
        {
        }

        public override string ToString() => $"{Type}: {Quantity} units, Cost per unit: {Cost}, Weight per unit: {Weight}";

        // A dictionary mapping each resource type to its associated cost and weight
        private static readonly Dictionary<ResourceType, (int Cost, int Weight)> ResourceTypeProperties = new()
        {
            { ResourceType.Neutronium, (1500, 1000) },
            { ResourceType.IceCrystals, (500, 50) },
            { ResourceType.Helium3, (800, 100) },
            { ResourceType.QuantumAlloy, (2000, 700) },
            { ResourceType.DarkMatter, (3000, 2000) },
            { ResourceType.Deuterium, (1000, 200) },
            { ResourceType.SolarFlareGas, (1200, 80) },
            { ResourceType.Plutonium239, (3500, 1500) },
            { ResourceType.Antimatter, (5000, 2500) },
            { ResourceType.Tritium, (950, 150) },
            { ResourceType.PlasmaCrystals, (1700, 300) },
            { ResourceType.Iridium, (1300, 900) },
            { ResourceType.ExoticMetals, (2200, 1100) },
            { ResourceType.XenonGas, (600, 60) },
            { ResourceType.Aetherium, (2800, 1200) },
            { ResourceType.Titanium, (900, 600) },
            { ResourceType.GravitonCores, (4000, 1800) }
        };
    }

    // Enum representing different types of resources available
    public enum ResourceType
    {
        None,
        Neutronium,
        IceCrystals,
        Helium3,
        QuantumAlloy,
        DarkMatter,
        Deuterium,
        SolarFlareGas,
        Plutonium239,
        Antimatter,
        Tritium,
        PlasmaCrystals,
        Iridium,
        ExoticMetals,
        XenonGas,
        Aetherium,
        Titanium,
        GravitonCores
    }
}
