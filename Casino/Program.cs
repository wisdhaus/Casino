using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//string cd_gold_disk = "📀";
int matrix_width = 58;
int matrix_hight = 23;
int matrix_square = matrix_width * matrix_hight;
string[] Matrix = new string[matrix_square];
string[] Matrix_Color = new string[matrix_square];

string[] Symbols = { "🇯", "🇶", "🇰", "🇹", "🥝", "🍋", "🍒", "💎", "🔔", "⚡" };
string[] Wild_Symbol = { "", "⚡", "W", "I", "L", "D", "⚡", "" };
Random rand = new Random();

for (int i = 0; i < matrix_square; i++)
{
    Matrix[i] = ".";
}

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
    int all_slots_x = 2;
    int all_slots_y = 4;

    for (int i = 0; i < slot_hight; i++)
    {
        for (int j = 0; j < slot_width; j++)
        {
            Slot_With_Symbol.Slot_X[j + slot_width * i] = Slot_With_Symbol.slot_x0 + j;
            Slot_With_Symbol.Slot_Y[j + slot_width * i] = Slot_With_Symbol.slot_y0 + i;
        }
    }

    //Slot's Color
    Slot_With_Symbol.Slot_Elements_Color = new string[slot_square];
    for (int i = 0; i < Slot_With_Symbol.Slot_Elements_Color.Length; i++)
    {
        Slot_With_Symbol.Slot_Elements_Color[i] = "Cyan";
    }
    if (Slot_With_Symbol.slot_symbol != "⚡")
    {
        Slot_With_Symbol.Slot_Elements_Color[Slot_With_Symbol.Slot_Elements_Color.Length / 2 - 1] =
            "Magenta";
    }

    //Slot's Graphic Elements
    for (int i = 0; i < Slot_With_Symbol.Slot_Graphic_Elements.Length; i++)
    {
        if (
            i != Slot_With_Symbol.Slot_Graphic_Elements.Length / 2
            || Slot_With_Symbol.slot_symbol == "⚡"
        )
        {
            Slot_With_Symbol.Slot_Graphic_Elements[i] = " ";
        }
    }
    if (Slot_With_Symbol.slot_symbol == "⚡")
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < Wild_Symbol.Length; j++)
            {
                Slot_With_Symbol.Slot_Graphic_Elements[
                    j
                        + (Slot_With_Symbol.Slot_Graphic_Elements.Length / 2)
                        - (Wild_Symbol.Length / 2)
                        - slot_width
                        + i * slot_width
                ] = Wild_Symbol[j];
            }
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
    if (Slot_With_Symbol.slot_symbol != "⚡")
    {
        Slot_With_Symbol.Slot_Graphic_Elements[
            Slot_With_Symbol.Slot_Graphic_Elements.Length / 2 - 1
        ] = Slot_With_Symbol.slot_symbol;
    }
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

    //Slots Writing To Matrix
    for (int i = 0; i < Slot_With_Symbol.Slot_Graphic_Elements.Length; i++)
    {
        Matrix[
            matrix_width * (Slot_With_Symbol.Slot_Y[i] + all_slots_y)
                + Slot_With_Symbol.Slot_X[i]
                + all_slots_x
        ] = Slot_With_Symbol.Slot_Graphic_Elements[i];
    }

    //Slots' Color Writing To Matrix
    for (int i = 0; i < Slot_With_Symbol.Slot_Elements_Color.Length; i++)
    {
        int color_x =
            i - (int)(i / slot_width) * slot_width + Slot_With_Symbol.slot_x0 + all_slots_x;
        int color_y = (int)(i / slot_width) + Slot_With_Symbol.slot_y0 + all_slots_y;
        Matrix_Color[matrix_width * color_y + color_x] = Slot_With_Symbol.Slot_Elements_Color[i];
    }

    return Slot_With_Symbol;
}
Frame_Characteristics Frame_Graphics(Frame_Characteristics Frame_With_Value)
{
    Frame_With_Value.In_Frame_Text = new char[Frame_With_Value.frame_width - 2];

    int frame_square = Frame_With_Value.frame_width * Frame_With_Value.frame_hight;
    Frame_With_Value.Frame_Graphic_Elements = new string[frame_square];
    for (int i = 0; i < Frame_With_Value.Frame_Graphic_Elements.Length; i++)
    {
        Frame_With_Value.Frame_Graphic_Elements[i] = " ";
    }
    Frame_With_Value.Frame_Graphic_Elements[0] = "╔";
    Frame_With_Value.Frame_Graphic_Elements[
        Frame_With_Value.Frame_Graphic_Elements.Length / Frame_With_Value.frame_hight - 1
    ] = "╗";
    Frame_With_Value.Frame_Graphic_Elements[
        Frame_With_Value.Frame_Graphic_Elements.Length - Frame_With_Value.frame_width
    ] = "╚";
    Frame_With_Value.Frame_Graphic_Elements[Frame_With_Value.Frame_Graphic_Elements.Length - 1] =
        "╝";
    for (int i = 1; i < Frame_With_Value.frame_width - 1; i++)
    {
        Frame_With_Value.Frame_Graphic_Elements[i] = "═";
    }
    for (
        int i = Frame_With_Value.Frame_Graphic_Elements.Length - Frame_With_Value.frame_width + 1;
        i < Frame_With_Value.Frame_Graphic_Elements.Length - 1;
        i++
    )
    {
        Frame_With_Value.Frame_Graphic_Elements[i] = "═";
    }
    for (
        int i = Frame_With_Value.frame_width;
        i < Frame_With_Value.Frame_Graphic_Elements.Length - Frame_With_Value.frame_width;

    )
    {
        Frame_With_Value.Frame_Graphic_Elements[i] = "║";
        i = i + Frame_With_Value.frame_width;
    }
    for (
        int i = Frame_With_Value.frame_width * 2 - 1;
        i < Frame_With_Value.Frame_Graphic_Elements.Length - Frame_With_Value.frame_width;

    )
    {
        Frame_With_Value.Frame_Graphic_Elements[i] = "║";
        i = i + Frame_With_Value.frame_width;
    }

    for (int i = 0; i < Frame_With_Value.Frame_Graphic_Elements.Length; i++)
    {
        int x =
            i
            - (int)(i / Frame_With_Value.frame_width) * Frame_With_Value.frame_width
            + Frame_With_Value.frame_x0;
        int y = (int)(i / Frame_With_Value.frame_width) + Frame_With_Value.frame_y0;
        if (Frame_With_Value.Frame_Graphic_Elements[i] != " ")
        {
            Matrix[matrix_width * y + x] = Graphic_Elements_Addition(
                (Matrix[matrix_width * y + x]),
                (Frame_With_Value.Frame_Graphic_Elements[i])
            );
        }
    }
    return Frame_With_Value;
}
string Graphic_Elements_Addition(string input_1, string input_2)
{
    //0b(right)(up)(left)(down)
    //0b0000
    //GE_To_BN => Graphic Element To Binary Number
    Dictionary<string, int> GE_To_BN =
        new()
        {
            { "╚", 0b1100 },
            { "╝", 0b0110 },
            { "╗", 0b0011 },
            { "╔", 0b1001 },
            { "╩", 0b1110 },
            { "╦", 0b1011 },
            { "╠", 0b1101 },
            { "╣", 0b0111 },
            { "╬", 0b1111 },
            { "═", 0b1010 },
            { "║", 0b0101 }
        };
    Dictionary<int, string> BN_To_GE = GE_To_BN.ToDictionary(i => i.Value, i => i.Key);
    string Addition(string existing_symbol, string additional_symbol)
    {
        if (GE_To_BN.ContainsKey(existing_symbol) && GE_To_BN.ContainsKey(additional_symbol))
        {
            int binary_resoult = GE_To_BN[existing_symbol] | GE_To_BN[additional_symbol];
            return BN_To_GE[binary_resoult];
        }
        else
        {
            return additional_symbol;
        }
    }
    return Convert.ToString(Addition(input_1, input_2));
}
void Background_Layer_1()
{
    for (int i = 0; i < matrix_square; i++)
    {
        Matrix_Color[i] = "Magenta";
    }
    for (int i = 3 * matrix_width; i < 20 * matrix_width; i++)
    {
        Matrix[i] = "│";
    }
}

