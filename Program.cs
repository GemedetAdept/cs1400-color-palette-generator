// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek

string userInput = GetUserInput("Do you want to input color for Hexadecimal, RGB, HSL, or HSV? ");



if (string.Equals(userInput, "Hexadecimal", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Enter a valid Hexadecimal value eg(#806FD9)");
    string? hexadecimal = Console.ReadLine();
    if (IsHexadecimal(hexadecimal)) {
        Console.WriteLine(ConvertToInteger(hexadecimal));

     }
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

bool IsHexadecimal(string hexadecimal)
{
    char[] valid = new char[16] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
    foreach (char letter in hexadecimal)
    {
        if (hexadecimal.Length != 6)
        {
            return false;
        }
        if (!valid.Contains(letter))
        {
            return false;
        }


    }
    return true;
}

int ConvertToInteger(string hexadecimal)
{
    List<int> values = new List<int>();
    double value = 0;
    char [] nubmers = new char [10]{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

    
    foreach (char letter in hexadecimal)
    {
        if (nubmers.Contains(letter))
        {

            values.Add(Convert.ToInt32(letter)-48);
        }
        else if (letter == 'A')
        {
            values.Add(10);
        }
        else if (letter == 'B')
        {
            values.Add(11);
        }
        else if (letter == 'C')
        {
            values.Add(12);
        }
        else if (letter == 'D')
        {
            values.Add(13);
        }
        else if (letter == 'E')
        {
            values.Add(14);
        }
        else if (letter == 'F')
        {
            values.Add(15);
        }
    }
    int y = 0;
    for (double x = 5; x >= 0; x--)
    {
        
        value = value+values[y]*Math.Pow(16d, x);
        y++;
    }
    return Convert.ToInt32(value);
}


//Complementary

void Complementary()
{
    Console.WriteLine("Enter the value of your number to get a complemntary harmony.");
    int number = int.Parse(Console.ReadLine());
    int complement = number + 180;
    Console.WriteLine(complement);
     Console.ReadKey();
    ColorHarmonyMenu();
}
void SplitComplementary()
{
    Console.WriteLine("Enter the value of your number to get a  slplit complemntary harmony.");
    int number = int.Parse(Console.ReadLine());
    int splitcomplement = number *180/2;
    Console.WriteLine(splitcomplement);
     Console.ReadKey();
    ColorHarmonyMenu();
}



void Triadic()
{
    Console.WriteLine("Enter the value of your number to get a  triadic harmony.");
    int number =int.Parse(Console.ReadLine());
    int triadic = number *120;
    Console.WriteLine(triadic);
     Console.ReadKey();
    ColorHarmonyMenu();
}
void Tetradic()
{
    Console.WriteLine("Enter the value of your number to get a  tetradic harmony.");
    int number = int.Parse(Console.ReadLine());
    int tetradic = number + 180/3;
    Console.WriteLine(tetradic);
     Console.ReadKey();
    ColorHarmonyMenu();
}

void Square()
{

    Console.WriteLine("Enter the value of your number to get a square harmony.");
    int number = int.Parse(Console.ReadLine());
    int square = number *180/4;
    Console.WriteLine(square);
     Console.ReadKey();
    ColorHarmonyMenu();
}
void Monochromatic()
{
    Console.WriteLine("Enter the value of your number to get a monochromatic harmony.");
    int number = int.Parse(Console.ReadLine());
    int monochromatic = number *180/1;
    Console.WriteLine(monochromatic);
     Console.ReadKey();
    ColorHarmonyMenu();
}



void Analogpus()
{
    Console.WriteLine("Enter the value of your number to get a analogous color harmony.");
    int number = int.Parse(Console.ReadLine());
    int analogous = number *180/1;
    Console.WriteLine(analogous);
     Console.ReadKey();
    ColorHarmonyMenu();
}


void ColorHarmonyMenu()
{ 
    Console.WriteLine("What color Harmony would you like to use? 1. Complementary 2. Split Complemtary 3. Triadic 4. Tetradic 5. Square 6. Monochromatic , 7. Analogous , 8. exit Please enter a valid number");
   string UserInput = Console.ReadLine();
   
  

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

        if(UserInput == "7")
        Analogpus();

    if (UserInput == "8")
    
    { Console.WriteLine("Goodbye!");
    System.Environment.Exit(0);
       }
    else
    {
        ColorHarmonyMenu();
    }

}

ColorHarmonyMenu();
