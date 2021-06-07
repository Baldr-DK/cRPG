using static cRPG.RNG;
namespace cRPG
{
    class Item
    {
        public static string GetWeapon()
        {            
                switch (rand.Next(0, 9))
                {
                    case 0:
                        return "Club";
                    case 1:
                        return "Shortsword";
                    case 2:
                        return "Longsword";
                    case 3:
                        return "Bastardsword";
                    case 4:
                        return "Shortspear";
                    case 5:
                        return "Spear";
                    case 6:
                        return "Halberd";
                    case 7:
                        return "Mace";
                    case 8:
                        return "Dagger";
                }
                return "Battleaxe";            
        }
        public static int Damage()
        {
            if (GetWeapon() == "Club")
            {
                int damage = D3();
                return damage;
            }
            else if (GetWeapon() == "Shortsword")
            {
                int damage = D6();
                return damage;
            }
            else if (GetWeapon() == "Longsword")
            {
                int damage = D8();
                return damage;
            }
            else if (GetWeapon() == "Bastardsword")
            {
                int damage = D8() + 2;
                return damage;
            }
            else if (GetWeapon() == "Spear")
            {
                int damage = D6() + 2;
                return damage;
            }
            else if (GetWeapon() == "Halberd")
            {
                int damage = D12();
                return damage;
            }
            else if (GetWeapon() == "Mace")
            {
                int damage = D6() + 1;
                return damage;
            }
            else if (GetWeapon() == "Dagger")
            {
                int damage = D4();
                return damage;
            }
            else if (GetWeapon() == "Battleaxe")
            {
                int damage = D8() + 1;
                return damage;
            }
            return D2();
        }
    }
}
