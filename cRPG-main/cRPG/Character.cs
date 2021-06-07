using System.Linq;
using static System.Console;
using static cRPG.Game;
using static cRPG.Engine;
using static cRPG.RNG;
namespace cRPG
{
    class Character
    {
        private int mod = 1;
        private int lvl = 1;
        private int xp = 0;
        private int gold = 0;
        private int herbs = 3;
        private int maxHerbs = 10;
        private int melee = 1;
        private int maxMelee = 10;
        private int ranged = 1;
        private int maxRanged = 10;
        private int toughness = 0;
        private int maxToughness = 10;
        private int ammo = 10;
        private int maxAmmo = 20;
        private int dmgBonus = 0;
        private int hitPoints = 0;
        private int maxHitPoints = 0;
        private int stamina = 0;
        private int maxStamina = 0;
        private int mana = 0;
        private int maxMana = 0;

        private int strength = 0;
        private int halfStrength = 0;
        private int fifthStrength = 0;
        private int constitution = 0;
        private int halfConstitution = 0;
        private int fifthConstitution = 0;
        private int dexterity = 0;
        private int halfDexterity = 0;
        private int fifthDexterity = 0;
        private int intelligence = 0;
        private int halfIntelligence = 0;
        private int fifthIntelligence = 0;
        private int luck = 0;
        private int halfLuck = 0;
        private int fifthLuck = 0;

        private string name;

