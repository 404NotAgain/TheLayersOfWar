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
        public int Damage { get; set; }
        public int MaxHealth { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int Health { get; set; }
        public DateTime SaveDate { get; set; }

        public List<string> Weapons { get; set; } = new();
        public List<string> Inventory { get; set; } = new();
        public string EquippedWeapon { get; set; } = "";

        private static readonly string SaveFolder = "Saves";


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
                MaxHealth = player.MaxHealth,
                Damage = player.Damage,
                Weapons = player.Weapons.ToList(),
                Inventory = player.Inventory.ToList(),
                EquippedWeapon = player.EquippedWeapon,
                SaveDate = DateTime.Now
            };

            string fileName = $"{player.WarriorName}_{world}_{DateTime.Now:yyyyMMdd_HHmmss}.json";
            string path = Path.Combine(SaveFolder, fileName);

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nGame saved successfully as '{fileName}'!");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        public static void LoadGame()
        {
            if (!Directory.Exists(SaveFolder))
            {
                Console.WriteLine("No save folder found yet.");
                Console.ReadKey();
                return;
            }

            string[] files = Directory.GetFiles(SaveFolder, "*.json")
            .OrderByDescending(f => File.GetCreationTime(f))
            .ToArray(); // it orders the save, newest on top

            if (files.Length == 0)
            {
                Console.WriteLine("No saved games found.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("><><><><><><><><><><><><><><><><><><><><><");
            Console.WriteLine("              LOAD GAME  ");
            Console.WriteLine("><><><><><><><><><><><><><><><><><><><><><\n");

            for (int i = 0; i < files.Length; i++)
            {
                string json = File.ReadAllText(files[i]);
                SaveData save = JsonSerializer.Deserialize<SaveData>(json)!;
                Console.WriteLine($"[{i + 1}] {save.WarriorName} & {save.WiseName} | {save.World} Lv.{save.Level} | XP:{save.XP} | {save.SaveDate}");
            }

            Console.WriteLine("\n[0] Delete a save file");
            Console.WriteLine("[1] Load a save file");
            Console.WriteLine("[2] Return to title screen");
            Console.Write("Select an option: ");
            string input = Console.ReadLine() ?? "";

            if (input == "0")
            {
                Console.Write("Enter the number of the save you want to delete: ");
                string delInput = Console.ReadLine() ?? "";

                if (int.TryParse(delInput, out int delChoice) && delChoice >= 1 && delChoice <= files.Length)
                {
                    Console.Write($"Are you sure you want to delete this save? (y/n): ");
                    string confirm = Console.ReadLine()?.Trim().ToLower() ?? "n";

                    if (confirm == "y")
                    {
                        File.Delete(files[delChoice - 1]);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nSave deleted successfully!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Deletion cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

                Console.WriteLine("\nReturning to title screen...");
                Thread.Sleep(1000);
                Program.ShowTitleScreen(); // returns to main menu
                Console.ReadKey();
                return;
            }

            else if (input == "1")
            {
                int choice = -1;
                while (true)
                {
                    Console.Write("\nSelect a save number to load: ");
                    string loadinput = Console.ReadLine() ?? "";

                    if (int.TryParse(loadinput, out choice) && choice >= 1 && choice <= files.Length)
                        break; // valid choice, continue

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input, try again.");
                    Console.ResetColor();
                }

                string selectedFile = files[choice - 1];
                string selectedJson = File.ReadAllText(selectedFile);
                SaveData loadedData = JsonSerializer.Deserialize<SaveData>(selectedJson)!;

                ApplySave(loadedData);
                return;
            }

            // 🔙 Return to title screen
            else if (input == "2")
            {
                Console.WriteLine("\nReturning to the title screen...");
                Thread.Sleep(1000);
                Program.ShowTitleScreen();
                return;
            }
        }


        private static void ApplySave(SaveData save)
        {
            if (Program.currentPlayer == null)
                Program.currentPlayer = new Player();

            var p = Program.currentPlayer;

            p.WarriorName = save.WarriorName;
            p.WiseName = save.WiseName;
            p.XP = save.XP;
            p.Health = save.Health;
            p.MaxHealth = save.MaxHealth;
            p.Damage = save.Damage;
            p.Weapons = save.Weapons ?? new List<string>();
            p.Inventory = save.Inventory ?? new List<string>();
            p.EquippedWeapon = save.EquippedWeapon ?? "Bare Hands";
            p.CurrentWorld = save.World;
            p.Level = save.Level;

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
