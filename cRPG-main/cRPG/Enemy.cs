using static cRPG.Game;
using static cRPG.RNG;
namespace cRPG
{
    class Enemy
    {
        public static string GetBasicName()
        {
            switch (rand.Next(0, 14))
            {
                case 0:
                    return "Orc Fighter";
                case 1:
                    return "Orc Rogue";
                case 2:
                    return "Goblin Fighter";
                case 3:
                    return "Goblin Rogue";
                case 4:
                    return "Gnoll Fighter";
                case 5:
                    return "Human Fighter";
                case 6:
                    return "Human Rogue";
                case 7:
                    return "Half-Elf Fighter";
                case 8:
                    return "Half-Elf Rogue";
                case 9:
                    return "Elf Fighter";
                case 10:
                    return "Elf Rogue";
                case 11:
                    return "Dwarf Fighter";
                case 12:
                    return "Dwarf Rogue";
                case 13:
                    return "Halfling Fighter";
            }
            return "Halfling Rogue";
        }
        public int GetHitDice()
        {
            int hd = D10M(currentCharacter.Mod);
            return hd;
        }
        public int GetDefence()
        {
            int max = rand.Next(currentCharacter.Dexterity);
            int min = rand.Next(currentCharacter.FifthDexterity);
            if (min >= max)
            {
                min = max;
            }
            return rand.Next(min, max);
        }
        public int GetDamage()
        {
            int damage = Item.Damage();
            return damage;
        }
    }
}
