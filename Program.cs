// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek
using userinput;

var colorPaletteOutput = new List<(double, double, double)>();
var standardInput = UserInput.Input();

List<double> harmonyOutput = ColorHarmony.Menu(standardInput);

foreach (double val in harmonyOutput) {
	colorPaletteOutput.Add((val, standardInput.Item2, standardInput.Item3));
}

foreach (var color in colorPaletteOutput) {Console.WriteLine(color);}


// // What are the color harmonies?
// ColorHarmony.Colorharmonypick();
// ColorHarmony.ColorHarmonyInfo();
// ColorHarmony.Menu(inputHue);