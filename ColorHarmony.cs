// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek
//Complementary
//what aee the color harmoines?
public static class ColorHarmony
{

    public static void complemenatryMeaning()
    {
        Console.WriteLine("The color harmony Complmentary, is when pairs of colors are  positioned on opposite ends of the color wheel (or color circle), and they can be either primary, secondary, or tertiary colors.");

    }

    public static void SplitComplementarymeaning()
    {
        Console.WriteLine(" The color harmony Split Complemnatry is deifined as one key color and two colors adjacent to that key colors complement. ");
    }

    public static void Triadicmeaning()
    {
        Console.WriteLine("The color harmony Triadic, is when color combinations consist of three colors evenly spaced on the color wheel.");
    }


    public static void Tetradicmeaning()
    {
        Console.WriteLine(" The color harmony Tetradic is when four individual colors: a key color and three more colors, are all equidistant from the key color on the color wheel.");
    }


    public static void Squaremeaning()
    {
        Console.WriteLine(" The Square color harmomny consist of four colors spaced evenly around the color wheel. To create a square color palette, pick the key color to start with. Then identify the other colors that are equidistant from that color. You’ll basically end up with two complementary pairs.");
    }

    public static void Monochromaticmeaning()
    {
        Console.WriteLine(" The Monochromatic color harmony is defined as a single base hue and extend the color scheme by using different shades, tones, and tints of that color family.");
    }


    public static void Analogousmeaning()
    {
        Console.WriteLine(" The analogous color harmony is defined as three hues, all positioned next to each other on the color wheel. ");
    }

    public static void ColorHarmonyInfo()
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
            Menu();

    }

    public static void Colorharmonypick()
    {
        Console.WriteLine("Would you like to know about the differnt color harmonies? y or n.");
        string? response = Console.ReadLine();
        if (response == "y")
            ColorHarmonyInfo();
        if (response == "n")
            Menu();


    }




    public static void Complementary()
    {
        Console.WriteLine("Enter the value of your number to get a complemntary harmony.");
        int number = int.Parse(Console.ReadLine());
        int complement = number + 180;
        if (complement > 360) complement = complement - 360;

        Console.WriteLine($" Here is your complemtary harmony: {number}, {complement}");
        Console.ReadKey();
        Menu();
    }
    public static void SplitComplementary()
    {
        Console.WriteLine("Enter the value of your number to get a  slplit complemntary harmony.");
        int number = int.Parse(Console.ReadLine());
        int splitcomplement = number + 180;
        int splitcomplement2 = splitcomplement / 2;
        if (splitcomplement > 360) splitcomplement = splitcomplement - 360;
        if (splitcomplement2 > 360) splitcomplement2 = splitcomplement2 - 360;
        Console.WriteLine($"Here is your splitcomplemntary color harmony: {number}, {splitcomplement}, {splitcomplement2}");
        Console.ReadKey();
        Menu();
    }



    public static void Triadic()
    {
        Console.WriteLine("Enter the value of your number to get a  triadic harmony.");
        int number = int.Parse(Console.ReadLine());
        int triadic = number + 180;
        int Triadic2 = triadic + 180;
        if (triadic > 360) triadic = triadic - 360;
        if (Triadic2 > 360) Triadic2 = Triadic2 - 360;
        Console.WriteLine($"Here is your triadic color harmony:{number}, {triadic}, {Triadic2}");
        Console.ReadKey();
        Menu();
    }
    public static void Tetradic()
    {
        Console.WriteLine("Enter the value of your number to get a  tetradic harmony.");
        int number = int.Parse(Console.ReadLine());
        int tetradic = number + 180;
         int tetradic1 = tetradic + 180;
        if (tetradic > 360) tetradic = tetradic - 360;
        Console.WriteLine($"Here is your tetradic color harmony:{number},{tetradic},{tetradic1} ");
        Console.ReadKey();
        Menu();
    }

    public static void Square()
    {

        Console.WriteLine("Enter the value of your number to get a square harmony.");
        int number = int.Parse(Console.ReadLine());
        int square = number + 90;
        int square1 = square + 90;
        int square2 = square1 + 90;
        if (square > 360) square = square - 360;
        if (square2 > 360) square2 = square2 - 360;
        Console.WriteLine($"Here is your square color harmony:{number},{square}, {square1}, {square2}.");
        Console.ReadKey();
        Menu();
    }
    public static void Monochromatic()
    {
        Console.WriteLine("Enter the value of your number to get a monochromatic harmony.");
        int number = int.Parse(Console.ReadLine());
        int monochromatic = number + 30;
        int monochromatic1 = monochromatic + 15;
        int monochromatic2 = monochromatic1 + 15;
        if (monochromatic > 360) monochromatic = monochromatic - 360;
        if (monochromatic1 > 360) monochromatic1 = monochromatic1 - 360;
        if (monochromatic2 > 360) monochromatic2 = monochromatic2 - 360;
        Console.WriteLine($" Here is your monochromatic color harmony:{number}, {monochromatic}, {monochromatic1}, {monochromatic2}. ");
        Console.ReadKey();
        Menu();
    }



    public static void Analogus()
    {
        Console.WriteLine("Enter the value of your number to get a analogous color harmony.");
        int number = int.Parse(Console.ReadLine());
        int analogous = number + 15;
        int analogous1 = analogous + 15;
        int analogous2 = analogous1 + 15;
        if (analogous > 360) analogous = analogous - 360;
        if (analogous1 > 360) analogous1 = analogous1 - 360;
        if (analogous2 > 360) analogous2 = analogous2 - 360;
        Console.WriteLine($"Here is your analogous color harmony: {number}, {analogous}, {analogous1} ,{analogous2}.");
        Console.ReadKey();
        Menu();
    }


    public static void Menu()
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
            Menu();
        }

    }





}