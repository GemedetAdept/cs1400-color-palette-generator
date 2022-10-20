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

while (inputMenu) {

	Console.Clear();

	// Reset all option cursors to default
	for (int i = 0; i < inputMenuCursors.Length; i++) {
		inputMenuCursors[i] = cursorIdle;
		inputMenuCursors[optionActive] = cursorActive;
	}

	// Display menu options
	for (int i = 0; i < inputMenuCursors.Length; i++) {
		Console.WriteLine($"{inputMenuCursors[i]} {(ColorInput)i}");
	}

	// Change active option using the Up and Down arrow keys
	var arrowKeyInput = Console.ReadKey(false).Key;
	if (arrowKeyInput == ConsoleKey.UpArrow && optionActive > 0){
		optionActive -= 1;
	}
	else if (arrowKeyInput == ConsoleKey.DownArrow && optionActive < (inputMenuCursors.Length-1)) {
		optionActive += 1;
	}
	else {
		optionActive = optionActive;
	}
}



enum ColorInput {
	CMYK,
	CSSName,
	Hexadecimal,
	HexadecimalName,
	HSL,
	HSV,
	RGB,
}