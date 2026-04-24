using System.Globalization;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

Console.OutputEncoding = System.Text.Encoding.UTF8;

double balance = 0;
long bet = 100;
long win = 10000;
Random rand = new Random();

//string cd_gold_disk = "📀";
int matrix_width = 58;
int matrix_hight = 23;
int matrix_square = matrix_width * matrix_hight;
string[] Matrix = new string[matrix_square];
Array.Fill(Matrix, " ");
string[] Matrix_Foreground_Color = new string[matrix_square];
Array.Fill(Matrix_Foreground_Color, "Magenta");
string[] Matrix_Background_Color = new string[matrix_square];
Array.Fill(Matrix_Background_Color, "Black");

string[] Symbols = { "🇯", "🇶", "🇰", "🇹", "🥝", "🍋", "🍒", "💎", "🔔", "⚡" };
string[] Wild_Symbol = { "", "⚡", "W", "I", "L", "D", "⚡", "" };

string[] Generated_Symbols = new string[15];
for (int i = 0; i < Generated_Symbols.Length; i++)
{
    Generated_Symbols[i] = Symbols[rand.Next(0, Symbols.Length)];
}

string slot_1_symbol = Generated_Symbols[0];
string slot_2_symbol = Generated_Symbols[1];
string slot_3_symbol = Generated_Symbols[2];
int[] Matches_Count(string slot_i_symbol)
{
    int[] Slot_i_Match = new int[15];
    Array.Fill(Slot_i_Match, 0);
    if (slot_i_symbol != "⚡")
    {
        for (int i = 3; i < Generated_Symbols.Length; i++)
        {
            if (Generated_Symbols[i] == slot_i_symbol || Generated_Symbols[i] == "⚡")
            {
                Slot_i_Match[i] = 1;
            }
        }
    }
    return Slot_i_Match;
}
int[] Slot_1_Match = Matches_Count(slot_1_symbol);
int[] Slot_2_Match = Matches_Count(slot_2_symbol);
int[] Slot_3_Match = Matches_Count(slot_3_symbol);
void Comb_Count_And_Length(int[] Slot_i_Match)
{
    for (int i = 0; i < Slot_i_Match.Length; i++)
    {
        Console.Write(Slot_i_Match[i]);
    }
    Console.WriteLine();
    int[] Comb_Count_And_Length = new int[2];
    int comb_count = 1;
    int comb_length = 0;
    int[] Reel_Match = new int[5];
    for (int i = 3; i < Slot_i_Match.Length; i++)
    {
        int reel_match_count = 0;
        for (int j = 0; j < 3; j++)
        {
            reel_match_count = +Slot_i_Match[i];
            i++;
        }
        Reel_Match[i / 3] = reel_match_count;
    }
    for (int i = 1; i < Reel_Match.Length - 1; i++)
    {
        if (Reel_Match[i] == 0)
        {
            break;
        }
        comb_count = comb_count * Reel_Match[i];
        comb_length++;
    }
    if (comb_count < 3)
    {
        comb_count = 0;
        comb_length = 0;
    }
    Console.WriteLine(comb_count);
    Console.WriteLine(comb_length);
}
Comb_Count_And_Length(Slot_1_Match);
Comb_Count_And_Length(Slot_2_Match);
Comb_Count_And_Length(Slot_3_Match);
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
    Array.Fill(Slot_With_Symbol.Slot_Elements_Color, "Cyan");
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
        Matrix_Foreground_Color[matrix_width * color_y + color_x] =
            Slot_With_Symbol.Slot_Elements_Color[i];
    }

    return Slot_With_Symbol;
}

