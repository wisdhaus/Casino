using System.Numerics;

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

Slot_With_Symbol Slot_1 = new Slot_With_Symbol(Symbols[rand.Next(0, 8)], 1, 0, 0);
Slot_1.Slot_Characteristics();
Slot_With_Symbol Slot_2 = new Slot_With_Symbol(Symbols[rand.Next(0, 8)], 1, 0, 0);
Slot_2.Slot_Characteristics();
Slot_With_Symbol Slot_3 = new Slot_With_Symbol(Symbols[rand.Next(0, 8)], 1, 0, 0);
Slot_3.Slot_Characteristics();

struct Slot_With_Symbol(string symbol, int scale, int slot_x0, int slot_y0 = 0)
{
    public void Slot_Characteristics()
    {
        int slot_hight = 3 + 2 * scale;
        int slot_width = slot_hight * 2;
        int slot_square = slot_hight * slot_width;
        string[] Slot_Graphic_Elements = new string[slot_square];
        //Slot's Coordinates
        int[] Slot_X = new int[slot_square];
        int[] Slot_Y = new int[slot_square];

        for (int i = 0; i < slot_hight; i++)
        {
            for (int j = 0; j < slot_width; j++)
            {
                Slot_X[j + slot_width * i] = slot_x0 + j;
                Slot_Y[j + slot_width * i] = slot_y0 + i;
            }
        }

        //Slot's Graphics
        for (int i = 0; i < Slot_Graphic_Elements.Length; i++)
        {
            if (i != Slot_Graphic_Elements.Length / 2)
            {
                Slot_Graphic_Elements[i] = " ";
            }
        }
        Slot_Graphic_Elements[0] = "╔";
        Slot_Graphic_Elements[Slot_Graphic_Elements.Length / slot_hight - 1] = "╗";
        Slot_Graphic_Elements[Slot_Graphic_Elements.Length - slot_width] = "╚";
        Slot_Graphic_Elements[Slot_Graphic_Elements.Length - 1] = "╝";
        Slot_Graphic_Elements[Slot_Graphic_Elements.Length / 2 - 1] = symbol;
        for (int i = 1; i < slot_width - 1; i++)
        {
            Slot_Graphic_Elements[i] = "═";
        }
        for (
            int i = Slot_Graphic_Elements.Length - slot_width + 1;
            i < Slot_Graphic_Elements.Length - 1;
            i++
        )
        {
            Slot_Graphic_Elements[i] = "═";
        }
        for (int i = slot_width; i < Slot_Graphic_Elements.Length - slot_width; )
        {
            Slot_Graphic_Elements[i] = "║";
            i = i + slot_width;
        }
        for (int i = slot_width * 2 - 1; i < Slot_Graphic_Elements.Length - slot_width; )
        {
            Slot_Graphic_Elements[i] = "║";
            i = i + slot_width;
        }

        //Slot's output
        for (int i = 0; i < Slot_Graphic_Elements.Length; )
        {
            for (int j = 0; j < slot_width; j++)
            {
                Console.Write(Slot_Graphic_Elements[i]);
                i++;
            }
            Console.WriteLine();
        }
    }
}
