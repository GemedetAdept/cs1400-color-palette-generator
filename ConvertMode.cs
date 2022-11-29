// Functions for converting between color modes

/* TODO
- HEX
	- HEX to HSL
	- HEX to HSV
	- HEX to RGB
- HSL
	- HSL to HEX
	- HSL to HSV
	- HSL to RGB
- HSV
	- HSV to HEX
	- HSV to HSL
	[x] HSV to RGB
- RGB
	- RGB to HEX
	- RGB to HSL
	[x] RGB to HSV
*/

public class ConvertMode {

	// RGB
	public static (double, double, double) RGBtoHSV((double, double, double) inputRGB) {

		List<double> valuesRGB = new List<double>();

		double redPrime = inputRGB.Item1/255;
		double greenPrime = inputRGB.Item2/255;
		double bluePrime = inputRGB.Item3/255;

		valuesRGB.Add(redPrime);
		valuesRGB.Add(greenPrime);
		valuesRGB.Add(bluePrime);

		double colorMax = valuesRGB.Max();
		double colorMin = valuesRGB.Min();
		double deltaMinMax = colorMax - colorMin;

		double hueHSV = 0.0;
		if (deltaMinMax == 0) { hueHSV = 0; }
		else if (colorMax == redPrime) { hueHSV = 60*(((greenPrime - bluePrime)/deltaMinMax) % 6); }
		else if (colorMax == greenPrime) { hueHSV = 60*(((bluePrime - redPrime)/deltaMinMax) + 2); }
		else if (colorMax == bluePrime) { hueHSV = 60*(((redPrime - greenPrime)/deltaMinMax) + 4); }

		double saturationHSV = 0.0;
		if (colorMax == 0) { saturationHSV = 0; }
		else if (colorMax != 0) { saturationHSV = deltaMinMax/colorMax; }

		double valueHSV = colorMax;

		(double, double, double) valuesHSV = (hueHSV, saturationHSV, valueHSV);
		return valuesHSV;
	}

	public static (double, double, double) RGBtoHSL((double, double, double) inputRGB) {

		List<double> valuesRGB = new List<double>();

		double redPrime = inputRGB.Item1/255;
		double greenPrime = inputRGB.Item2/255;
		double bluePrime = inputRGB.Item3/255;

		valuesRGB.Add(redPrime);
		valuesRGB.Add(greenPrime);
		valuesRGB.Add(bluePrime);

		double colorMax = valuesRGB.Max();
		double colorMin = valuesRGB.Min();
		double deltaMinMax = colorMax - colorMin;

		double hueHSL = 0.0;
		if (deltaMinMax == 0) { hueHSL = 0; }
		else if (colorMax == redPrime) { hueHSL = 60*(((greenPrime - bluePrime)/deltaMinMax) % 6); }
		else if (colorMax == greenPrime) { hueHSL = 60*(((bluePrime - redPrime)/deltaMinMax) + 2); }
		else if (colorMax == bluePrime) { hueHSL = 60*(((redPrime - greenPrime)/deltaMinMax) + 4); }

		double lightnessHSL = (colorMax + colorMin)/2;

		double saturationHSL = 0.0;
		if (deltaMinMax == 0) { saturationHSL = 0; }
		else if (deltaMinMax != 0) { saturationHSL = deltaMinMax/(1 - Math.Abs((2*lightnessHSL)-1)); }

		(double, double, double) valuesHSL = (hueHSL, saturationHSL, lightnessHSL);
		return valuesHSL;
	}

	// HSV
	public static (double, double, double) HSVtoRGB((double, double, double) inputHSV) {

		double hueHSV = inputHSV.Item1;
		double saturationHSV = inputHSV.Item2;
		double valueHSV = inputHSV.Item3;

		// In the formula, these are literally just the letters C, X, and m
		// I now have a vendetta against mathmaticians for their dumb, single-letter variable names
		double chroma = valueHSV * saturationHSV;
		double XValue = chroma*(1-Math.Abs((hueHSV/60) % 2 ) - 1);
		double mValue = valueHSV - chroma;

		(double, double, double) primesRGB = (0.0, 0.0, 0.0);
		if (0 <= hueHSV && hueHSV < 60) {primesRGB = (chroma, XValue, 0);}
		else if (60 <= hueHSV && hueHSV < 120) {primesRGB = (XValue, chroma, 0);}
		else if (120 <= hueHSV && hueHSV < 180) {primesRGB = (0, chroma, XValue);}
		else if (180 <= hueHSV && hueHSV < 240) {primesRGB = (0, XValue, chroma);}
		else if (240 <= hueHSV && hueHSV < 300) {primesRGB = (XValue, 0, chroma);}
		else if (300 <= hueHSV && hueHSV < 360) {primesRGB = (chroma, 0, XValue);}

		double redPrime = primesRGB.Item1;
		double greenPrime = primesRGB.Item2;
		double bluePrime = primesRGB.Item3;

		(double, double, double) valuesRGB = ((redPrime+mValue)*255, (greenPrime+mValue)*255, (bluePrime+mValue)*255);
		return valuesRGB;
	}
}