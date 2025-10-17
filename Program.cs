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
            Console.WriteLine("><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><");
            Console.WriteLine("   Before your journey begins, name the two royal onion-sisters.");
            Console.WriteLine("><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><\n\n");

            string warriorName = "";
            do
            {
                Console.Clear() ;
                Console.Write("  Enter the name of the strong, fearless princess: ");
                Console.Write("\n-----------------------------------------------------------\n");
                warriorName = Console.ReadLine()?.Trim() ?? "";

                if (!IsValidName(warriorName))
                {
                    Console.WriteLine("Please enter a name that is worthy for a strong princess -letters only, no numbers or symbols!.");
                }
                
                Console.ReadKey() ;

            } while (!IsValidName(warriorName));
            currentPlayer.WarriorName = warriorName;

            Console.WriteLine("\n\n");

            string wiseName = "";
            do
            {
                Console.Clear() ;
                Console.Write("  Enter the name of the wise, gentle princess: ");
                Console.Write("\n-----------------------------------------------------------\n");
                wiseName = Console.ReadLine()?.Trim() ?? "";

                if (!IsValidName(wiseName))
                {
                    Console.WriteLine("A wise princess deserves a graceful name — letters only, no numbers or symbols, please!");
                }

                Console.ReadKey() ;

            } while (!IsValidName(wiseName));
            currentPlayer.WiseName = wiseName;

            Console.Clear();
            Console.WriteLine($"\nThe kingdom shall remember their names as: {currentPlayer.WarriorName} and {currentPlayer.WiseName}.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter); // stellt sicher das im Namen nur buchstaben verwendet werden und nichts leer bleibt
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

            foreach (string line in introLines) // jede string line bekommt 1,6 sekunden zeit bevor die nächste zeile erscheint
            {
                Console.WriteLine(line);
                Thread.Sleep(1600);
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();

            TransitionToWorld("Ruins of Layeria");
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

            string[] lore = new string[]
            {
                "Long before the fall, Layeria was a land of abundance and balance.",
                "Verdant fields rolled across the hills, each layer of soil rich with history and harmony.",
                "Villagers of every veggie kind — carrots, beets, even the proud broccoli clans — lived in peace under the onion-sister's rule.",
                "",
                $"The twin rulers, led from the heart of the Onion-Domed Castle.",
                "One, a fierce protector of the borders. The other, a healer of minds and land alike.",
                "",
                "Layeria thrived — not because of strength alone, but because of unity.",
                "",
                "But peace, as always, drew shadows.",
                "From the fruitlands beyond the Bitterroots came whispers of a rotting power — the Corrupted Draconfruit.",
                "Once sweet, now poisoned by envy.",
                "",
                "He turned fruits into armies. insects into weapons.",
                "And when he descended, he tore through Layeria like blight on harvest day.",
                "",
                "The soil still remembers. The wind still whispers their names.",
                "",
                "This is not just a fight for a sister. It is a fight for everything that was buried beneath the ash."
            };

            foreach (string line in lore)
            {
                Console.WriteLine(line);
                Thread.Sleep(80);
            }

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nPress any key to return...");
            Console.ResetColor();
            Console.ReadKey();
        }
        static Enemy GetEnemyForLevel(string world, int level)
        {
            if (world == "Finsterwurzelhöhle")
            {
                return null!; // keine extra gegner in der endwelt

            }
            if (level == 3)
            {
                // Mini-Boss auf jedem dritten Level
                return new Mini_Boss("Kern-Keiler");
            }

            // Normale Gegner
            return new Enemy("Gurkenreiter", 20, 5);
        }
        static void StartFinalBossFight()
        {
            Enemy finalBoss = new Final_Boss();
            Console.WriteLine("Draconfruit, The destroyer of fields has appeared to bring you, your peely end!");

        }
        static void TransitionToWorld(string worldName)
        {
            Console.Clear();
            string[] loreLines; // macht das in jedem level eine kleine story immersion ist, inklusive pausen zwischen zeilen

            switch (worldName)
            {
                case "Ruins of Layeria":
                    loreLines = new string[]
                    {
                       "Your journey begins at the ruins of Layeria...",
                       "",
                       "Ash clings to every stone like the ghosts of what once was.",
                       "You walk past broken onion-carts, scattered beetroot helmets, and burned soil.",
                       "The wind howls through the cracks in the onion-domed castle.",
                       "You are all that remains.",
                    };
                    break;

                case "Bitterroot Forest":
                    loreLines = new string[]
                    {
                       "You step into the Bitterroot Forest.",
                       "",
                       "Once a thriving grove of medicine and mystery.",
                       "Now it's a maze of twisted roots and spores.",
                       "The trees whisper names of the fallen — and some whisper yours.",
                    };
                    break;

                case "Cave of Whispers":
                    loreLines = new string[]
                    {
                       "You descend into the Cave of Whispers.",
                       "",
                       "The deeper you go, the less you trust your own footsteps.",
                       $"Voices echo — faint cries can be heared and you make them out to belong to your beloved sister {currentPlayer.WiseName}",
                       "Your kindeling flame of power ",
                       "Draconfruit is close... Too close...",
                    };
                    break;

                default:
                    loreLines = new string[]
                    {
                       $"You enter: {worldName}.",
                       "But something here feels... wrong."
                    };
                    break;
            }

            foreach (string line in loreLines) 
            {
                Console.WriteLine(line);
                Thread.Sleep(1600);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            EnterWorld(worldName);
        }
        static void EnterWorld(string worldName)
        {
            Console.Clear();
            Console.WriteLine($"You entered: {worldName}.\n");

            if (worldName == "Cave of whispers")
            {
                StartFinalBossFight();
                Console.WriteLine("\nYou’ve won the game!");
                Console.WriteLine("Finally reunited 'The Twinions' can finally take a vacation at Honey Beach...");
                Console.WriteLine("");
                Console.WriteLine("For the first time in many seasons, the sun rises over Layeria.");
                Console.WriteLine("Among the scorched fields, gentle sprouts begin to grow.");
                Console.WriteLine("The wind still whispers the names of the fallen — but today, it whispers hope too.");
                Console.WriteLine("");
                Console.WriteLine($"{currentPlayer.WarriorName} and {currentPlayer.WiseName} stand side by side.");
                Console.WriteLine("Not as warrior and wise one, but simply: as sisters.");
                Console.WriteLine("");
                Console.WriteLine("Honey Beach awaits. And this time... without weapons.");
                Console.WriteLine("\nPress any key to return to the main menu.");
                Console.ReadKey();
                ShowTitleScreen();
                return;
            }

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"--- {worldName} – Sublevel {i} ---");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

                EnterLevel(i, worldName);
            }
            // Zur nächsten Welt übergehen
            string nextWorld = GetNextWorld(worldName);
            if (!string.IsNullOrEmpty(nextWorld))
            {
                TransitionToWorld(nextWorld);
            }
        }
        static void EnterLevel(int levelNumber, string worldName)
        {
            Enemy enemy = GetEnemyForLevel(worldName, levelNumber);
            if (enemy == null) return; // prüft das keine extra gegner in der endwelt erscheinen

            Console.Clear();
            Console.WriteLine($"{worldName} – Sublevel {levelNumber}");

            Console.WriteLine($"An enemy appears: {enemy.Name}!");
            Console.WriteLine("(Kampfsystem kommt später)");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        static string GetNextWorld(string current)
        {
            switch (current)
            {
                case "Ruins of Layeria": return "Bitterroot Forest";
                case "Bitterroot Forest": return "Cave of whispers";
                default: return ""; // automatisiert den übergang von den welten zur nächsten

            }
        }


    }
}
