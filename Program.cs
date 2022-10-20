// CS 1400, Final Project - Color Palette Generator
// By: Jasmine Carrasco, Chad Miller, and Pluto Zitek

bool inputMenu = true;


string cursorIdle = "> ";
string cursorActive = ">>> ";
string[] inputMenuCursors = {
	cursorIdle,
	cursorIdle,
	cursorIdle,
	cursorIdle,
	cursorIdle,
	cursorIdle,
	cursorIdle,
};

while (inputMenu) {

	for (int i = 0; i < inputMenuCursors.Length; i++) {
		Console.WriteLine($"{inputMenuCursors[i]} {(ColorInput)i}");
	}
	Console.ReadKey();
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