// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek
using UserInput;

// UserInput.UserInput.Input();



//Complementary

// void Complementary()
// {
//     Console.WriteLine("Enter the value of your number to get a complemntary harmony.");
//     int number = int.Parse(Console.ReadLine());
//     int complement = number + 180;
//     Console.WriteLine(complement);
//      Console.ReadKey();
//     ColorHarmonyMenu();
// }
// void SplitComplementary()
// {
//     Console.WriteLine("Enter the value of your number to get a  slplit complemntary harmony.");
//     int number = int.Parse(Console.ReadLine());
//     int splitcomplement = number *180/2;
//     Console.WriteLine(splitcomplement);
//      Console.ReadKey();
//     ColorHarmonyMenu();
// }



// void Triadic()
// {
//     Console.WriteLine("Enter the value of your number to get a  triadic harmony.");
//     int number =int.Parse(Console.ReadLine());
//     int triadic = number *120;
//     Console.WriteLine(triadic);
//      Console.ReadKey();
//     ColorHarmonyMenu();
// }
// void Tetradic()
// {
//     Console.WriteLine("Enter the value of your number to get a  tetradic harmony.");
//     int number = int.Parse(Console.ReadLine());
//     int tetradic = number + 180/3;
//     Console.WriteLine(tetradic);
//      Console.ReadKey();
//     ColorHarmonyMenu();
// }

// void Square()
// {

//     Console.WriteLine("Enter the value of your number to get a square harmony.");
//     int number = int.Parse(Console.ReadLine());
//     int square = number *180/4;
//     Console.WriteLine(square);
//      Console.ReadKey();
//     ColorHarmonyMenu();
// }
// void Monochromatic()
// {
//     Console.WriteLine("Enter the value of your number to get a monochromatic harmony.");
//     int number = int.Parse(Console.ReadLine());
//     int monochromatic = number *180/1;
//     Console.WriteLine(monochromatic);
//      Console.ReadKey();
//     ColorHarmonyMenu();
// }



// void Analogpus()
// {
//     Console.WriteLine("Enter the value of your number to get a analogous color harmony.");
//     int number = int.Parse(Console.ReadLine());
//     int analogous = number *180/1;
//     Console.WriteLine(analogous);
//      Console.ReadKey();
//     ColorHarmonyMenu();
// }


// void ColorHarmonyMenu()
// { 
//     Console.WriteLine("What color Harmony would you like to use? 1. Complementary 2. Split Complemtary 3. Triadic 4. Tetradic 5. Square 6. Monochromatic , 7. Analogous , 8. exit Please enter a valid number");
//    string UserInput = Console.ReadLine();
   
  

//     if (UserInput == "1")
//         Complementary();

//     if (UserInput == "2")
//         SplitComplementary();

//     if (UserInput == "3")
//         Triadic();

//     if (UserInput == "4")
//         Tetradic();

//     if (UserInput == "5")
//         Square();

//     if (UserInput == "6")
//         Monochromatic();

//         if(UserInput == "7")
//         Analogpus();

//     if (UserInput == "8")
    
//     { Console.WriteLine("Goodbye!");
//     System.Environment.Exit(0);
//        }
//     else
//     {
//         ColorHarmonyMenu();
//     }

// }

// ColorHarmonyMenu();

Console.Clear();
var inputHSL = (195, 77, 99);
// ConvertMode.HSLtoRGB(inputHSL);
Console.WriteLine(ConvertMode.HSLtoRGB(inputHSL));