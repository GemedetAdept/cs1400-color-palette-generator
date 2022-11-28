// Functions for converting between color modes

/* TODO
- HEX
	- HEX to CMYK
	- HEX to HSL
	- HEX to HSV
	- HEX to RGB
- HSL
	- HSL to CMYK
	- HSL to HEX
	- HSL to HSV
	- HSL to RGB
- HSV
	- HSV to CMYK
	- HSV to HEX
	- HSV to HSL
	- HSV to RGB
- RGB
	- RGB to HEX
	- RGB to CMYK
	- RGB to HSL
	- RGB to HSV
*/

public class ConvertMode {

	public static string RGBToHex(int red, int green, int blue) {

		List<string> hexParts = new List<string>();
		string hexOutput = "#";

		List<string> convertedRed = new List<string>();
		convertedRed = ConvertFromBaseTen((double)red, 16, convertedRed);

		List<string> convertedGreen = new List<string>();
		convertedGreen = ConvertFromBaseTen((double)green, 16, convertedGreen);

		List<string> convertedBlue = new List<string>();
		convertedBlue = ConvertFromBaseTen((double)blue, 16, convertedBlue);


		hexParts.AddRange(convertedRed);
		hexParts.AddRange(convertedGreen);
		hexParts.AddRange(convertedBlue);

		hexOutput += string.Join("", hexParts);
		return hexOutput;
	}

	public static string RGBtoHSV(int red, int green, int blue) {

		
	}
}