namespace TheLayersOfWar
{
    using System;
    using System.Reflection.Emit;
    using System.Text.Json;
    using System.Threading;
    using static System.Net.Mime.MediaTypeNames;

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
                    Console.WriteLine("\n><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><");
                    Console.WriteLine(" Farewell, brave veggie. May your journey be fruitful until we meet again.");
                    Console.WriteLine("><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><\n");
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

                Console.Write("\n-----------------------------------------------------------\n");
                Console.WriteLine("Press any key to continue!");
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

                Console.Write("\n-----------------------------------------------------------\n");
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey() ;

            } while (!IsValidName(wiseName));
            currentPlayer.WiseName = wiseName;

            Console.Clear();
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------");
            Console.WriteLine($"\nThe kingdom shall remember their names as: {currentPlayer.WarriorName} and {currentPlayer.WiseName}.");
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter); 
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

            foreach (string line in introLines) // jede string line bekommt 1,2 sekunden zeit bevor die nächste zeile erscheint
            {
                Console.WriteLine(line);
                Thread.Sleep(900);
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
                "Villagers of every veggie kind — carrots, beets, even the proud broccoli clans — lived in peace under the onion-sister'srule.",
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
                Thread.Sleep(300);
            }

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nPress any key to return...");
            Console.ResetColor();
            Console.ReadKey();
        }
        static void StartFinalBossFight()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Draconfruit, the Destroyer of Fields, rises with a hiss and a thunderclap!");
                Console.ResetColor();

                Console.WriteLine("His peel crackles with cursed energy. His eyes glow with fermented rage.");
                Console.WriteLine("You feel the weight of every fallen sprout in your hand... and your heart.");
                Console.WriteLine("\nThe final battle begins!");
                Console.WriteLine("\nPress any key to face Draconfruit...");
                Console.ReadKey();

                Enemy finalBoss = new Final_Boss();
                FightEnemy(finalBoss);

                if (Program.currentPlayer.Health > 0)
                {
                    // Player won
                    break;
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You were defeated by Draconfruit... Your tale could end here.");
                Console.ResetColor();

                Console.Write("\nWould you like to try the final battle again? (y/n): ");
                string retry = Console.ReadLine()?.ToLower().Trim() ?? "";

                if (retry != "y")
                {
                    Console.WriteLine("\nFarewell, brave veggie. May your journey be fruitful until we meet again.");
                    Console.WriteLine("Press any key to return to the title screen...");
                    Console.ReadKey();
                    ShowTitleScreen();
                    return;
                }

                // Reset the player's health when retrying
                Program.currentPlayer.Health = 25; 
            }
            Console.Clear();
            Console.WriteLine("\nYou’ve won the game!");
            Console.WriteLine("Reunited, 'The Twinions' can finally take the long awaited vacation at Honey Beach...");
            Console.WriteLine("");
            Console.WriteLine("For the first time in many seasons, the sun rises over Layeria.");
            Console.WriteLine("Among the scorched fields, gentle sprouts begin to grow.");
            Console.WriteLine("From fields once laid to waste, small radishes now sprout, potatoes greet the sunlight, ");
            Console.WriteLine("while other crops begin to rise — bringing new hope to the Kingdom of Layeria for a bountiful and blooming future...");
            Console.WriteLine("The wind still whispers the names of the fallen — but today, it whispers hope as well.");
            Console.WriteLine("");
            Console.WriteLine($"{currentPlayer.WarriorName} and {currentPlayer.WiseName} stand side by side.");
            Console.WriteLine("Not as warrior and wise one, but simply: as sisters.");
            Console.WriteLine("");
            Console.WriteLine("Honey Beach awaits. And this time... without weapons.");
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
            ShowTitleScreen();
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
                       "Your kindeling flame of power returns, eager to bring the rotten to justice",
                       "Suddenly your hear a fearsome roar, followed by sound of despair and decay...",
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
                Thread.Sleep(900);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            EnterWorld(worldName);
        }
        static void EnterWorld(string worldName)
        {
            Console.Clear();
            Console.WriteLine($"You entered: {worldName}.\n");

            for (int i = 1; i <= 3; i++)
            {
                Console.Clear();

                // Mini-boss buildup before level 3
                if (i == 3)
                {
                    Console.WriteLine($"You feel a shift in the air... Something big awaits at {worldName} – Sublevel {i}.");
                    Console.WriteLine("Prepare yourself for the threat that is awaiting...");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.WriteLine($"--- {worldName} – Sublevel {i} ---");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

                EnterLevel(i, worldName);

                // Flavor text between sublevels 1 and 2 for main worlds
                if (i == 1)
                {
                    if (worldName == "Ruins of Layeria")
                    {
                        Console.Clear();
                        Console.WriteLine("The ruins whisper tales of fallen heroes and forgotten glory...");
                        Console.WriteLine("You steel yourself to continue deeper into the shadows.");
                        Console.WriteLine("\nPress any key to press onward...");
                        Console.ReadKey();
                    }
                    else if (worldName == "Bitterroot Forest")
                    {
                        Console.Clear();
                        Console.WriteLine("The forest grows darker and the air thickens with the scent of decay.");
                        Console.WriteLine("You hear distant rustling — something watches.");
                        Console.WriteLine("\nPress any key to push forward...");
                        Console.ReadKey();
                    }
                }
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
            List<Enemy> enemies = EnemyFactory.GetEnemiesForLevel(worldName, levelNumber);

            Console.Clear();
            Console.WriteLine($"{worldName} – Sublevel {levelNumber}");
            Console.WriteLine($"Enemies appear: {string.Join(", ", enemies.Select(e => e.Name))}!");

            Console.WriteLine("\nPress any key to begin the battle...");
            Console.ReadKey();

            foreach (var enemy in enemies)
            {
                FightEnemy(enemy);

                if (Program.currentPlayer.Health <= 0)
                {
                    Console.WriteLine("You have been defeated. Game over.");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("\nAll enemies defeated! Press any key to continue...");
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
        static void FightEnemy(Enemy enemy)
        {
            Player player = Program.currentPlayer;

            while (enemy.Health > 0 && player.Health > 0)
            {
                Console.Clear();
                Console.WriteLine($"Enemy: {enemy.Name} | HP: {enemy.Health}");
                Console.WriteLine($"You: HP: {player.Health}\n");

                if (player.IsStunned)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You are stunned and lose your turn!");
                    Console.ResetColor();
                    player.IsStunned = false;

                    Thread.Sleep(1500); // automatisch setzt eine runde aus 
                }
                else
                {
                    Console.WriteLine("[1] Saut\u00E9");
                    Console.WriteLine("[2] Start crying");
                    Console.WriteLine("[3] Sprout and scout");
                    Console.Write("\nChoose your action: ");
                    string input = Console.ReadLine() ?? "";

                    switch (input)
                    {
                        case "1":
                            Console.WriteLine($"Saut\u00E9! You sear {enemy.Name} for {player.Damage} spicy damage!");
                            enemy.Health -= player.Damage;
                            break;

                        case "2":
                            player.Heal();
                            break;

                        case "3":
                            Console.WriteLine("Time to sprout and scout—this onion’s out!");
                            return; 
                        default:
                            Console.WriteLine("Nope! That action's overcooked. Turn lost!");
                            break;
                    }
                    Thread.Sleep(1000);
                }

                // Enemy's turn if still alive
                if (enemy.Health > 0)
                {
                    enemy.Attack(player);
                    Thread.Sleep(1000);
                }
            }

            // End of fight
            if (player.Health <= 0)
            {
                Console.WriteLine("You were defeated...");
                // Handle death or retry logic here
            }
            else if (enemy.Health <= 0)
            {
                Console.WriteLine($"You defeated the {enemy.Name}!");
                // XP gain, loot, etc.
                int xpEarned = 5; 
                Console.WriteLine($"You gained {xpEarned} XP!");
                player.XPGain(xpEarned);

            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }




    }
}
