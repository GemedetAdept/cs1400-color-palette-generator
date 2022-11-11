// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek

string userInput = GetUserInput("Do you want to input color for Hexadecimal, RGB, HSL, or HSV? ");


if (string.Equals(userInput, "Hexadecimal", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Enter a valid Hexadecimal value eg(#806FD9)");
    string? hexadecimal = Console.ReadLine();
    Console.WriteLine(hexadecimal);
}
else if (string.Equals(userInput, "RGB", StringComparison.OrdinalIgnoreCase))
{

    int Red = GetRGB("Enter a Red value between 0 and 255");
    int Green = GetRGB("Enter a Green value between 0 and 255");
    int Blue = GetRGB("Enter a Blue value between 0 and 255");
    (int Red, int Green, int Blue) RGB = (Red, Green, Blue);
    Console.WriteLine(RGB);


}
else if (string.Equals(userInput, "HSL", StringComparison.OrdinalIgnoreCase))
{

    int Hue = GetHSL("Enter a Hue between 0 and 360");
    int Saturation = GetHSL("Enter a Saturation between 0 and 100");
    int Lightness = GetHSL("Enter a Lightness between 0 and 100");
    (int Hue, int Saturation, int Lightness) HSL = (Hue, Saturation, Lightness);
    Console.WriteLine(HSL);

}
else if (string.Equals(userInput, "HSV", StringComparison.OrdinalIgnoreCase))
{

    int Hue = GetHSV("Enter a Hue between 0 and 255");
    int Saturation = GetHSV("Enter a Saturation between 0 and 255");
    int Value = GetHSV("Enter a Value between 0 and 255");
    (int Hue, int Saturation, int Value) HSV = (Hue, Saturation, Value);
    Console.WriteLine(HSV);

}

int GetHSV(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        try
        {
            int userInput = int.Parse(Console.ReadLine());
            if (userInput >= 0 && userInput <= 255)
            {
                return userInput;
            }
        }
        catch
        {
        }
        Console.WriteLine("Not a valid input. Try again.");
    }
}

int GetHSL(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        try
        {
            int userInput = int.Parse(Console.ReadLine());
            if (userInput >= 0 && userInput <= 360)
            {
                return userInput;
            }
        }
        catch
        {
        }
        Console.WriteLine("Not a valid input. Try again.");
    }
}

int GetRGB(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        try
        {
            int userInput = int.Parse(Console.ReadLine());
            if (userInput >= 0 && userInput <= 255)
            {
                return userInput;
            }
        }
        catch
        {
        }
        Console.WriteLine("Not a valid input. Try again.");
    }
}

string GetUserInput(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        try
        {
            string? userInput = Console.ReadLine();

            if (string.Equals(userInput, "HSL", StringComparison.OrdinalIgnoreCase) || string.Equals(userInput, "HSV", StringComparison.OrdinalIgnoreCase) || string.Equals(userInput, "Hexadecimal", StringComparison.OrdinalIgnoreCase) || string.Equals(userInput, "RGB", StringComparison.OrdinalIgnoreCase))
            {
                return userInput;
            }
        }
        catch
        {
        }
        Console.WriteLine("Not a valid input. Try again.");
    }
}
