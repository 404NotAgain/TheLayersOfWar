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
                    new Enemy("Cucumber Knight", 20, 5),
                    new Enemy("Plum Goblin", 15, 4)
                };
            case 2:
                return new List<Enemy>
                {
                    new Enemy("Cherry Crusader", 22, 6),
                    new Enemy("Radish Renegade", 18, 5),
                    new Enemy("Broc-kill-i", 25, 7)
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
                    new Enemy("Spore Wolf", 28, 9),
                    new Enemy("Mushroom Warrior", 30, 8)
                };
            case 2:
                return new List<Enemy>
                {
                    new Enemy("Thorn Runner", 35, 12),
                    new Enemy("Bitter Wraith", 32, 10),
                    new Enemy("Bark Howler", 38, 11)
                };
            default:
                return new List<Enemy>();
        }
    }
    public static Enemy Create(string enemyName)
    {
        enemyName = enemyName?.Trim() ?? "";

        // Match by name (case-insensitive)
        return enemyName.ToLower() switch
        {
            "thorn mother" => new ThornMother(),
            "core boar" => new CoreBoar(),
            "draconfruit" => new Final_Boss(),
            "spore wolf" => new Enemy("Spore Wolf", 28, 9),
            "mushroom warrior" => new Enemy("Mushroom Warrior", 30, 8),
            "thorn runner" => new Enemy("Thorn Runner", 35, 12),
            "bitter wraith" => new Enemy("Bitter Wraith", 32, 10),
            "bark howler" => new Enemy("Bark Howler", 38, 11),
            "cucumber knight" => new Enemy("Cucumber Knight", 20, 5),
            "plum goblin" => new Enemy("Plum Goblin", 15, 4),
            "cherry crusader" => new Enemy("Cherry Crusader", 22, 6),
            "radish renegade" => new Enemy("Radish Renegade", 18, 5),
            "broc-kill-i" => new Enemy("Broc-kill-i", 25, 7),
            _ => new Enemy(enemyName, 15, 5) // fallback
        };
    }

}

