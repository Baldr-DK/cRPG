using Pastel;
using static System.Console;
namespace cRPG
{
    class GUI
    {
        public static void HpBar(string filler, string background, decimal value, int size)
        {
            int diff = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < diff)
                    Write(filler.Pastel("#cb0435"));
                else
                    Write(background);
            }
        }
        public static void ManaBar(string filler, string background, decimal value, int size)
        {
            int diff = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < diff)
                    Write(filler.Pastel("#0435cb"));
                else
                    Write(background);
            }
        }
        public static void StaBar(string filler, string background, decimal value, int size)
        {
            int diff = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < diff)
                    Write(filler.Pastel("#35cb04"));
                else
                    Write(background);
            }
        }
        public static void XpBar(string filler, string background, decimal value, int size)
        {
            int diff = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < diff)
                    Write(filler.Pastel("#ffd700"));
                else
                    Write(background);
            }
        }
    }
}
