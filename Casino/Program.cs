using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.ForegroundColor = ConsoleColor.Cyan;

//Console.WriteLine($"╔════════╗\n║⚡WILD⚡║\n║⚡WILD⚡║\n║⚡WILD⚡║\n╚════════╝");
//string cd_gold_disk = "📀";
int matrix_width = 54;
int matrix_hight = 15;
int matrix_square = matrix_width * matrix_hight;
string[] Matrix = new string[matrix_square];

for (int i = 0; i < Matrix.Length; i++)
{
    Matrix[i] = ".";
}

string[] Symbols = { "🇯", "🇶", "🇰", "🇹", "🥝", "🍋", "🍒", "💎", "🔔" };
Random rand = new Random();

Slot_Characteristics Slot_Graphics(Slot_Characteristics Slot_With_Symbol)
{
    //Slot's Sizing
    int slot_hight = 3 + 2 * Slot_With_Symbol.slot_scale;
    int slot_width = slot_hight * 2;
    int slot_square = slot_hight * slot_width;

    //Slot's Symbol
    Slot_With_Symbol.Slot_Graphic_Elements = new string[slot_square];

    //Slot's Coordinates
    Slot_With_Symbol.Slot_X = new int[slot_square];
    Slot_With_Symbol.Slot_Y = new int[slot_square];
    for (int i = 0; i < slot_hight; i++)
    {
        for (int j = 0; j < slot_width; j++)
        {
            Slot_With_Symbol.Slot_X[j + slot_width * i] = Slot_With_Symbol.slot_x0 + j;
            Slot_With_Symbol.Slot_Y[j + slot_width * i] = Slot_With_Symbol.slot_y0 + i;
        }
    }

    //Slot's Graphic Elements
    for (int i = 0; i < Slot_With_Symbol.Slot_Graphic_Elements.Length; i++)
    {
        if (i != Slot_With_Symbol.Slot_Graphic_Elements.Length / 2)
        {
            Slot_With_Symbol.Slot_Graphic_Elements[i] = " ";
        }
    }
    Slot_With_Symbol.Slot_Graphic_Elements[0] = "╔";
    Slot_With_Symbol.Slot_Graphic_Elements[
        Slot_With_Symbol.Slot_Graphic_Elements.Length / slot_hight - 1
    ] = "╗";
    Slot_With_Symbol.Slot_Graphic_Elements[
        Slot_With_Symbol.Slot_Graphic_Elements.Length - slot_width
    ] = "╚";
    Slot_With_Symbol.Slot_Graphic_Elements[Slot_With_Symbol.Slot_Graphic_Elements.Length - 1] = "╝";
    Slot_With_Symbol.Slot_Graphic_Elements[Slot_With_Symbol.Slot_Graphic_Elements.Length / 2 - 1] =
        Slot_With_Symbol.slot_symbol;
    for (int i = 1; i < slot_width - 1; i++)
    {
        Slot_With_Symbol.Slot_Graphic_Elements[i] = "═";
    }
    for (
        int i = Slot_With_Symbol.Slot_Graphic_Elements.Length - slot_width + 1;
        i < Slot_With_Symbol.Slot_Graphic_Elements.Length - 1;
        i++
    )
    {
        Slot_With_Symbol.Slot_Graphic_Elements[i] = "═";
    }
    for (int i = slot_width; i < Slot_With_Symbol.Slot_Graphic_Elements.Length - slot_width; )
    {
        Slot_With_Symbol.Slot_Graphic_Elements[i] = "║";
        i = i + slot_width;
    }
    for (
        int i = slot_width * 2 - 1;
        i < Slot_With_Symbol.Slot_Graphic_Elements.Length - slot_width;

    )
    {
        Slot_With_Symbol.Slot_Graphic_Elements[i] = "║";
        i = i + slot_width;
    }

    //Slot's Writing To Matrix
    for (int i = 0; i < Slot_With_Symbol.Slot_Graphic_Elements.Length; i++)
    {
        Matrix[matrix_width * Slot_With_Symbol.Slot_Y[i] + Slot_With_Symbol.Slot_X[i]] =
            Slot_With_Symbol.Slot_Graphic_Elements[i];
    }

    return Slot_With_Symbol;
}
void All_Slots()
{
    var Slot_1 = new Slot_Characteristics
    {
        slot_x0 = 0,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_1 = Slot_Graphics(Slot_1);

    var Slot_2 = new Slot_Characteristics
    {
        slot_x0 = 11,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_2 = Slot_Graphics(Slot_2);

    var Slot_3 = new Slot_Characteristics
    {
        slot_x0 = 22,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_3 = Slot_Graphics(Slot_3);

    var Slot_4 = new Slot_Characteristics
    {
        slot_x0 = 33,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_4 = Slot_Graphics(Slot_4);

    var Slot_5 = new Slot_Characteristics
    {
        slot_x0 = 44,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_5 = Slot_Graphics(Slot_5);

    var Slot_6 = new Slot_Characteristics
    {
        slot_x0 = 0,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_6 = Slot_Graphics(Slot_6);

    var Slot_7 = new Slot_Characteristics
    {
        slot_x0 = 11,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_7 = Slot_Graphics(Slot_7);

    var Slot_8 = new Slot_Characteristics
    {
        slot_x0 = 22,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_8 = Slot_Graphics(Slot_8);

    var Slot_9 = new Slot_Characteristics
    {
        slot_x0 = 33,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_9 = Slot_Graphics(Slot_9);

    var Slot_10 = new Slot_Characteristics
    {
        slot_x0 = 44,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_10 = Slot_Graphics(Slot_10);

    var Slot_11 = new Slot_Characteristics
    {
        slot_x0 = 0,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_11 = Slot_Graphics(Slot_11);

    var Slot_12 = new Slot_Characteristics
    {
        slot_x0 = 11,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_12 = Slot_Graphics(Slot_12);

    var Slot_13 = new Slot_Characteristics
    {
        slot_x0 = 22,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_13 = Slot_Graphics(Slot_13);

    var Slot_14 = new Slot_Characteristics
    {
        slot_x0 = 33,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_14 = Slot_Graphics(Slot_14);

    var Slot_15 = new Slot_Characteristics
    {
        slot_x0 = 44,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, 8)]
    };
    Slot_15 = Slot_Graphics(Slot_15);
}
All_Slots();

void Output()
{
    int i = 0;
    for (int j = 0; j < matrix_hight; j++)
    {
        for (int k = 0; k < matrix_width; k++)
        {
            Console.Write(Matrix[i]);
            i++;
        }
        Console.WriteLine();
    }
}
Output();

struct Slot_Characteristics
{
    public int slot_x0;
    public int slot_y0;
    public int slot_scale;
    public string slot_symbol;
    public string[] Slot_Graphic_Elements;
    public int[] Slot_X;
    public int[] Slot_Y;
}
