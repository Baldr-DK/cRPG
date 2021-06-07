using System;
using Figgle;
using static System.Console;
using static cRPG.Character;
using static cRPG.Enemy;
using static cRPG.Engine;
using static cRPG.Game;
using static cRPG.RNG;
namespace cRPG
{
    class Combat
    {
        private static readonly Enemy currentEnemy = new Enemy();         
        public static void GetEncounter()
        {
            Clear();
            Print("(B)asic Encounter\n(S)pecial Encounter");
            string input = ReadLine();
            if (input.ToLower() == "b")
                BasicEncounter();
            else if (input.ToLower() == "s")
                SpecialEncounter();
            else
                GetEncounter();
        }
        private static void SpecialEncounter()
        {
            Clear();
            CombatLoop(false, "Special Encounter", 10, 10, 10);
        }
        private static void BasicEncounter()
        {
            Clear();
            CombatLoop(true, "", 0, 0, 0);

        }
        private static void CombatLoop(bool random, string name, int hitDice, int defence, int damage)
        {         
            if (random)
            {
                name = GetBasicName();
                hitDice = currentEnemy.GetHitDice();
                defence = currentEnemy.GetDefence();
                damage = currentEnemy.GetDamage();
            }            
            while (hitDice > 0)
            {
                Clear();
                WriteLine("=============================");
                WriteLine(name);
                WriteLine("Attack: " + damage + " " + Item.GetWeapon() + " / Defence: " + defence + "  /  HitPoints: " + hitDice);
                WriteLine("=============================\n\n");
                WriteLine(FiggleFonts.Amc3Line.Render("    VS"));
                WriteLine("\n\n=============================");
                WriteLine(currentCharacter.Name + " / " + currentCharacter.currentClass);
                WriteLine("level: " + currentCharacter.Lvl);
                WriteLine("_____________________________");
                WriteLine("|(M)elee   //  (R)anged     |");
                WriteLine("|(D)odge   //  (H)eal       |");
                WriteLine("|(F)eat    //  (S)pell      |");
                WriteLine("|     (E)scape to camp      |");
                WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                WriteLine("Ammunition : " + currentCharacter.Ammo + "/" + currentCharacter.MaxAmmo + "  //  Herbs    : " + currentCharacter.Herbs + "/" + currentCharacter.MaxHerbs);
                WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                WriteLine("Melee      : " + currentCharacter.Melee + "/" + currentCharacter.MaxMelee + "    //  Ranged   : " + currentCharacter.Ranged + "/" + currentCharacter.MaxRanged);
                WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                WriteLine("DamageBonus: +" + currentCharacter.DmgBonus + "      //  Toughness: " + currentCharacter.Toughness + "/" + currentCharacter.MaxToughness);
                WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                WriteLine("HitPoints : " + currentCharacter.HitPoints + "/" + currentCharacter.MaxHitPoints);
                Write(" [");
                GUI.HpBar("+", " ", ((decimal)currentCharacter.HitPoints / (decimal)currentCharacter.MaxHitPoints), 25);
                WriteLine("]");
                WriteLine("Stamina   : " + currentCharacter.Stamina + "/" + currentCharacter.MaxStamina);
                Write(" [");
                GUI.StaBar("+", " ", ((decimal)currentCharacter.Stamina / (decimal)currentCharacter.MaxStamina), 25);
                WriteLine("]");
                WriteLine("Mana      : " + currentCharacter.Mana + "/" + currentCharacter.MaxMana);
                Write(" [");
                GUI.ManaBar("+", " ", ((decimal)currentCharacter.Mana / (decimal)currentCharacter.MaxMana), 25);
                WriteLine("]");
                WriteLine("Experience: " + currentCharacter.Xp + "/" + currentCharacter.GetLevelUpValue() + " Level Up");
                Write(" [");
                GUI.XpBar("+", " ", ((decimal)currentCharacter.Xp / (decimal)currentCharacter.GetLevelUpValue()), 25);
                WriteLine("]");
                WriteLine("______________________________");
                string input = ReadLine();
                if (input.ToLower() == "m")
                {
                    Print("You try to hit the " + name);
                    int eDmg = damage + D8() - currentCharacter.Toughness;
                    if (eDmg < 0)
                        eDmg = 0;
                    if (currentCharacter.GetHit() >= defence)
                    {
                        int pDmg = rand.Next(0, currentCharacter.Melee) + D8() + currentCharacter.DmgBonus;
                        Print("You hit the " + name + " for: " + pDmg + " damage, and take: " + eDmg + " damage!");
                        hitDice -= pDmg;
                    }
                    else
                    {
                        Print("You miss the " + name + " and take: " + eDmg + " damage!");
                    }
                    currentCharacter.HitPoints -= eDmg;
                }
                else if (input.ToLower() == "r")
                {
                    if (currentCharacter.Ammo == 0)
                    {
                        int eDmg = damage - currentCharacter.Toughness;
                        if (eDmg < 0)
                            eDmg = 0;
                        Print("You are out of ammunition, the:" + name + " close the distance, you take: " + eDmg + " damage!");
                        currentCharacter.HitPoints -= eDmg;
                    }
                    else
                    {
                        currentCharacter.Ammo -= 1;
                        if (currentCharacter.GetHit() >= defence)
                        {
                            int pDmg = rand.Next(0, currentCharacter.Ranged) + D8();
                            Print("You hit the " + name + " for: " + pDmg + " damage!");
                            hitDice -= pDmg;
                        }
                        else
                        {
                            Print("You miss the " + name);
                        }
                    }
                }
                else if (input.ToLower() == "d")
                {
                    Print("You dodge carefully while attacking!");
                    int eDmg = damage + D8() / 4 - currentCharacter.Toughness;
                    if (eDmg < 0)
                        eDmg = 0;
                    if (currentCharacter.GetHit() >= defence)
                    {
                        int pDmg = rand.Next(0, currentCharacter.Melee) + D8() + currentCharacter.DmgBonus / 2;
                        Print("You hit the " + name + " for: " + pDmg + " damage, and take: " + eDmg + " damage!");
                        hitDice -= pDmg;
                    }
                    else
                    {
                        Print("You miss the " + name + " and take: " + eDmg + " damage!");
                    }
                    currentCharacter.HitPoints -= eDmg;
                }
                else if (input.ToLower() == "h")
                {
                    if (currentCharacter.currentClass != CharacterClass.Wizard)
                    {
                        if (currentCharacter.Herbs == 0)
                        {
                            int eDmg = damage + D8() - currentCharacter.Toughness;
                            if (eDmg < 0)
                                eDmg = 0;
                            Print("You are out of herbs, you take: " + eDmg + " damage!");
                            currentCharacter.HitPoints -= eDmg;
                        }
                        else
                        {
                            int heal = 10;
                            int eDmg = damage / 2 - currentCharacter.Toughness;
                            if (eDmg < 0)
                                eDmg = 0;
                            currentCharacter.HitPoints += heal;
                            if (currentCharacter.HitPoints > currentCharacter.MaxHitPoints)
                            {
                                currentCharacter.HitPoints = currentCharacter.MaxHitPoints;
                            }
                            Print("You heal: " + heal + " hitpoints, and take: " + eDmg + " damage!");
                            currentCharacter.HitPoints -= eDmg;
                        }
                    }
                    else
                    {
                        Print("Do you want to use a healing h(e)rb or cast a healing (s)pell?");
                        input = ReadLine().ToLower();
                        if (input.ToLower() == "e")
                        {
                            if (currentCharacter.Herbs == 0)
                            {
                                int eDmg = damage + D8() - currentCharacter.Toughness;
                                if (eDmg < 0)
                                    eDmg = 0;
                                Print("You are out of herbs, you take: " + eDmg + " damage!");
                                currentCharacter.HitPoints -= eDmg;
                            }
                            else
                            {
                                int heal = 10;
                                int eDmg = damage / 2 - currentCharacter.Toughness;
                                if (eDmg < 0)
                                    eDmg = 0;
                                currentCharacter.HitPoints += heal;
                                if (currentCharacter.HitPoints > currentCharacter.MaxHitPoints)
                                {
                                    currentCharacter.HitPoints = currentCharacter.MaxHitPoints;
                                }
                                Print("You heal: " + heal + " hitpoints, and take: " + eDmg + " damage!");
                                currentCharacter.HitPoints -= eDmg;
                            }
                        }
                        else if (input.ToLower() == "s")
                        {
                            if (currentCharacter.Mana >= 21)
                            {
                                int cure = currentCharacter.FifthIntelligence;
                                int eDmg = damage / 2 - currentCharacter.Toughness;
                                if (eDmg < 0)
                                    eDmg = 0;
                                currentCharacter.HitPoints += cure;
                                Print("You cast a healing spell and: " + cure + " hitpoints are cured!\nHowever the " + name + "attacks you for " + eDmg + " damage!");
                                currentCharacter.Mana -= 20;
                                currentCharacter.HitPoints -= eDmg;
                            }
                            else
                                Print("You do not have enough mana to cast healing");
                        }
                    }
                }
                else if (input.ToLower() == "f")
                {
                    if (currentCharacter.currentClass == CharacterClass.Fighter)
                        Print("FIGHTER FEAT MENU:\n(P)ower attack\n(B)ash");
                    input = ReadLine().ToLower();
                    if (input == "p")
                    {
                        if (currentCharacter.Stamina >= 21)
                        {
                            int pdmg = currentCharacter.FifthStrength + D20() + currentCharacter.Lvl;
                            Print("You power attack the " + name + " for " + pdmg + " hitpoints of damage");
                            hitDice -= pdmg;
                            currentCharacter.Stamina -= 20;
                            ReadKey();
                        }
                        else
                            Print("You do not have enough stamina to use that ability");
                    }
                    else if (input == "b")
                    {
                        if (currentCharacter.Stamina >= 11)
                        {
                            Print("You bash the " + name + " is confuzed and dazzed!");
                            currentCharacter.Stamina -= 10;
                            defence -= defence / 3;
                            damage -= damage / 3;
                            ReadKey();
                        }
                        else
                            Print("You do not have enough stamina to use that ability");
                    }
                    else if (currentCharacter.currentClass == CharacterClass.Rogue)
                    {
                        Print("ROGUE FEAT MENU:\n(B)ackstab\n(S)moke Bomb");
                        input = ReadLine().ToLower();
                        if (input == "b" || input == "backstab")
                        {
                            if (currentCharacter.Stamina >= 21)
                            {
                                int pdmg = currentCharacter.FifthDexterity + D20() * currentCharacter.Lvl;
                                Print("You backstab the " + name + " for " + pdmg + " hitpoints of damage");
                                hitDice -= pdmg;
                                currentCharacter.Stamina -= 20;
                                ReadKey();
                            }
                            else
                                Print("You do not have enough stamina to use that ability");
                        }
                        else if (input == "s" || input == "smokebomb")
                        {
                            if (currentCharacter.Stamina >= 21)
                            {
                                Print("You drop a smoke bomb and the " + name + " is confuzed and dazzed!");
                                currentCharacter.Stamina -= 20;
                                defence -= defence / 2;
                                damage -= damage / 2;
                                ReadKey();
                            }
                            else
                                Print("You do not have enough stamina to use that ability");
                        }
                    }
                }
                else if (input.ToLower() == "s")
                {
                    if (currentCharacter.currentClass == CharacterClass.Wizard)
                    {
                        Print("MAGIC MENU\n(M)agic Missile\n(F)ire Bolt\n(f(I)re Ball\nf(L)ame Strike\nm(E)teor Swarm\n(H)ell Storm");
                        input = ReadLine().ToLower();
                        if (input == "m" || input == "magic missile")
                        {
                            if (currentCharacter.Mana >= 5 + 1)
                            {
                                int pdmg = D6M(2);
                                Print("You cast magic missile and deal: " + pdmg + " hitpoints of damage");
                                currentCharacter.Mana -= 5;
                                hitDice -= pdmg;
                            }
                            else
                                Print("You do not have enough mana to cast magic missile");
                        }
                        else if (input == "f" || input == "fire bolt")
                        {
                            if (currentCharacter.Mana >= 11)
                            {
                                int pdmg = D12M(2);
                                Print("You cast fire bolt and deal: " + pdmg + " hitpoints of damage");
                                currentCharacter.Mana -= 10;
                                hitDice -= pdmg;
                            }
                            else
                                Print("You do not have enough mana to cast fire bolt");

                        }
                        else if (input == "i" || input == "fire ball")
                        {
                            if (currentCharacter.Mana >= 16)
                            {
                                int pdmg = D20M(2);
                                Print("You cast fire ball and deal: " + pdmg + " hitpoints of damage");
                                currentCharacter.Mana -= 15;
                                hitDice -= pdmg;
                            }
                            else
                                Print("You do not have enough mana to cast fire ball");

                        }
                        else if (input == "l" || input == "flame strike")
                        {
                            if (currentCharacter.Mana >= 21)
                            {
                                int pdmg = D20M(4);
                                Print("You cast flame strike and deal: " + pdmg + " hitpoints of damage");
                                currentCharacter.Mana -= 20;
                                hitDice -= pdmg;
                            }
                            else
                                Print("You do not have enough mana to cast flame strike");

                        }
                        else if (input == "e" || input == "meteor swarm")
                        {
                            if (currentCharacter.Mana >= 31)
                            {
                                int pdmg = D20M(8);
                                Print("You cast meteor swarm and deal: " + pdmg + " hitpoints of damage");
                                currentCharacter.Mana -= 30;
                                hitDice -= pdmg;
                            }
                            else
                                Print("You do not have enough mana to cast meteor swarm");

                        }
                        else if (input == "h" || input == "hell storm")
                        {
                            if (currentCharacter.Mana >= 41)
                            {
                                int pdmg = D100M(2);
                                Print("You cast hell storm and deal: " + pdmg + " hitpoints of damage");
                                currentCharacter.Mana -= 40;
                                hitDice -= pdmg;
                            }
                            else
                                Print("You do not have enough mana to cast hell storm");
                        }
                    }
                    else
                        Print("You do not have any spells!");
                    ReadKey();
                }
                else if (input.ToLower() == "e")
                {
                    if (rand.Next(0, 2) == 0 && currentCharacter.currentClass != CharacterClass.Rogue)
                    {
                        Print("You try to escape but the " + name + " catches you in the back");
                        int edmg = damage + rand.Next(1, 3) - currentCharacter.Toughness;
                        if (edmg < 0)
                            edmg = 0;
                        Print("You lose " + edmg + " hitpoints and have to fight");
                        currentCharacter.HitPoints -= edmg;

                    }
                    else
                    {
                        Print("You try to escape the " + name + " , and your gamble pays off!");
                        Home.LoadHome();
                    }
                }
                if (currentCharacter.HitPoints <= 0)
                {
                    Clear();
                    Print("DEAD");
                    ReadKey();
                    Environment.Exit(0);
                }
            }
            int gold = currentCharacter.GetGold();
            int xp = currentCharacter.GetXp();
            Print("You killed: " + name + " and find: " + gold + " gold, and get: " + xp + " experience.");
            currentCharacter.Gold += gold;
            currentCharacter.Xp += xp;
            if (currentCharacter.CanLevelUp())
            {
                currentCharacter.LevelUp();
            }
            ReadKey();
            Clear();
            GameReturn();
        }
    }
}
