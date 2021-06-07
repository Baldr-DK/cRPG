using System;
using Pastel;
using static System.Console;
using static cRPG.Engine;
using static cRPG.Game;
namespace cRPG
{
    class Home
    {
        public static void LoadHome()
        {
            RunHome();
        }
        private static void RunHome()
        {
            int herbsC;
            int toughC;
            int meleeC;
            int rangedC;
            int ammoC;
            int difficulty;
            while (true)
            {
                herbsC = 100;
                ammoC = 150;
                toughC = 200 * (currentCharacter.Toughness + 1);
                meleeC = 200 * currentCharacter.Melee;
                rangedC = 200 * currentCharacter.Ranged;
                difficulty = 300 + 100 * currentCharacter.Mod;
                Clear();
                WriteLine("======================================================".Pastel("#3e3e42"));
                WriteLine("(H)erbs       :   $" + herbsC);
                WriteLine("(A)mmo        :   $" + ammoC);
                WriteLine("(M)elee       :   $" + meleeC);
                WriteLine("(R)ranged     :   $" + rangedC);
                WriteLine("(T)oughness   :   $" + toughC);
                WriteLine("(D)ifficulty  :   $" + difficulty);
                WriteLine("======================================================".Pastel("#3e3e42"));
                WriteLine("(S)leep and recover health.");
                WriteLine("(B)ack to the dungeon");
                WriteLine("(Q)uit and save the game.");
                WriteLine("======================================================".Pastel("#3e3e42"));
                WriteLine("Strength    : " + currentCharacter.Strength + " / " + currentCharacter.HalfStrength + " / " + currentCharacter.FifthStrength);
                WriteLine("Constituion : " + currentCharacter.Constitution + " / " + currentCharacter.HalfConstitution + " / " + currentCharacter.FifthConstitution);
                WriteLine("Dexterity   : " + currentCharacter.Dexterity + " / " + currentCharacter.HalfDexterity + " / " + currentCharacter.FifthDexterity);
                WriteLine("Intelligence: " + currentCharacter.Intelligence + " / " + currentCharacter.HalfIntelligence + " / " + currentCharacter.FifthIntelligence);
                WriteLine("Luck        : " + currentCharacter.Luck + " / " + currentCharacter.HalfLuck + " / " + currentCharacter.FifthLuck);
                WriteLine("======================================================".Pastel("#3e3e42"));
                WriteLine("Name : " + currentCharacter.Name);
                WriteLine("Class: " + currentCharacter.currentClass + " Race: " + currentCharacter.currentRace + " Gender: " + currentCharacter.currentGender);
                WriteLine("======================================================".Pastel("#3e3e42"));
                WriteLine("Gold          :        " + currentCharacter.Gold);
                WriteLine("Herbs         :        " + currentCharacter.Herbs);
                WriteLine("Ammunition    :        " + currentCharacter.Ammo + " / " + currentCharacter.MaxAmmo);
                WriteLine("Damage Bonus  :        +" + currentCharacter.DmgBonus);
                WriteLine("Melee         :        " + currentCharacter.Melee + " / " + currentCharacter.MaxMelee);
                WriteLine("Ranged        :        " + currentCharacter.Ranged + " / " + currentCharacter.MaxRanged);
                WriteLine("Toughness     :        " + currentCharacter.Toughness + " / " + currentCharacter.MaxToughness);
                WriteLine("Difficulty    :        " + currentCharacter.Mod);
                WriteLine("Hitpoints     :        " + currentCharacter.HitPoints + " / " + currentCharacter.MaxHitPoints);
                Write(" [".Pastel("#3e3e42"));
                GUI.HpBar("+", " ", ((decimal)currentCharacter.HitPoints / (decimal)currentCharacter.MaxHitPoints), 25);
                WriteLine("]".Pastel("#3e3e42"));
                WriteLine("Stamina       :        " + currentCharacter.Stamina + " / " + currentCharacter.MaxStamina);
                Write(" [".Pastel("#3e3e42"));
                GUI.StaBar("+", " ", ((decimal)currentCharacter.Stamina / (decimal)currentCharacter.MaxStamina), 25);
                WriteLine("]".Pastel("#3e3e42"));
                WriteLine("Mana          :        " + currentCharacter.Mana + " / " + currentCharacter.MaxMana);
                Write(" [".Pastel("#3e3e42"));
                GUI.ManaBar("+", " ", ((decimal)currentCharacter.Mana / (decimal)currentCharacter.MaxMana), 25);
                WriteLine("]".Pastel("#3e3e42"));
                WriteLine("Level         :        " + currentCharacter.Lvl);
                WriteLine("Experience    :        " + currentCharacter.Xp);
                Write(" [".Pastel("#3e3e42"));
                GUI.XpBar("+", " ", ((decimal)currentCharacter.Xp / (decimal)currentCharacter.GetLevelUpValue()), 25);
                WriteLine("]".Pastel("#3e3e42"));
                WriteLine("======================================================".Pastel("#3e3e42"));
                ResetColor();
                string input = ReadLine().ToLower();
                if (input == "h" || input == "herbs")
                {
                    TryBuy("Herbs", herbsC);
                }
                else if (input == "m" || input == "melee")
                {
                    TryBuy("Melee", meleeC);
                }
                else if (input == "t" || input == "toughness")
                {
                    TryBuy("Toughness", toughC);
                }
                else if (input == "d" || input == "difficulty")
                {
                    TryBuy("Difficulty", difficulty);
                }
                else if (input == "a" || input == "ammo")
                {
                    TryBuy("Ammo", ammoC);
                }
                else if (input == "r" || input == "ranged")
                {
                    TryBuy("Ranged", rangedC);
                }
                else if (input == "s" || input == "sleep")
                {
                    Print("Do you want to make a (S)hort or a (L)ong rest?");

                    string input2 = ReadLine().ToLower();
                    if (input2 == "s" || input2 == "short")
                    {
                        Print("You rest for a few hours and regain some of your lost health and stamina.");
                        currentCharacter.HitPoints += RNG.D10();
                        currentCharacter.Stamina = currentCharacter.MaxStamina;
                        if (currentCharacter.HitPoints > currentCharacter.MaxHitPoints)
                        {
                            currentCharacter.HitPoints = currentCharacter.MaxHitPoints;
                        }
                        Print("You now have: " + currentCharacter.HitPoints + " hitpoints out of: " + currentCharacter.MaxHitPoints + " and: " + currentCharacter.Stamina + " stamina out of: " + currentCharacter.MaxStamina);
                    }
                    else if (input2 == "l" || input2 == "long")
                    {
                        Print("You rest untill you have regained all of your health, stamina and mana.");
                        currentCharacter.HitPoints = currentCharacter.MaxHitPoints;
                        currentCharacter.Stamina = currentCharacter.MaxStamina;
                        currentCharacter.Mana = currentCharacter.MaxMana;
                    }
                    ReadKey();
                }
                else if (input == "q" || input == "quit")
                {
                    Environment.Exit(0);
                }
                else if (input == "b" || input == "back")
                {
                    Clear();
                    GameReturn();
                }
            }
        }
        private static void TryBuy(string item, int cost)
        {
            if (currentCharacter.Gold >= cost)
            {
                if (item == "Herbs")
                {
                    currentCharacter.Herbs ++;
                    if (currentCharacter.Herbs > currentCharacter.MaxHerbs)
                    {
                        currentCharacter.Herbs = currentCharacter.MaxHerbs;
                    }
                }
                else if (item == "Melee")
                {
                    currentCharacter.Melee ++;
                    if (currentCharacter.Melee > currentCharacter.MaxMelee)
                    {
                        currentCharacter.Melee = currentCharacter.MaxMelee;
                    }
                }
                else if (item == "Toughness")
                {
                    currentCharacter.Toughness ++;
                    if (currentCharacter.Toughness > currentCharacter.MaxToughness)
                    {
                        currentCharacter.Toughness = currentCharacter.MaxToughness;
                    }
                }
                else if (item == "Ammo")
                {
                    currentCharacter.Ammo += 5;
                    if (currentCharacter.Ammo > currentCharacter.MaxAmmo)
                    {
                        currentCharacter.Ammo = currentCharacter.MaxAmmo;
                    }
                }
                else if (item == "Ranged")
                {
                    currentCharacter.Ranged ++;
                    if (currentCharacter.Ranged > currentCharacter.MaxRanged)
                    {
                        currentCharacter.Ranged = currentCharacter.MaxRanged;
                    }
                }
                else if (item == "Difficulty")
                {
                    currentCharacter.Mod ++;
                }
                currentCharacter.Gold -= cost;
            }
            else
            {
                Print("You dont have enough gold to buy that!");
                ReadKey();
            }
        }
    }
}
