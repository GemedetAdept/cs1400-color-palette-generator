// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek
//Complementary
//what aee the color harmoines?
public static class ColorHarmony
{

    public static void complemenatryMeaning()
    {
        Console.WriteLine("The color harmony Complmentary, is when pairs of colors are positioned on opposite ends of the color wheel (or color circle), and they can be either primary, secondary, or tertiary colors.");

    }

    public static void SplitComplementarymeaning()
    {
        Console.WriteLine("The color harmony Split Complemnatry is deifined as one key color and two colors adjacent to that key colors complement.");
    }

    public static void Triadicmeaning()
    {
        Console.WriteLine("The color harmony Triadic, is when color combinations consist of three colors evenly spaced on the color wheel.");
    }


    public static void Tetradicmeaning()
    {
        Console.WriteLine("The color harmony Tetradic is when four individual colors: a key color and three more colors, are all equidistant from the key color on the color wheel.");
    }


    public static void Squaremeaning()
    {
        Console.WriteLine("The Square color harmomny consist of four colors spaced evenly around the color wheel. To create a square color palette, pick the key color to start with. Then identify the other colors that are equidistant from that color. You’ll basically end up with two complementary pairs.");
    }

    public static void Monochromaticmeaning()
    {
        Console.WriteLine("The Monochromatic color harmony is defined as a single base hue and extend the color scheme by using different shades, tones, and tdoubles of that color family.");
    }


    public static void Analogousmeaning()
    {
        Console.WriteLine("The analogous color harmony is defined as three hues, all positioned next to each other on the color wheel. ");
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
            Menu(localColorInput);

    }

    public static void Colorharmonypick()
    {
        Console.WriteLine("Would you like to know about the differnt color harmonies? y or n.");
        string? response = Console.ReadLine();
        if (response == "y")
            ColorHarmonyInfo();
        if (response == "n")
            Menu(localColorInput);


    }


    public static double[] Complementary((double, double, double) userColorInput)
    {

        // Hue
        double inputHue = userColorInput.Item1;
        double complement = inputHue + 180;
        if (complement > 360) complement = complement - 360;

        Console.WriteLine($" Here is your complemtary harmony: {inputHue}, {complement}");
        Console.ReadKey();
        double[] complements = new double[]{inputHue, complement};
        return complements;
    }


    public static double[] SplitComplementary((double, double, double) userColorInput)
    {
        // Hue
        double inputHue = userColorInput.Item1;
        double splitcomplement = inputHue + 180;
        double splitcomplement2 = splitcomplement / 2;
        if (splitcomplement > 360) splitcomplement = splitcomplement - 360;
        if (splitcomplement2 > 360) splitcomplement2 = splitcomplement2 - 360;
        Console.WriteLine($"Here is your splitcomplemntary color harmony: {inputHue}, {splitcomplement}, {splitcomplement2}");
        Console.ReadKey();
        double[] complemantriesSplit = new double[]{inputHue, splitcomplement, splitcomplement2};
        return complemantriesSplit;
    }



    public static double[] Triadic((double, double, double) userColorInput)
    {
        // Hue
        double inputHue = userColorInput.Item1;
        double triadic = inputHue + 180;
        double Triadic2 = triadic + 180;
        if (triadic > 360) triadic = triadic - 360;
        if (Triadic2 > 360) Triadic2 = Triadic2 - 360;
        Console.WriteLine($"Here is your triadic color harmony:{inputHue}, {triadic}, {Triadic2}");
        Console.ReadKey();
        double[] complemantriesTriadic = new double[]{inputHue, triadic, Triadic2};
        return complemantriesTriadic;
    }

    public static double[] Tetradic((double, double, double) userColorInput)
    {
        // Hue
        double inputHue = userColorInput.Item1;
        double tetradic = inputHue + 180;
        double tetradic1 = tetradic + 180;
        if (tetradic > 360) tetradic = tetradic - 360;
        Console.WriteLine($"Here is your tetradic color harmony:{inputHue},{tetradic},{tetradic1} ");
        Console.ReadKey();
        double[] complemantriesTetradic = new double[]{inputHue, tetradic, tetradic1};
        return complemantriesTetradic;
    }

