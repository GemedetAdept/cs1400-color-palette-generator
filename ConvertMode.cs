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
	[x] HSV to HSL
	[~] HSV to RGB
- RGB
	- RGB to HEX
	- RGB to HSL
	[~] RGB to HSV
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

		(double, double, double) valuesHSV = (
			Math.Round(hueHSV, 0), 
			Math.Round(saturationHSV*Math.Pow(10,2), 0), 
			Math.Round(valueHSV*Math.Pow(10,2), 0)
		);
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

		(double, double, double) valuesHSL = (
			Math.Round(hueHSL, 0), 
			Math.Round(saturationHSL*Math.Pow(10,2), 0), 
			Math.Round(lightnessHSL*Math.Pow(10,2), 0)
		);
		return valuesHSL;
	}

	// HSV
	public static (double, double, double) HSVtoRGB((double, double, double) inputHSV) {

		double hueHSV = inputHSV.Item1*Math.Pow(10, -2);
		double saturationHSV = inputHSV.Item2*Math.Pow(10, -2);
		double valueHSV = inputHSV.Item3*Math.Pow(10, -2);

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

		(double, double, double) valuesRGB = (
			(int)((redPrime+mValue)*255), 
			(int)((greenPrime+mValue)*255), 
			(int)((bluePrime+mValue)*255)
		);
		return valuesRGB;
	}

	public static (double, double, double) HSVtoHSL((double, double, double) inputHSV) {

		double hueHSV = inputHSV.Item1;
		double saturationHSV = inputHSV.Item2 * Math.Pow(10, -2);
		double valueHSV = inputHSV.Item3 * Math.Pow(10, -2);

		double hueHSL = -99.0;
		double saturationHSL = -99.0;
		double lightnessHSL = -99.0;

		// Catch out-of-bounds // TODO: Send back to input menu.
		var checkValuesHSV = (hueHSV, saturationHSV, valueHSV);
		bool outOfBounds = CheckOutOfBounds(checkValuesHSV, "HSV");
		if (outOfBounds == true) { Console.WriteLine("One or more invalid values."); Console.ReadKey(); }

		// HSV to HSL calculations
		else {
			hueHSL = hueHSV;
			lightnessHSL = valueHSV * (1 - (saturationHSV/2));

			if (lightnessHSL == 0 || lightnessHSL == 1) {saturationHSL = 0;}
			else {saturationHSL = (valueHSV - lightnessHSL)/(Math.Min(lightnessHSL, 1-lightnessHSL));}
		}

		saturationHSL = Math.Round(saturationHSL*Math.Pow(10, 2));
		lightnessHSL = Math.Round(lightnessHSL*Math.Pow(10, 2));

		var outputHSL = (hueHSL, saturationHSL, lightnessHSL);
		return outputHSL;
	}

	// HSL
	public static void HSLtoHSV((double, double, double) inputHSL) {


	}

	public static bool CheckOutOfBounds((double, double, double) colorValues, string colorType) {

		bool isInvalid = false;

		if (colorType == "HSV") {

			double hueHSV = colorValues.Item1;
			double saturationHSV = colorValues.Item2;
			double valueHSV = colorValues.Item3;

			if (hueHSV < 0 || hueHSV > 360) {
				Console.WriteLine($"HSV Hue value {hueHSV} is out-of-bounds (0–360).");
				isInvalid = true;
			}
			if (saturationHSV < 0 || saturationHSV > 100) { 
				Console.WriteLine($"HSV Saturation value {saturationHSV} is out-of-bounds (0–1)");
				isInvalid = true;
			}
			if (valueHSV < 0 || valueHSV > 100) {
				Console.WriteLine($"HSV Value value {valueHSV} is out-of-bounds (0–1)");
				isInvalid = true;
			}
			else {isInvalid = false;}
		}

		return isInvalid;
	}
}

// TODO: Implementation of conversions is slightly off and broken.