Frame_Characteristics Frame_Graphics(Frame_Characteristics Frame)
{
    int frame_square = Frame.frame_width * Frame.frame_hight;
    Frame.Frame_Graphic_Elements = new string[frame_square];
    Array.Fill(Frame.Frame_Graphic_Elements, " ");
    Frame.Frame_Elements_Color = new string[frame_square];
    Array.Fill(Frame.Frame_Elements_Color, "Magenta");

    //In-frame line
    if (Frame.frame_value_name != null)
    {
        char[] Frame_Line = new char[Frame.frame_width - 2];
        Array.Fill(Frame_Line, ' ');

        for (int i = 0; i < Frame.frame_value_name.Length; i++)
        {
            Frame_Line[i] = Frame.frame_value_name[i];
        }

        Frame_Line[Frame_Line.Length - 1] = '$';

        char[] frame_value_space = new char[Frame_Line.Length - Frame.frame_value_name.Length - 1];

        Array.Fill(frame_value_space, '_');

        string value_to_string = Convert.ToString(Frame.value);
        if (frame_value_space.Length >= value_to_string.Length)
        {
            for (
                int i = frame_value_space.Length - value_to_string.Length;
                i < frame_value_space.Length;
                i++
            )
            {
                frame_value_space[i] = value_to_string[
                    i - (frame_value_space.Length - value_to_string.Length)
                ];
            }
        }
        else if (frame_value_space.Length < value_to_string.Length)
        {
            int i = 0;
            for (; i < frame_value_space.Length; i++)
            {
                frame_value_space[i] = value_to_string[i];
            }
            frame_value_space[i - 1] = '…';
        }

        for (int i = Frame.frame_value_name.Length; i < Frame_Line.Length - 1; i++)
        {
            Frame_Line[i] = frame_value_space[i - Frame.frame_value_name.Length];
        }

        for (int i = 0; i < Frame_Line.Length; i++)
        {
            Frame.Frame_Graphic_Elements[i + 1 + Frame.frame_width] = Convert.ToString(
                Frame_Line[i]
            );
            Frame.Frame_Elements_Color[i + 1 + Frame.frame_width] = "Magenta";
        }
    }

    //Graphic elements
    Frame.Frame_Graphic_Elements[0] = "╔";
    Frame.Frame_Graphic_Elements[Frame.Frame_Graphic_Elements.Length / Frame.frame_hight - 1] = "╗";
    Frame.Frame_Graphic_Elements[Frame.Frame_Graphic_Elements.Length - Frame.frame_width] = "╚";
    Frame.Frame_Graphic_Elements[Frame.Frame_Graphic_Elements.Length - 1] = "╝";

    for (int i = 1; i < Frame.frame_width - 1; i++)
    {
        Frame.Frame_Graphic_Elements[i] = "═";
    }

    for (
        int i = Frame.Frame_Graphic_Elements.Length - Frame.frame_width + 1;
        i < Frame.Frame_Graphic_Elements.Length - 1;
        i++
    )
    {
        Frame.Frame_Graphic_Elements[i] = "═";
    }

    for (int i = Frame.frame_width; i < Frame.Frame_Graphic_Elements.Length - Frame.frame_width; )
    {
        Frame.Frame_Graphic_Elements[i] = "║";
        i = i + Frame.frame_width;
    }

    for (
        int i = Frame.frame_width * 2 - 1;
        i < Frame.Frame_Graphic_Elements.Length - Frame.frame_width;

    )
    {
        Frame.Frame_Graphic_Elements[i] = "║";
        i = i + Frame.frame_width;
    }

    for (int i = 0; i < Frame.Frame_Graphic_Elements.Length; i++)
    {
        int x = i - (int)(i / Frame.frame_width) * Frame.frame_width + Frame.frame_x0;
        int y = (int)(i / Frame.frame_width) + Frame.frame_y0;
        if (Frame.Frame_Graphic_Elements[i] != " ")
        {
            Matrix[matrix_width * y + x] = Graphic_Elements_Addition(
                (Matrix[matrix_width * y + x]),
                (Frame.Frame_Graphic_Elements[i])
            );
            Matrix_Foreground_Color[matrix_width * y + x] = Frame.Frame_Elements_Color[i];
        }
    }

    return Frame;
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

    if (GE_To_BN.ContainsKey(input_1) && GE_To_BN.ContainsKey(input_2))
    {
        int binary_resoult = GE_To_BN[input_1] | GE_To_BN[input_2];
        return BN_To_GE[binary_resoult];
    }
    else
    {
        return input_2;
    }
}

void Background_Layer_1()
{
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
    Frame_Graphics(Frame_1);

    var Frame_2 = new Frame_Characteristics
    {
        frame_x0 = 34,
        frame_y0 = 0,
        frame_width = 24,
        frame_hight = 3,
        frame_value_name = "BALANCE:",
        value = balance,
    };
    Frame_Graphics(Frame_2);

    var Frame_3 = new Frame_Characteristics
    {
        frame_x0 = 34,
        frame_y0 = 20,
        frame_width = 24,
        frame_hight = 3,
        frame_value_name = "WIN:",
        value = win,
    };
    Frame_Graphics(Frame_3);

    var Frame_4 = new Frame_Characteristics
    {
        frame_x0 = 0,
        frame_y0 = 20,
        frame_width = 13,
        frame_hight = 3,
        frame_value_name = "BET:",
        value = bet,
    };
    Frame_Graphics(Frame_4);
}

