// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek
using userinput;

var standardInput = UserInput.Input();
List<double> harmonyOutput = ColorHarmony.Menu(standardInput);

Console.WriteLine(standardInput);
foreach (double val in harmonyOutput) {Console.WriteLine(val);}

// // What are the color harmonies?
// ColorHarmony.Colorharmonypick();
// ColorHarmony.ColorHarmonyInfo();
// ColorHarmony.Menu(inputHue);