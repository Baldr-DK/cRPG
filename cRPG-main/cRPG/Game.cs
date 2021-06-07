using System;
using Figgle;
using Pastel;
using static System.Console;
using static cRPG.Engine;
using static cRPG.RNG;
using static cRPG.Character;
namespace cRPG
{
    class Game
    {
        public static Character currentCharacter = new Character();
        public void Boot()
        {
            Max();
            NewGame();
        }
        private static void NewGame()
        {
            Print("Press a key to start");
            ReadKey();
            Clear();
            Print("Name your character:");
            currentCharacter.Name = ReadLine();
            Print("Generating your characteristics:\n");
            currentCharacter.Strength = GetStr();
            WriteLine(currentCharacter.Strength + " Strength     (Increases your melee damage)");
            currentCharacter.Constitution = GetCon();
            WriteLine(currentCharacter.Constitution + " Constitution (Increases your health and stamina)");
            currentCharacter.Dexterity = GetDex();
            WriteLine(currentCharacter.Dexterity + " Dexterity    (Increases your ranged damage and your hit chance in both melee and ranged)");
            currentCharacter.Intelligence = GetInt();
            WriteLine(currentCharacter.Intelligence + " Intelligence (Increases your mana)");
            currentCharacter.Luck = GetLuck();
            WriteLine(currentCharacter.Luck + " Luck         (Increases gold and experience rewards)");
            bool flag0 = false;
            while (flag0 == false)
            {
                Print("\n\nWant to (R)oll again or (S)ave and continue with character creation?");
                string input = ReadLine().ToLower();
                if (input == "r" || input == "roll" || input == "roll again" || input == "(r)oll again" || input == "(r)oll" || input == "(r)")
                {
                    Clear();
                    Print("Name: " + currentCharacter.Name);
                    Print("\nRegenerating your characteristics!\n");
                    currentCharacter.Strength = GetStr();
                    WriteLine(currentCharacter.Strength + " Strength     (Increases your melee damage)");
                    currentCharacter.Constitution = GetCon();
                    WriteLine(currentCharacter.Constitution + " Constitution (Increases your health and stamina)");
                    currentCharacter.Dexterity = GetDex();
                    WriteLine(currentCharacter.Dexterity + " Dexterity    (Increases your ranged damage and your hit chance in both melee and ranged)");
                    currentCharacter.Intelligence = GetInt();
                    WriteLine(currentCharacter.Intelligence + " Intelligence (Increases your mana)");
                    currentCharacter.Luck = GetLuck();
                    WriteLine(currentCharacter.Luck + " Luck         (Increases gold and experience rewards)");
                }
                else if (input == "s" || input == "save" || input == "(s)" || input == "(s)ave")
                {
                    Print("Characteristics are saved!");
                    flag0 = true;
                }
                else
                {
                    Print("Input Error!");
                    flag0 = false;
                }
            }
            currentCharacter.HalfConstitution = currentCharacter.Constitution / 2;
            currentCharacter.FifthConstitution = currentCharacter.Constitution / 5;
            currentCharacter.HitPoints = currentCharacter.CalcHitPoints();
            currentCharacter.MaxHitPoints = currentCharacter.CalcMaxHitPoints();
            currentCharacter.Stamina = currentCharacter.CalcStamina();
            currentCharacter.MaxStamina = currentCharacter.CalcMaxStamina();
            currentCharacter.HalfIntelligence = currentCharacter.Intelligence / 2;
            currentCharacter.FifthIntelligence = currentCharacter.Intelligence / 5;
            currentCharacter.Mana = currentCharacter.CalcMana();
            currentCharacter.MaxMana = currentCharacter.CalcMaxMana();
            bool flag1 = false;
            while (flag1 == false)
            {
                Print("\n\nChose your class: \n(F)ighter (Increased health and melee attack)\n(R)ogue   (Increased ranged attack)\n(W)izard  (Increased magical ability)");
                flag1 = true;
                String input = ReadLine().ToLower();
                if (input == "f" || input == "fighter" || input == "(f)" || input == "(f)ighter")
                {
                    currentCharacter.currentClass = CharacterClass.Fighter;
                    currentCharacter.MaxHitPoints += D12();
                    currentCharacter.Melee += 1;
                }
                else if (input == "r" || input == "rogue" || input == "(r)" || input == "(r)ogue")
                {
                    currentCharacter.currentClass = CharacterClass.Rogue;
                    currentCharacter.MaxHitPoints += D8();
                    currentCharacter.Ranged += 1;
                }
                else if (input == "w" || input == "wizard" || input == "(w)" || input == "(w)izard")
                {
                    currentCharacter.currentClass = CharacterClass.Wizard;
                    currentCharacter.MaxHitPoints += D4();
                    currentCharacter.MaxMana += D12();
                }
                else
                {
                    flag1 = false;
                }
            }
            Print("Chose your race: \n(H)uman    (Are the default race, neither good nor bad at anything)\n(E)lf      (Decreased health but increased ranged and melee\nh(A)lf-Elf (Slightly decreased health but slightly increased ranged and melee)\n(D)warf    (Have increased health and toughness)\nha(L)fling (Lowest health of all races but slightly increased ranged, dexterity and luck)");
            bool flag2 = false;
            while (flag2 == false)
            {
                flag2 = true;
                String input = ReadLine().ToLower();
                if (input == "h" || input == "human" || input == "(h)" || input == "(h)uman")
                {
                    currentCharacter.currentRace = CharacterRace.Human;
                    currentCharacter.MaxHitPoints += D10();
                }

                else if (input == "e" || input == "elf" || input == "(e)" || input == "(e)lf")
                {
                    currentCharacter.currentRace = CharacterRace.Elf;
                    currentCharacter.MaxHitPoints += D6();
                    currentCharacter.Melee += 1;
                    currentCharacter.Ranged += 2;
                }
                else if (input == "a" || input == "halfelf" || input == "half-elf" || input == "(a)" || input == "h(a)lfelf" || input == "h(a)lf-elf")
                {
                    currentCharacter.currentRace = CharacterRace.HalfElf;
                    currentCharacter.MaxHitPoints += D8();
                    currentCharacter.Ranged += 1;
                }
                else if (input == "d" || input == "dwarf" || input == "(d)" || input == "(d)warf")
                {
                    currentCharacter.currentRace = CharacterRace.Dwarf;
                    currentCharacter.MaxHitPoints += D12();
                    currentCharacter.Toughness += 1;
                }
                else if (input == "l" || input == "halfling" || input == "(l)" || input == "ha(l)fling")
                {
                    currentCharacter.currentRace = CharacterRace.Halfling;
                    currentCharacter.MaxHitPoints += D4();
                    currentCharacter.Ranged += 1;
                    currentCharacter.Dexterity += 10;
                    currentCharacter.Luck += 10;
                }
                else
                {
                    Print("Chose an existing race!");
                    flag2 = false;
                }
            }
            Print("Chose your gender: \n(M)ale (Slightly increased health and strength)\n(F)emale (Slightly decreased health but increased dexterity)");
            bool flag3 = false;
            while (flag3 == false)
            {
                flag3 = true;
                String input = ReadLine().ToLower();
                if (input == "m" || input == "male" || input == "(m)" || input == "(m)ale")
                {
                    currentCharacter.currentGender = CharacterGender.Male;
                    currentCharacter.MaxHitPoints += D8();
                    currentCharacter.Strength += 10;
                }
                else if (input == "f" || input == "female" || input == "(f)" || input == "(f)emale")
                {
                    currentCharacter.currentGender = CharacterGender.Female;
                    currentCharacter.MaxHitPoints += D6();
                    currentCharacter.Dexterity += 10;
                }
                else
                {
                    Print("You must chose an existing gender!");
                    flag3 = false;
                }
            }
            currentCharacter.HalfStrength = currentCharacter.Strength / 2;
            currentCharacter.FifthStrength = currentCharacter.Strength / 5;
            currentCharacter.HalfConstitution = currentCharacter.Constitution / 2;
            currentCharacter.FifthConstitution = currentCharacter.Constitution / 5;
            currentCharacter.HalfDexterity = currentCharacter.Dexterity / 2;
            currentCharacter.FifthDexterity = currentCharacter.Dexterity / 5;
            currentCharacter.HalfIntelligence = currentCharacter.Intelligence / 2;
            currentCharacter.FifthIntelligence = currentCharacter.Intelligence / 5;
            currentCharacter.HalfLuck = currentCharacter.Luck / 2;
            currentCharacter.FifthLuck = currentCharacter.Luck / 5;
            currentCharacter.DmgBonus = currentCharacter.DamageBonus();
            int gold = currentCharacter.GetGold();
            int xp = currentCharacter.GetXp();
            currentCharacter.Gold += gold;
            currentCharacter.Xp += xp;
            currentCharacter.Mana = currentCharacter.MaxMana;
            currentCharacter.HitPoints = currentCharacter.MaxHitPoints;            
            Clear();
            WriteLine(FiggleFonts.Larry3d.Render("The Amazing"));
            WriteLine(FiggleFonts.Larry3d.Render("                      " + currentCharacter.Name));
            WriteLine("\n\n===========================================================\n".Pastel("#3e3e42"));
            WriteLine(FiggleFonts.Amc3Line.Render("Character Sheet"));
            WriteLine("===========================================================".Pastel("#3e3e42"));
            WriteLine("              :        1/1 / 1/2 / 1/5 ");
            WriteLine("===========================================================".Pastel("#3e3e42"));
            WriteLine("Strength      :        " + currentCharacter.Strength + " / " + currentCharacter.HalfStrength + " / " + currentCharacter.FifthStrength);
            WriteLine("Constituion   :        " + currentCharacter.Constitution + " / " + currentCharacter.HalfConstitution + " / " + currentCharacter.FifthConstitution);
            WriteLine("Dexterity     :        " + currentCharacter.Dexterity + " / " + currentCharacter.HalfDexterity + " / " + currentCharacter.FifthDexterity);
            WriteLine("Intelligence  :        " + currentCharacter.Intelligence + " / " + currentCharacter.HalfIntelligence + " / " + currentCharacter.FifthIntelligence);
            WriteLine("Luck          :        " + currentCharacter.Luck + " / " + currentCharacter.HalfLuck + " / " + currentCharacter.FifthLuck);
            WriteLine("===========================================================".Pastel("#3e3e42"));
            WriteLine("Name          :        " + currentCharacter.Name + "\nClass         :        " + currentCharacter.currentClass + "\nRace          :        " + currentCharacter.currentRace + "\nGender        :        " + currentCharacter.currentGender);
            WriteLine("===========================================================".Pastel("#3e3e42"));
            WriteLine("Gold          :        " + currentCharacter.Gold);
            WriteLine("Healing Herbs :        " + currentCharacter.Herbs);
            WriteLine("Ammunition    :        " + currentCharacter.Ammo + " / " + currentCharacter.MaxAmmo);
            WriteLine("===========================================================".Pastel("#3e3e42"));
            WriteLine("Damage Bonus  :        +" + currentCharacter.DmgBonus);
            WriteLine("Melee         :        " + currentCharacter.Melee + " / " + currentCharacter.MaxMelee);            
            WriteLine("Ranged        :        " + currentCharacter.Ranged + " / " + currentCharacter.MaxRanged);
            WriteLine("Toughness     :        " + currentCharacter.Toughness + " / " + currentCharacter.MaxToughness);
            WriteLine("===========================================================".Pastel("#3e3e42"));
            WriteLine("Hitpoints     :        " + currentCharacter.HitPoints + " / " + currentCharacter.MaxHitPoints);
            WriteLine("Stamina       :        " + currentCharacter.Stamina + " / " + currentCharacter.MaxStamina);
            WriteLine("Mana          :        " + currentCharacter.Mana + " / " + currentCharacter.MaxMana);
            WriteLine("===========================================================".Pastel("#3e3e42"));
            WriteLine("Level         :        " + currentCharacter.Lvl);
            WriteLine("Difficulty    :        " + currentCharacter.Mod);
            WriteLine("Experience    :        " + currentCharacter.Xp);            
            WriteLine("===========================================================".Pastel("#3e3e42"));
            ReadKey();
            GameLoop();
        }
        public static void GameReturn()
        {
            GameLoop();
        }
        private static void GameLoop()
        {
            Clear();
            Print("Choose an action\n(C)ombat\n(H)ome\n(P)uzzle\n(Q)uit");
            string input = ReadLine().ToLower();
            if (input == "c")
            {
                Clear();
                Combat.GetEncounter();
            }
            else if (input == "h")
            {
                Clear();
                Home.LoadHome();
            }
            else if (input == "p")
            {
                Clear();
                Puzzle.PuzzleStart();
            }
            else if (input == "q")
            {
                Clear();
                Print("Exiting game");
                ReadKey();
                Environment.Exit(0);
            }
            else
            {
                GameLoop();
            }
        }
    }
}