        public enum CharacterRace { Human, Elf, HalfElf, Dwarf, Halfling };
        public CharacterRace currentRace = CharacterRace.Human;
        public enum CharacterGender { Male, Female };
        public CharacterGender currentGender = CharacterGender.Male;
        public enum CharacterClass { Fighter, Rogue, Wizard };
        public CharacterClass currentClass = CharacterClass.Fighter;
        public int Mod
        {
            get
            {
                return currentCharacter.mod;
            }
            set
            {
                mod = value;
            }
        }
        public int Lvl
        {
            get
            {
                return currentCharacter.lvl;
            }
            set
            {
                lvl = value;
            }
        }
        public int Xp
        {
            get
            {
                return currentCharacter.xp;
            }
            set
            {
                xp = value;
            }
        }
        public int Gold
        {
            get
            {
                return currentCharacter.gold;
            }
            set
            {
                gold = value;
            }
        }
        public int Herbs
        {
            get
            {
                return currentCharacter.herbs;
            }
            set
            {
                herbs = value;
            }
        }
        public int MaxHerbs
        {
            get
            {
                return currentCharacter.maxHerbs;
            }
            set
            {
                maxHerbs = value;
            }
        }
        public int Melee
        {
            get
            {
                return currentCharacter.melee;
            }
            set
            {
                melee = value;
            }
        }
        public int MaxMelee
        {
            get
            {
                return currentCharacter.maxMelee;
            }
            set
            {
                maxMelee = value;
            }
        }
        public int Ranged
        {
            get
            {
                return currentCharacter.ranged;
            }
            set
            {
                ranged = value;
            }
        }
        public int MaxRanged
        {
            get
            {
                return currentCharacter.maxRanged;
            }
            set
            {
                maxRanged = value;
            }
        }
        public int Toughness
        {
            get
            {
                return currentCharacter.toughness;
            }
            set
            {
                toughness = value;
            }
        }
        public int MaxToughness
        {
            get
            {
                return currentCharacter.maxToughness;
            }
            set
            {
                maxToughness = value;
            }
        }
        public int Ammo
        {
            get
            {
                return currentCharacter.ammo;
            }
            set
            {
                ammo = value;
            }
        }
        public int MaxAmmo
        {
            get
            {
                return currentCharacter.maxAmmo;
            }
            set
            {
                maxAmmo = value;
            }
        }
        public int DmgBonus
        {
            get
            {
                return currentCharacter.dmgBonus;
            }
            set
            {
                dmgBonus = value;
            }
        }
        public int HitPoints
        {
            get
            {
                return currentCharacter.hitPoints;
            }
            set
            {
                hitPoints = value;
            }
        }
        public int MaxHitPoints
        {
            get
            {
                return currentCharacter.maxHitPoints;
            }
            set
            {
                maxHitPoints = value;
            }
        }
        public int Stamina
        {
            get
            {
                return currentCharacter.stamina;
            }
            set
            {
                stamina = value;
            }
        }
        public int MaxStamina
        {
            get
            {
                return currentCharacter.maxStamina;
            }
            set
            {
                maxStamina = value;
            }
        }
        public int Mana
        {
            get
            {
                return currentCharacter.mana;
            }
            set
            {
                mana = value;
            }
        }
        public int MaxMana
        {
            get
            {
                return currentCharacter.maxMana;
            }
            set
            {
                maxMana = value;
            }
        }
        public int Strength
        {
            get
            {
                return currentCharacter.strength;
            }
            set
            {
                strength = value;
            }
        }
        public int HalfStrength
        {
            get
            {
                return currentCharacter.halfStrength;
            }
            set
            {
                halfStrength = value;
            }
        }
        public int FifthStrength
        {
            get
            {
                return currentCharacter.fifthStrength;
            }
            set
            {
                fifthStrength = value;
            }
        }
        public int Constitution
        {
            get
            {
                return currentCharacter.constitution;
            }
            set
            {
                constitution = value;
            }
        }
        public int HalfConstitution
        {
            get
            {
                return currentCharacter.halfConstitution;
            }
            set
            {
                halfConstitution = value;
            }
        }
        public int FifthConstitution
        {
            get
            {
                return currentCharacter.fifthConstitution;
            }
            set
            {
                fifthConstitution = value;
            }
        }
        public int Dexterity
        {
            get
            {
                return currentCharacter.dexterity;
            }
            set
            {
                dexterity = value;
            }
        }
        public int HalfDexterity
        {
            get
            {
                return currentCharacter.halfDexterity;
            }
            set
            {
                halfDexterity = value;
            }
        }
        public int FifthDexterity
        {
            get
            {
                return currentCharacter.fifthDexterity;
            }
            set
            {
                fifthDexterity = value;
            }
        }
        public int Intelligence
        {
            get
            {
                return currentCharacter.intelligence;
            }
            set
            {
                intelligence = value;
            }
        }
        public int HalfIntelligence
        {
            get
            {
                return currentCharacter.halfIntelligence;
            }
            set
            {
                halfIntelligence = value;
            }
        }
        public int FifthIntelligence
        {
            get
            {
                return currentCharacter.fifthIntelligence;
            }
            set
            {
                fifthIntelligence = value;
            }
        }
        public int Luck
        {
            get
            {
                return currentCharacter.luck;
            }
            set
            {
                luck = value;
            }
        }
        public int HalfLuck
        {
            get
            {
                return currentCharacter.halfLuck;
            }
            set
            {
                halfLuck = value;
            }
        }
        public int FifthLuck
        {
            get
            {
                return currentCharacter.fifthLuck;
            }
            set
            {
                fifthLuck = value;
            }
        }
        public string Name
        {
            get
            {
                return currentCharacter.name;
            }
            set
            {
                name = value;
            }
        }        
        public int DamageBonus()
        {            
            if (Enumerable.Range(2, 34).Contains(currentCharacter.Strength))
            {
                return +1;
            }
            else if (Enumerable.Range(35, 54).Contains(currentCharacter.Strength))
            {
                return +2;
            }
            else if (Enumerable.Range(55, 94).Contains(currentCharacter.Strength))
            {
                return +4;
            }
            else if (Enumerable.Range(95, 134).Contains(currentCharacter.Strength))
            {
                return +8;
            }
            else if (Enumerable.Range(135, 194).Contains(currentCharacter.Strength))
            {
                return +16;
            }
            else if (Enumerable.Range(195, 295).Contains(currentCharacter.Strength))
            {
                return +32;
            }
            return +0;
        }
        public int CalcHitPoints()
        {
            int hp = FifthConstitution;
            return hp;
        }
        public int CalcMaxHitPoints()
        {
            int maxHp = FifthConstitution;
            return maxHp;
        }
        public int CalcMana()
        {
            int mana = FifthIntelligence;
            return mana;
        }
        public int CalcMaxMana()
        {
            int maxMana = FifthIntelligence;
            return maxMana;
        }
        public int CalcStamina()
        {
            int sta = HalfConstitution;
            return sta;
        }
        public int CalcMaxStamina()
        {
            int maxSta = HalfConstitution;
            return maxSta;
        }
        public int GetHit()
        {
            int max = Dexterity;
            int min = FifthDexterity;
            return rand.Next(min, max);
        }
        public int GetGold()
        {
            int max = Mod * FifthLuck + rand.Next(401, 800);
            int min = Mod * FifthLuck + rand.Next(100, 400);
            return rand.Next(min, max);
        }
        public int GetXp()
        {
            int max = Mod * FifthLuck + rand.Next(401, 600);
            int min = Mod * FifthLuck + rand.Next(201, 400);
            return rand.Next(min, max);
        }
        public int GetLevelUpValue()
        {
            return 100 * Lvl + 400;
        }
        public bool CanLevelUp()
        {
            if (Xp >= GetLevelUpValue())
                return true;
            else
                return false;
        }
        public void LevelUp()
        {
            while (CanLevelUp())
            {
                Xp -= GetLevelUpValue();
                Lvl++;
            }
            Clear();
            Print("Congratulations! You are now level " + Lvl + "!\nDifficulty have now been increased!");
            if (currentClass == CharacterClass.Fighter)
            {
                currentCharacter.MaxHitPoints += Mod + D12();
                currentCharacter.MaxStamina += Mod + D6();
                currentCharacter.Strength += 10;
                HalfStrength = Strength / 2;
                FifthStrength = Strength / 5; 
                if (Enumerable.Range(35, 54).Contains(currentCharacter.Strength))
                {
                    currentCharacter.DmgBonus += 1;
                }
                else if (Enumerable.Range(55, 94).Contains(currentCharacter.Strength))
                {
                    currentCharacter.DmgBonus += 1;
                }
                else if (Enumerable.Range(95, 134).Contains(currentCharacter.Strength))
                {
                    currentCharacter.DmgBonus += 2;
                }
                else if (Enumerable.Range(135, 194).Contains(currentCharacter.Strength))
                {
                    currentCharacter.DmgBonus += 3;
                }
                else if (Enumerable.Range(195, 295).Contains(currentCharacter.Strength))
                {
                    currentCharacter.DmgBonus += 4;
                }                
                currentCharacter.HitPoints = currentCharacter.MaxHitPoints;
                currentCharacter.Stamina = currentCharacter.MaxStamina;
                currentCharacter.Mana = currentCharacter.MaxMana;
                Print("You gained: 10 Strength, D12 Maximum Hitpoints and D6 Maximum Stamina!\n");
            }
            else if (currentClass == CharacterClass.Rogue)
            {
                currentCharacter.MaxHitPoints += Mod + D8();
                currentCharacter.MaxStamina += Mod + D10();
                currentCharacter.Dexterity += 10;
                HalfDexterity = Dexterity / 2;
                FifthDexterity = Dexterity / 5;
                currentCharacter.HitPoints = currentCharacter.MaxHitPoints;
                currentCharacter.Stamina = currentCharacter.MaxStamina;
                currentCharacter.Mana = currentCharacter.MaxMana;
                Print("You gained: 10 Dexterity, D8 Maximum Hitpoints and D10 Maximum Stamina!\n");
            }
            else if (currentClass == CharacterClass.Wizard)
            {
                currentCharacter.MaxHitPoints += Mod + D4();
                currentCharacter.MaxMana += Mod + D12();
                currentCharacter.Intelligence += 10;
                HalfIntelligence = Intelligence / 2;
                FifthIntelligence = Intelligence / 5;
                currentCharacter.HitPoints = currentCharacter.MaxHitPoints;
                currentCharacter.Stamina = currentCharacter.MaxStamina;
                currentCharacter.Mana = currentCharacter.MaxMana;
                Print("You gained: 10 Intelligence, D12 of Maximum Mana and D4 Maximum Hitpoints!\n");
            }
            Mod++;
            currentCharacter.GetGold();
            Print("You find something extra: " + Gold + " $.\nAnd your maximum hitpoints, stamina and mana are now " + MaxHitPoints + " / " + MaxStamina + " / " + MaxMana + " !");
            currentCharacter.Gold += Gold;
        }
    }
}

