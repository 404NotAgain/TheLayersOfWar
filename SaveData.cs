using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLayersOfWar
{
    public class SaveData
    {
        public string WarriorName { get; set; }
        public string WiseName { get; set; }
        public string World { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int Health { get; set; }
        public DateTime SaveDate { get; set; }

        private static readonly string SaveFolder = "Saves";

        // 🧅 Speichern des aktuellen Spielstands
        public static void SaveGame(Player player, string world, int level)
        {
            if (!Directory.Exists(SaveFolder))
                Directory.CreateDirectory(SaveFolder);

            SaveData data = new SaveData
            {
                WarriorName = player.WarriorName,
                WiseName = player.WiseName,
                World = world,
                Level = level,
                XP = player.XP,
                Health = player.Health,
                SaveDate = DateTime.Now
            };

            string fileName = $"{player.WarriorName}_{DateTime.Now:yyyyMMdd_HHmmss}.json";
            string path = Path.Combine(SaveFolder, fileName);

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nGame saved successfully as '{fileName}'!");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // 🧅 Spielstände anzeigen und auswählen
        public static void LoadGame()
        {
            if (!Directory.Exists(SaveFolder))
            {
                Console.WriteLine("No save folder found yet.");
                Console.ReadKey();
                return;
            }

            string[] files = Directory.GetFiles(SaveFolder, "*.json");

            if (files.Length == 0)
            {
                Console.WriteLine("No saved games found.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("><><><><><><><><><><><><><><><><><><><><><");
            Console.WriteLine("            🧅 LOAD GAME 🧅");
            Console.WriteLine("><><><><><><><><><><><><><><><><><><><><><\n");

            for (int i = 0; i < files.Length; i++)
            {
                string json = File.ReadAllText(files[i]);
                SaveData save = JsonSerializer.Deserialize<SaveData>(json)!;
                Console.WriteLine($"[{i + 1}] {save.WarriorName} & {save.WiseName} | {save.World} Lv.{save.Level} | XP:{save.XP} | {save.SaveDate}");
            }

            Console.Write("\nSelect a save number to load: ");
            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > files.Length)
            {
                Console.WriteLine("Invalid choice. Returning to menu...");
                Console.ReadKey();
                return;
            }

            string selectedFile = files[choice - 1];
            string selectedJson = File.ReadAllText(selectedFile);
            SaveData loadedData = JsonSerializer.Deserialize<SaveData>(selectedJson)!;

            ApplySave(loadedData);
        }

        // 🧅 Anwenden des geladenen Spielstands
        private static void ApplySave(SaveData save)
        {
            Program.currentPlayer = new Player
            {
                WarriorName = save.WarriorName,
                WiseName = save.WiseName,
                XP = save.XP,
                Health = save.Health
            };

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Loaded save from {save.SaveDate}!");
            Console.ResetColor();
            Console.WriteLine($"World: {save.World} | Level: {save.Level} | XP: {save.XP}");
            Console.WriteLine("\nPress any key to continue your journey...");
            Console.ReadKey();

            Program.TransitionToWorld(save.World);
        }
    }
}