    public static double[] Square((double, double, double) userColorInput)
    {

        // Hue
        double inputHue = userColorInput.Item1;
        double square = inputHue + 90;
        double square1 = square + 90;
        double square2 = square1 + 90;
        if (square > 360) square = square - 360;
        if (square2 > 360) square2 = square2 - 360;
        Console.WriteLine($"Here is your square color harmony:{inputHue},{square}, {square1}, {square2}.");
        Console.ReadKey();
        double[] complemantriesSquare = new double[]{inputHue, square, square1, square2};
        return complemantriesSquare;

    }
    public static double[] Monochromatic((double, double, double) userColorInput)
    {
        // Hue
        double inputHue = userColorInput.Item1;
        double monochromatic = inputHue + 30;
        double monochromatic1 = monochromatic + 15;
        double monochromatic2 = monochromatic1 + 15;
        if (monochromatic > 360) monochromatic = monochromatic - 360;
        if (monochromatic1 > 360) monochromatic1 = monochromatic1 - 360;
        if (monochromatic2 > 360) monochromatic2 = monochromatic2 - 360;
        Console.WriteLine($" Here is your monochromatic color harmony:{inputHue}, {monochromatic}, {monochromatic1}, {monochromatic2}. ");
        Console.ReadKey();
        double[] complemantriesMonochromatic = new double[]{inputHue, monochromatic, monochromatic1, monochromatic2};
        return complemantriesMonochromatic;
    }



    public static double[] Analogus((double, double, double) userColorInput)
    {
        // Hue
        double inputHue = userColorInput.Item1;
        double analogous = inputHue + 15;
        double analogous1 = analogous + 15;
        double analogous2 = analogous1 + 15;
        if (analogous > 360) analogous = analogous - 360;
        if (analogous1 > 360) analogous1 = analogous1 - 360;
        if (analogous2 > 360) analogous2 = analogous2 - 360;
        Console.WriteLine($"Here is your analogous color harmony: {inputHue}, {analogous}, {analogous1} ,{analogous2}.");
        Console.ReadKey();
        double[] complemantriesAnalgous = new double[]{inputHue, analogous, analogous1, analogous2};
        return complemantriesAnalgous;
    }

    static (double, double, double) localColorInput;
    public static List<double> Menu((double, double, double) userColorInput)
    {
        localColorInput = userColorInput;
        List<double> harmonyOutput = new List<double>();
        Console.WriteLine("What color Harmony would you like to use? 1. Complementary 2. Split Complemtary 3. Triadic 4. Tetradic 5. Square 6. Monochromatic , 7. Analogous , 8. exit. Please enter a valid inputHue");
        string? UserInput = Console.ReadLine();

        if (UserInput == "1") {
            harmonyOutput = Complementary(userColorInput).ToList();
            return harmonyOutput;
        }

        if (UserInput == "2") {
            harmonyOutput = SplitComplementary(userColorInput).ToList();
            return harmonyOutput;
        }

        if (UserInput == "3") {
            harmonyOutput = Triadic(userColorInput).ToList();
            return harmonyOutput;
        }

        if (UserInput == "4") {
            harmonyOutput = Tetradic(userColorInput).ToList();
            return harmonyOutput;
        }

        if (UserInput == "5") {
            harmonyOutput = Square(userColorInput).ToList();
            return harmonyOutput;
        }

        if (UserInput == "6") {
            harmonyOutput = Monochromatic(userColorInput).ToList();
            return harmonyOutput;
        }

        if (UserInput == "7") {
            harmonyOutput = Analogus(userColorInput).ToList();
            return harmonyOutput;
        }

        if (UserInput == "8") {

            Console.WriteLine("Thank you, for using the color palette generator,goodybye!");
            return harmonyOutput;
            System.Environment.Exit(0);
        }
        else
        {
            Menu(localColorInput);
        }
        return harmonyOutput;
    }



}