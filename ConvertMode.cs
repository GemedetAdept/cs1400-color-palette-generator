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

	public static (double, double, double) RGBtoHSV(int red, int green, int blue) {

		List<double> valuesRGB = new List<double>();

		double redPrime = red/255;
		double greenPrime = green/255;
		double bluePrime = blue/255;

		valuesRGB.Add(redPrime);
		valuesRGB.Add(greenPrime);
		valuesRGB.Add(bluePrime);

		double colorMax = valuesRGB.Max();
		double colorMin = valuesRGB.Min();
		double deltaMinMax = colorMax - colorMin;

		double HSVhue = 0.0;
		if (deltaMinMax == 0) { HSVhue = 0; }
		else if (colorMax == redPrime) { HSVhue = 60*(((greenPrime - bluePrime)/deltaMinMax) % 6); }
		else if (colorMax == greenPrime) { HSVhue = 60*(((bluePrime - redPrime)/deltaMinMax) + 2); }
		else if (colorMax == bluePrime) { HSVhue = 60*(((redPrime - greenPrime)/deltaMinMax) + 4); }

		double HSVsaturation = 0.0;
		if (colorMax == 0) { HSVsaturation = 0; }
		else if (colorMax != 0) { HSVsaturation = deltaMinMax/colorMax; }

		double HSVvalue = colorMax;

		(double, double, double) valuesHSV = (HSVhue, HSVsaturation, HSVvalue);
		return valuesHSV;
	}
}