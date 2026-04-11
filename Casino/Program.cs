Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.ForegroundColor = ConsoleColor.Cyan;

//Console.WriteLine($"╔════════╗\n║⚡WILD⚡║\n║⚡WILD⚡║\n║⚡WILD⚡║\n╚════════╝");
//string cd_gold_disk = "📀";
string[] Matrix = new string[810];
for (int i = 0; i < Matrix.Length; i++)
{
    Matrix[i] = ".";
}
void Output()
{
    int i = 0;
    for (int j = 0; j < 15; j++)
    {
        for (int k = 0; k < 54; k++)
        {
            Console.Write(Matrix[i]);
            i++;
        }
        Console.WriteLine();
    }
}
Output();
string[] Symbols = { "🇯", "🇶", "🇰", "🇹", "🥝", "🍋", "🍒", "💎", "🔔" };
Random rand = new Random();
Slot_With_Symbol Slot_1 = new Slot_With_Symbol(Symbols[rand.Next(0, 8)], 0, 0);
Slot_1.Slot_Geometry_And_Output();
Slot_With_Symbol Slot_2 = new Slot_With_Symbol(Symbols[rand.Next(0, 8)], 0, 0);
Slot_2.Slot_Geometry_And_Output();
Slot_With_Symbol Slot_3 = new Slot_With_Symbol(Symbols[rand.Next(0, 8)], 0, 0);
Slot_3.Slot_Geometry_And_Output();

struct Slot_With_Symbol(string symbol, int slot_x0, int slot_y0 = 0)
{
    public static int scale = 1; // Scale of the interface
    public static int slot_hight = 3 + 2 * scale;
    public static int slot_width_vs_hight_ratio = 2;
    public static int slot_width = slot_hight * slot_width_vs_hight_ratio;
    public string[] Slot = new string[slot_hight * slot_width];
    int[] Slot_X = new int[slot_hight * slot_width];
    int[] Slot_Y = new int[slot_hight * slot_width];

    public void Slot_Geometry_And_Output()
    {
        for (int i = 0; i < slot_hight; i++)
        {
            for (int j = 0; j < slot_width; j++)
            {
                Slot_X[j] = slot_x0 + j;
            }
        }
        for (int i = 0; i < slot_width; i++)
        {
            for (int j = 0; j < slot_hight; j++)
            {
                Slot_Y[j] = slot_y0 + j;
            }
        }
        //Slot's geometry
        for (int i = 0; i < Slot.Length; i++)
        {
            if (i != Slot.Length / 2)
            {
                Slot[i] = " ";
            }
        }
        Slot[0] = "╔";
        Slot[Slot.Length / slot_hight - 1] = "╗";
        Slot[Slot.Length - slot_width] = "╚";
        Slot[Slot.Length - 1] = "╝";
        Slot[Slot.Length / 2 - 1] = symbol;
        for (int i = 1; i < slot_width - 1; i++)
        {
            Slot[i] = "═";
        }
        for (int i = Slot.Length - slot_width + 1; i < Slot.Length - 1; i++)
        {
            Slot[i] = "═";
        }
        for (int i = slot_width; i < Slot.Length - slot_width; )
        {
            Slot[i] = "║";
            i = i + slot_width;
        }
        for (int i = slot_width * 2 - 1; i < Slot.Length - slot_width; )
        {
            Slot[i] = "║";
            i = i + slot_width;
        }
        //Slot's output
        for (int i = 0; i < Slot.Length; )
        {
            for (int j = 0; j < slot_width; j++)
            {
                Console.Write(Slot[i]);
                i++;
            }
            Console.WriteLine();
        }
    }
}
