// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek
using userinput;
using menudriver;

var paletteHEX = new List<string>();
var paletteHSL = new List<(double, double, double)>();
var paletteHSV = new List<(double, double, double)>();
var paletteRGB = new List<(double, double, double)>();

MenuDriver selectionMenu = new MenuDriver();
string[] options = new string[] {

	"Generate New Color Palette",
	"Learn About Color Harmonies",
	"Quit Program",
};
selectionMenu.AddOptions(options);

void mainMenu() {
	while (selectionMenu.menuLoop){

		Console.Clear();
		selectionMenu.DisplayMenu();
		selectionMenu.SetMenuCursor();

		switch(selectionMenu.selectedItem) {

			case 0:
				generationDriver();
				break;
			case 1:
				ColorHarmony.Colorharmonypick();
				break;
			case 2: 
				Console.Clear();
				Environment.Exit(0);
				break;
			default:
				break;
		}
	}
}

mainMenu();

void generationDriver() {

	(double, double, double) baseHSV = UserInput.Input();
	List<double> harmonyOutput = ColorHarmony.Menu(baseHSV);

	foreach (double harmonyVal in harmonyOutput) {
		paletteHSV.Add((harmonyVal, baseHSV.Item2, baseHSV.Item3));
	}

	foreach (var harmonyVal in paletteHSV) {
		var colorHEX = ConvertMode.HSVtoHEX(harmonyVal);
		paletteHEX.Add(colorHEX);
	}

	foreach (var harmonyVal in paletteHSV) {
		var colorHSL = ConvertMode.HSVtoHSL(harmonyVal);
		paletteHSL.Add(colorHSL);
	}

	foreach (var harmonyVal in paletteHSV) {
		var colorRGB = ConvertMode.HSVtoRGB(harmonyVal);
		paletteRGB.Add(colorRGB);
	} 

	displayPalette();
}

string alignItem((double, double, double) columnItem, int maxLength) {

	string inputItem = columnItem.ToString();
	int inputItemLength = inputItem.Length;
	string alignedItem = inputItem;

	if (inputItemLength < maxLength) {

		int padding = maxLength - inputItemLength;
		alignedItem += new string(' ', padding);
	}

	return alignedItem;
}

string centerHeader(string tableHeader, int maxWidth) {

	int headerLength = tableHeader.Length;
	string centeredHeader = tableHeader;

	int paddingLeft = -4;
	int paddingRight = -4;
	int widthRemainder = maxWidth - headerLength;

	if (widthRemainder % 2 == 1) {
		paddingRight = (widthRemainder+1)/2;
		paddingLeft = paddingRight-1;
	}

	else if (widthRemainder % 2 == 0) {
		paddingRight = widthRemainder/2;
		paddingLeft = widthRemainder/2;
	}

	string headerLeft = new string(' ', paddingLeft);
	string headerRight = new string(' ', paddingRight);
	centeredHeader = headerLeft + tableHeader + headerRight;

	return centeredHeader;
}

void displayPalette() {

	int colorCount = paletteHSV.Count;

	string columTitles = "    HEX         HSL            HSV            RGB";
	string columnBars = "   o---o       o---o          o---o          o---o";

	int paletteTableWidth = 55;
	string harmonyType = ColorHarmony.userHarmonyChoice;
	string tableHeader = centerHeader($"{harmonyType} Palette", paletteTableWidth);

	Console.WriteLine(tableHeader);
	Console.WriteLine(columTitles);
	Console.WriteLine(columnBars);

	for (int i=0; i < colorCount; i++) {

		string itemHEX = $"#{paletteHEX[i]}";
		string itemHSL = alignItem(paletteHSL[i], 13);
		string itemHSV = alignItem(paletteHSV[i], 13);
		string itemRGB = alignItem(paletteRGB[i], 13);

		Console.WriteLine($"  {itemHEX}  {itemHSL}  {itemHSV}  {itemRGB}");
	}

	Console.ReadKey();
}