// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek
//Complementary
//what aee the color harmoines?

void complemenatryMeaning()
{
    Console.WriteLine("The color harmony Complmentary, is when pairs of colors are  positioned on opposite ends of the color wheel (or color circle), and they can be either primary, secondary, or tertiary colors.");

}

void SplitComplementarymeaning()
{
    Console.WriteLine(" The color harmony Split Complemnatry is deifined as one key color and two colors adjacent to that key colors complement. ");
}

void Triadicmeaning()
{
    Console.WriteLine("The color harmony Triadic, is when color combinations consist of three colors evenly spaced on the color wheel.");
}


void Tetradicmeaning()
{
    Console.WriteLine(" The color harmony Tetradic is when four individual colors: a key color and three more colors, are all equidistant from the key color on the color wheel.");
}


void Squaremeaning()
{
    Console.WriteLine(" The Square color harmomny consist of four colors spaced evenly around the color wheel. To create a square color palette, pick the key color to start with. Then identify the other colors that are equidistant from that color. You’ll basically end up with two complementary pairs.");
}

void Monochromaticmeaning()
{
    Console.WriteLine(" The Monochromatic color harmony is defined as a single base hue and extend the color scheme by using different shades, tones, and tints of that color family.");
}


void Analogousmeaning()
{
    Console.WriteLine(" The analogous color harmony is defined as three hues, all positioned next to each other on the color wheel. ");
}

void ColorHarmonyInfo()
{
    Console.WriteLine("What color harmony would you like to know about? Enter a letter a-h.  a. Complememtary b. SplitComplemenatry c. Triadic d. Tetradic e. Square f. Monochromatic g. Analogous h. Contiune");
    string? UserPick = Console.ReadLine();
    if (UserPick == "a")
    complemenatryMeaning();


    if (UserPick == "b")
    SplitComplementarymeaning();

    if (UserPick == "c")
    Triadicmeaning();

    if (UserPick == "d")
    Tetradicmeaning();

    if (UserPick == "e")
    Squaremeaning();

    if (UserPick == "f")
    Monochromaticmeaning();

    if (UserPick == "g")
    Analogousmeaning();

    if (UserPick == "h")
    ColorHarmonyMenu();

}

void Colorharmonypick()
{
    Console.WriteLine("Would you like to know about the differnt color harmonies? y or n.");
    string? response = Console.ReadLine();
    if (response == "y") 
    ColorHarmonyInfo();
    if (response == "n") 
    ColorHarmonyMenu();


}




void Complementary()
{
    Console.WriteLine("Enter the value of your number to get a complemntary harmony.");
    int number = int.Parse(Console.ReadLine());
    int complement = number + 180;
    Console.WriteLine($" {number} {complement}");
    Console.ReadKey();
    ColorHarmonyMenu();
}
void SplitComplementary()
{
    Console.WriteLine("Enter the value of your number to get a  slplit complemntary harmony.");
    int number = int.Parse(Console.ReadLine());
    int splitcomplement = number + 180 ;
    int splitcomplement2 = splitcomplement/2;
    Console.WriteLine($" {number} {splitcomplement} {splitcomplement2}");
    Console.ReadKey();
    ColorHarmonyMenu();
}



void Triadic()
{
    Console.WriteLine("Enter the value of your number to get a  triadic harmony.");
    int number = int.Parse(Console.ReadLine());
    int triadic = number + 180;
    int Triadic2 = triadic +180;
    Console.WriteLine($"{number} {triadic} {Triadic2}");
    Console.ReadKey();
    ColorHarmonyMenu();
}
void Tetradic()
{
    Console.WriteLine("Enter the value of your number to get a  tetradic harmony.");
    int number = int.Parse(Console.ReadLine());
    int tetradic = number + 180;
    Console.WriteLine(tetradic);
    Console.ReadKey();
    ColorHarmonyMenu();
}

void Square()
{

    Console.WriteLine("Enter the value of your number to get a square harmony.");
    int number = int.Parse(Console.ReadLine());
    int square = number + 90;
    int square1 = square + 90;
    int square2 = square1 + 90;
    int square3 = square2 + 90;
    Console.WriteLine($"{square} {square1} {square2} {square3}");
    Console.ReadKey();
    ColorHarmonyMenu();
}
void Monochromatic()
{
    Console.WriteLine("Enter the value of your number to get a monochromatic harmony.");
    int number = int.Parse(Console.ReadLine());
    int monochromatic = number + 30;
    int monochromatic1 = monochromatic +15;
    int monochromatic2 = monochromatic1 +15;
    Console.WriteLine($" {monochromatic} {monochromatic1} {monochromatic} " );
    Console.ReadKey();
    ColorHarmonyMenu();
}



void Analogus()
{
    Console.WriteLine("Enter the value of your number to get a analogous color harmony.");
    int number = int.Parse(Console.ReadLine());
    int analogous = number +15;
    int analogous1 = analogous +15;
    int analogous2 = analogous1 +15;
    Console.WriteLine($"{analogous}v{ analogous1}  {analogous1}" );
    Console.ReadKey();
    ColorHarmonyMenu();
}


void ColorHarmonyMenu()
{
    Console.WriteLine("What color Harmony would you like to use? 1. Complementary 2. Split Complemtary 3. Triadic 4. Tetradic 5. Square 6. Monochromatic , 7. Analogous , 8. exit Please enter a valid number");
    string? UserInput = Console.ReadLine();



    if (UserInput == "1")
        Complementary();

    if (UserInput == "2")
        SplitComplementary();

    if (UserInput == "3")
        Triadic();

    if (UserInput == "4")
        Tetradic();

    if (UserInput == "5")
        Square();

    if (UserInput == "6")
        Monochromatic();

    if (UserInput == "7")
        Analogus();

    if (UserInput == "8")

    {
        Console.WriteLine("goodybye.");
        System.Environment.Exit(0);
    }
    else
    {
        ColorHarmonyMenu();
    }

}
Colorharmonypick();
ColorHarmonyInfo();
ColorHarmonyMenu();


