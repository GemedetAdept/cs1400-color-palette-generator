// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek

bool inputMenu = true;


string cursorIdle = ">";
string cursorActive = ">>>";
string[] inputMenuCursors = {
	cursorIdle,
	cursorIdle,
	cursorIdle,
	cursorIdle,
	cursorIdle,
	cursorIdle,
	cursorIdle,
};

int optionActive = 0;
int menuSelection = 0;

while (inputMenu) {

	Console.Clear();

	// Reset all option cursors to default
	for (int i = 0; i < inputMenuCursors.Length; i++) {
		inputMenuCursors[i] = cursorIdle;
		inputMenuCursors[optionActive] = cursorActive;
	}

	// Display menu options
	for (int i = 0; i < inputMenuCursors.Length; i++) {
		Console.WriteLine($"{inputMenuCursors[i]} {(ColorModes)i}");
	}

	// Change active option using the Up and Down arrow keys
	var keyboardInput = Console.ReadKey(false).Key;

	if (keyboardInput == ConsoleKey.Enter) {
		menuSelection = optionActive;
		colorInput(menuSelection);
	}
	else if (keyboardInput == ConsoleKey.UpArrow && optionActive > 0){
		optionActive -= 1;
	}
	else if (keyboardInput == ConsoleKey.DownArrow && optionActive < (inputMenuCursors.Length-1)) {
		optionActive += 1;
	}
	else {
		continue;
	}
}

void colorInput(int mode) {

	inputMenu = false;
	Console.Clear();
	Console.WriteLine($"Color Mode: [{(ColorModes)mode}]");

	Snippet.Break();
	
	Console.Write("Input format: ");
	switch (mode) {

		case (int)ColorModes.CMYK:
			Console.WriteLine("71.9, 7.6, 0.0, 27.5");
			break;
		case (int)ColorModes.CSSName:
			Console.WriteLine("DarkGoldenRod");
			break;
		case (int)ColorModes.Hexadecimal:
			Console.WriteLine("#00FF00");
			break;
		case (int)ColorModes.HTMLName:
			Console.WriteLine("CornflowerBlue");
			break;
		case (int)ColorModes.HSL:
			Console.WriteLine("165.0, 100.0, 50.0");
			break;
		case (int)ColorModes.HSV:
			Console.WriteLine("186.2, 71.8, 72.7");
			break;
		case (int)ColorModes.RGB:
			Console.WriteLine("52, 171, 185");
			break;
	}

	Snippet.Break();

	string codeInput = "";
	Console.Write("> ");
	codeInput = Console.ReadLine();

	Console.WriteLine(codeInput);
};


enum ColorModes {
	CMYK,
	CSSName,
	Hexadecimal,
	HTMLName,
	HSL,
	HSV,
	RGB,
}