void All_Slots()
{
    var Slot_1 = new Slot_Characteristics
    {
        slot_x0 = 0,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[0],
    };
    Slot_Graphics(Slot_1);

    var Slot_2 = new Slot_Characteristics
    {
        slot_x0 = 0,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[1],
    };
    Slot_Graphics(Slot_2);

    var Slot_3 = new Slot_Characteristics
    {
        slot_x0 = 0,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[2],
    };
    Slot_Graphics(Slot_3);

    var Slot_4 = new Slot_Characteristics
    {
        slot_x0 = 11,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[3],
    };
    Slot_Graphics(Slot_4);

    var Slot_5 = new Slot_Characteristics
    {
        slot_x0 = 11,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[4],
    };
    Slot_Graphics(Slot_5);

    var Slot_6 = new Slot_Characteristics
    {
        slot_x0 = 11,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[5],
    };
    Slot_Graphics(Slot_6);

    var Slot_7 = new Slot_Characteristics
    {
        slot_x0 = 22,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[6],
    };
    Slot_Graphics(Slot_7);

    var Slot_8 = new Slot_Characteristics
    {
        slot_x0 = 22,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[7],
    };
    Slot_Graphics(Slot_8);

    var Slot_9 = new Slot_Characteristics
    {
        slot_x0 = 22,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[8],
    };
    Slot_Graphics(Slot_9);

    var Slot_10 = new Slot_Characteristics
    {
        slot_x0 = 33,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[9],
    };
    Slot_Graphics(Slot_10);

    var Slot_11 = new Slot_Characteristics
    {
        slot_x0 = 33,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[10],
    };
    Slot_Graphics(Slot_11);

    var Slot_12 = new Slot_Characteristics
    {
        slot_x0 = 33,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[11],
    };
    Slot_Graphics(Slot_12);

    var Slot_13 = new Slot_Characteristics
    {
        slot_x0 = 44,
        slot_y0 = 0,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[12],
    };
    Slot_Graphics(Slot_13);

    var Slot_14 = new Slot_Characteristics
    {
        slot_x0 = 44,
        slot_y0 = 5,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[13],
    };
    Slot_Graphics(Slot_14);

    var Slot_15 = new Slot_Characteristics
    {
        slot_x0 = 44,
        slot_y0 = 10,
        slot_scale = 1,
        slot_symbol = Generated_Symbols[14],
    };
    Slot_Graphics(Slot_15);
}

void Output()
{
    int i = 0;
    for (int j = 0; j < matrix_hight; j++)
    {
        for (int k = 0; k < matrix_width; k++)
        {
            //Foreground
            if (Matrix_Foreground_Color[i] == "Cyan")
                Console.ForegroundColor = ConsoleColor.Cyan;
            if (Matrix_Foreground_Color[i] == "Magenta")
                Console.ForegroundColor = ConsoleColor.Magenta;
            if (Matrix_Foreground_Color[i] == "DarkMagenta")
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (Matrix_Foreground_Color[i] == "White")
                Console.ForegroundColor = ConsoleColor.White;
            if (Matrix_Foreground_Color[i] == "Black")
                Console.ForegroundColor = ConsoleColor.Black;

            //Background
            if (Matrix_Background_Color[i] == "Black")
                Console.BackgroundColor = ConsoleColor.Black;
            if (Matrix_Background_Color[i] == "Magenta")
                Console.BackgroundColor = ConsoleColor.Magenta;
            if (Matrix_Background_Color[i] == "Cyan")
                Console.BackgroundColor = ConsoleColor.Cyan;

            Console.Write(Matrix[i]);
            i++;
        }
        Console.WriteLine();
    }
}

void Title()
{
    string title = "/CONSOLE_CASINO.exe";
    for (int i = 0; i < title.Length; i++)
    {
        Matrix[i + matrix_width] = Convert.ToString(title[i]);
        Matrix_Foreground_Color[i + matrix_width] = "Black";
        Matrix_Background_Color[i + matrix_width] = "Cyan";
    }
}

Background_Layer_1();
Title();
All_Frames();
All_Slots();
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
    public double value;
    public string frame_value_name;
}
