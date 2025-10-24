using System;
using System.Collections.Generic;
using TheLayersOfWar;
internal class EnemyFactory
{
    public static List<Enemy> GetEnemiesForLevel(string world, int level)
    {
        // Normalize world name (ignore case and extra spaces)
        world = world?.Trim() ?? "";

        // --- Final boss handled separately ---
        if (world.Equals("Cave of Whispers", StringComparison.OrdinalIgnoreCase))
            return new List<Enemy>();

        // --- World-specific level 3 mini-bosses ---
        if (level == 3)
        {
            if (world.Equals("Ruins of Layeria", StringComparison.OrdinalIgnoreCase))
                return new List<Enemy> { new CoreBoar() };

            if (world.Equals("Bitterroot Forest", StringComparison.OrdinalIgnoreCase))
                return new List<Enemy> { new ThornMother() };
        }

        // --- Regular enemies by world ---
        if (world.Equals("Ruins of Layeria", StringComparison.OrdinalIgnoreCase))
            return GetRuinsEnemies(level);

        if (world.Equals("Bitterroot Forest", StringComparison.OrdinalIgnoreCase))
            return GetBitterrootEnemies(level);

        // --- Default fallback (for unknown world names) ---
        return new List<Enemy>
        {
            new Enemy("Unknown Creature", 10, 2)
        };
    }

    private static List<Enemy> GetRuinsEnemies(int level)
    {
        switch (level)
        {
            case 1:
                return new List<Enemy>
                {
                    new Enemy("Cucumber Knight", 15, 4),
                    new Enemy("Plum Goblin", 12, 3)
                };
            case 2:
                return new List<Enemy>
                {
                    new Enemy("Cherry Crusader", 18, 6),
                    new Enemy("Radish Renegade", 16, 5),
                    new Enemy("Broc-kill-i", 14, 7)
                };
            default:
                return new List<Enemy>();
        }
    }

    private static List<Enemy> GetBitterrootEnemies(int level)
    {
        switch (level)
        {
            case 1:
                return new List<Enemy>
                {
                    new Enemy("Spore Wolf", 16, 7),
                    new Enemy("Mushroom Warrior", 14, 8)
                };
            case 2:
                return new List<Enemy>
                {
                    new Enemy("Thorn Runner", 20, 12),
                    new Enemy("Bitter Wraith", 18, 10),
                    new Enemy("Bark Howler", 21, 11)
                };
            default:
                return new List<Enemy>();
        }
    }
}

