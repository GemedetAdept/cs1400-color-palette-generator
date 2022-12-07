// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek
using userinput;

// UserInput.Input();

// // What are the color harmonies?
// ColorHarmony.Colorharmonypick();
// ColorHarmony.ColorHarmonyInfo();
// ColorHarmony.Menu();
var inputRGB = (167, 110, 220);
Console.WriteLine("RGB to HEX");
Console.WriteLine(ConvertMode.RGBtoHEX(inputRGB));
Console.WriteLine("");
var inputHSV = (271, 50.0, 86.3);
Console.WriteLine("HSV to HEX");
Console.WriteLine(ConvertMode.HSVtoHEX(inputHSV));
var inputHSL = (271, 61.1, 64.7);
Console.WriteLine("HSL to HEX");
Console.WriteLine(ConvertMode.HSLtoHEX(inputHSL));