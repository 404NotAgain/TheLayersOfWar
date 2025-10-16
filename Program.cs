namespace TheLayersOfWar
{
    using System;
    using System.Threading;
    using System.Text.Json;

    class Program
    {
        public static Player currentPlayer = new Player();

        static void Main()
        {
            ShowTitleScreen();
        }

        static void ShowTitleScreen()
        {
            Console.Clear();
            Console.WriteLine("><><><><><><><><><><><><><><><><><><><><><");
            Console.WriteLine("             The Layers of War     ");
            Console.WriteLine("      A Tale of Courage, Peel, and Fury");
            Console.WriteLine("><><><><><><><><><><><><><><><><><><><><><\n\n");
            Console.WriteLine("             [1] Start Game");
            Console.WriteLine("             [2] Load Game");
            Console.WriteLine("             [3] About Layeria");
            Console.WriteLine("             [4] Quit");
            Console.Write("\nPick an option: ");

            string input = Console.ReadLine() ?? "";
            switch (input)
            {
                case "1":
                    GetTwinNames();
                    ShowIntroNarration();
                    return;
                case "2":
                    //ShowLoadMenuAndLoadGames
                    return;
                case "3":
                    ShowAboutLayeria();
                    ShowTitleScreen();
                    break;
                case "4":
                    Console.WriteLine("Goodbye, brave veggie.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Oops, that choice wasn’t ripe yet. Press any key to pick again.");
                    Console.ReadKey();
                    ShowTitleScreen();
                    break;
            }
        }
        static void GetTwinNames()
        {
            Console.Clear();
            Console.WriteLine("Before your journey begins, name the two royal onion-sisters.\n");

            Console.Write("Enter the name of the strong, fearless twin (The Warrior): ");
            currentPlayer.WarriorName = Console.ReadLine() ?? "";

            Console.Write("Enter the name of the wise, gentle twin (The Wise): ");
            currentPlayer.WiseName = Console.ReadLine() ?? "";

            Console.WriteLine($"\nThe kingdom shall remember their names as: {currentPlayer.WarriorName} and {currentPlayer.WiseName}.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void ShowIntroNarration()
        {
            Console.Clear();
            string[] introLines = new string[]
            {
            "Darkness hung over Layeria like a storm that had forgotten how to pass.",
            "",
            $"Once, the land was peaceful. Twin sisters — the strong {currentPlayer.WarriorName} and the wise {currentPlayer.WiseName} — ruled from the onion-domed castle.",
            "Their people called them the Twinions — a joke at first, but a legend in time.",
            "",
            "Then came the Corrupted Draconfruit.",
            "With him, a legion of twisted fruits and venomous insects.",
            "He swept through the kingdom like rot through a garden.",
            "",
            "Villagers fled. Fields burned. Heroes fell.",
            "And amid the chaos, one sister was taken.",
            "",
            "The other stood alone, sword in hand, the ashes of destruction burning in her eyes.",
            "She looked to the sky and screamed —",
            "",
            "\"THEY TOOK MY TWINION!\"",
            "",
            "And so your tale begins..."
            };

            foreach (string line in introLines)
            {
                Console.WriteLine(line);
                Thread.Sleep(1600);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        static void ShowLoadMenuAndLoadGames() 
        {
        
        }
        static void ShowAboutLayeria()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" ABOUT LAYERIA \n");
            Console.WriteLine("><><><><><><><><\n");

            Console.WriteLine("Once a thriving veggie kingdom, Layeria was attacked by the");
            Console.WriteLine("Corrupted Dracofruit and his legion of mutated fruits and insects.");
            Console.WriteLine($"Now, the lone onion warrior {currentPlayer.WarriorName} must rescue her twin sister {currentPlayer.WiseName} and avenge her land.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nPress any key to return...");
            Console.ResetColor();
            Console.ReadKey();
        }


    }
}