void All_Frames()
{
    var Frame_1 = new Frame_Characteristics
    {
        frame_x0 = 0,
        frame_y0 = 2,
        frame_width = 58,
        frame_hight = 19,
    };
    Frame_1 = Frame_Graphics(Frame_1);

    var Frame_2 = new Frame_Characteristics
    {
        frame_x0 = 34,
        frame_y0 = 0,
        frame_width = 24,
        frame_hight = 3,
    };
    Frame_2 = Frame_Graphics(Frame_2);

    var Frame_3 = new Frame_Characteristics
    {
        frame_x0 = 34,
        frame_y0 = 20,
        frame_width = 24,
        frame_hight = 3,
    };
    Frame_3 = Frame_Graphics(Frame_3);

    var Frame_4 = new Frame_Characteristics
    {
        frame_x0 = 0,
        frame_y0 = 20,
        frame_width = 13,
        frame_hight = 3,
    };
    Frame_4 = Frame_Graphics(Frame_4);
}

void All_Slots()
{
    var Slot_1 = new Slot_Characteristics
    {
        slot_x0 = 0,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_1 = Slot_Graphics(Slot_1);

    var Slot_2 = new Slot_Characteristics
    {
        slot_x0 = 11,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_2 = Slot_Graphics(Slot_2);

    var Slot_3 = new Slot_Characteristics
    {
        slot_x0 = 22,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_3 = Slot_Graphics(Slot_3);

    var Slot_4 = new Slot_Characteristics
    {
        slot_x0 = 33,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_4 = Slot_Graphics(Slot_4);

    var Slot_5 = new Slot_Characteristics
    {
        slot_x0 = 44,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_5 = Slot_Graphics(Slot_5);

    var Slot_6 = new Slot_Characteristics
    {
        slot_x0 = 0,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_6 = Slot_Graphics(Slot_6);

    var Slot_7 = new Slot_Characteristics
    {
        slot_x0 = 11,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_7 = Slot_Graphics(Slot_7);

    var Slot_8 = new Slot_Characteristics
    {
        slot_x0 = 22,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_8 = Slot_Graphics(Slot_8);

    var Slot_9 = new Slot_Characteristics
    {
        slot_x0 = 33,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_9 = Slot_Graphics(Slot_9);

    var Slot_10 = new Slot_Characteristics
    {
        slot_x0 = 44,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_10 = Slot_Graphics(Slot_10);

    var Slot_11 = new Slot_Characteristics
    {
        slot_x0 = 0,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_11 = Slot_Graphics(Slot_11);

    var Slot_12 = new Slot_Characteristics
    {
        slot_x0 = 11,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_12 = Slot_Graphics(Slot_12);

    var Slot_13 = new Slot_Characteristics
    {
        slot_x0 = 22,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_13 = Slot_Graphics(Slot_13);

    var Slot_14 = new Slot_Characteristics
    {
        slot_x0 = 33,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_14 = Slot_Graphics(Slot_14);

    var Slot_15 = new Slot_Characteristics
    {
        slot_x0 = 44,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Symbols[rand.Next(0, Symbols.Length)]
    };
    Slot_15 = Slot_Graphics(Slot_15);
}
Background_Layer_1();
All_Frames();
All_Slots();

void Output()
{
    int i = 0;
    for (int j = 0; j < matrix_hight; j++)
    {
        for (int k = 0; k < matrix_width; k++)
        {
            if (Matrix_Color[i] == "Cyan")
                Console.ForegroundColor = ConsoleColor.Cyan;
            if (Matrix_Color[i] == "Magenta")
                Console.ForegroundColor = ConsoleColor.Magenta;
            if (Matrix_Color[i] == "DarkMagenta")
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (Matrix_Color[i] == "White")
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Matrix[i]);
            i++;
        }
        Console.WriteLine();
    }
}
Output();

Console.WriteLine("𝓑𝓔𝓣");
Console.WriteLine("𝓦𝓘𝓝");
Console.WriteLine("𝓑𝓐𝓛𝓐𝓝𝓒𝓔");
Console.WriteLine("𝓒𝓞𝓝𝓢𝓞𝓛𝓔.𝓒𝓐𝓢𝓘𝓝𝓞");

struct Slot_Characteristics
{
    public int slot_x0;
    public int slot_y0;
    public int slot_scale;
    public string slot_symbol;
    public string[] Slot_Graphic_Elements;
    public int[] Slot_X;
    public int[] Slot_Y;
    public string[] Slot_Elements_Color;
}

struct Frame_Characteristics
{
    public int frame_x0;
    public int frame_y0;
    public int frame_width;
    public int frame_hight;
    public string[] Frame_Graphic_Elements;
    public string[] Frame_Elements_Color;
    public char[] In_Frame_Text;
}
