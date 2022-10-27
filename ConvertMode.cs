// Functions for converting between color modes

/* TODO
- CMYK
	- CMYK to HEX
	- CMYK to HSL
	- CMYK to HSV
	- CMYK to RGB
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

	public static void ConvertFromBaseTen(double input, int baseOutput, List<string> outputValue) {


		Dictionary<string, int> baseAlphabet = new Dictionary<string, int>() {
			{"A", 10}, {"B", 11}, {"C", 12}, {"D", 13}, {"E", 14}, {"F", 15}, {"G", 16}, {"H", 17}, 
			{"I", 18}, {"J", 19}, {"K", 20}, {"L", 21}, {"M", 22}, {"N", 23}, {"O", 24}, {"P", 25}, 
			{"Q", 26}, {"R", 27}, {"S", 28}, {"T", 29}, {"U", 30}, {"V", 31}, {"W", 32}, {"X", 33}, 
			{"Y", 34}, {"Z", 35},
		};

		foreach (var keyValuePair in baseAlphabet) {

			if ((int)input == keyValuePair.Value) {
				Console.WriteLine(keyValuePair.Key);

			}
		}
	}

	public static void RGBToHex(int red, int green, int blue) {
		
	}

}