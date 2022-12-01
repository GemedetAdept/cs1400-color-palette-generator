// Functions for converting between color modes

/* TODO
- HEX
	- HEX to HSL
	- HEX to HSV
	- HEX to RGB
- HSL
	- HSL to HEX
	[x] HSL to HSV
	- HSL to RGB
- HSV
	- HSV to HEX
	[x] HSV to HSL
	- HSV to RGB
- RGB
	- RGB to HEX
	- RGB to HSL
	[x] RGB to HSV
*/

public class ConvertMode {

	// RGB
		// Given: R,G,B ∈ [0,255],
		// R',G',B' = R/255, G/255, B/255;

		// Given: R',G',B' ∈ [0,1],
		// Xmax = max(R,G,B)
		// Xmin = min(R,G,B)
		// Chroma = Xmax - Xmin

		// (HSV & HSL)
		// For Hue (H):
		//		if C == 0, H = 0;
		//		if Xmax == R', H = 60*(0 + (G'-B')/C);
		//			*** Add 360 to H if Xmax == R ***
		//		if Xmax == G', H = 60*(2 + (B'-R')/C);
		//		if Xmax == B', H = 60*(4 + (R'-G')/C);

		// (HSV only)
		// For Value (V):
		//		Value = Xmax;
		// For Saturation (S):
		//		if V == 0, S = 0;
		//		else, S = C/V;

		// (HSL only)
		// For Lightness (L):
		//		L = (Xmax + Xmin)/2;
		// For Saturation (S):
		//		if L == 0 || 1, S = 0;
		//		else, S = (Xmax - L)/min(L, 1-L);

	public static (double, double, double) RGBtoHSV((double, double, double) inputRGB) {

		double redPrimeRGB = inputRGB.Item1/255;
		double greenPrimeRGB = inputRGB.Item2/255;
		double bluePrimeRGB = inputRGB.Item3/255;

		double hueHSV = -4.19;
		double saturationHSV = -4.19;
		double valueHSV = -4.19;

		// Catch out-of-bounds // TODO: Send back to input menu.
		bool outOfBounds = CheckOutOfBounds(inputRGB, "RGB");
		if (outOfBounds == true) {Console.WriteLine("One or more invalid values."); Console.ReadKey();}

		// RGB to HSV calculations
		else {
			List<double> checkMinMax = new List<double>();
				checkMinMax.Add(redPrimeRGB);
				checkMinMax.Add(greenPrimeRGB);
				checkMinMax.Add(bluePrimeRGB);

			double maxRGB = checkMinMax.OrderByDescending(x => x).First();
			double minRGB = checkMinMax.OrderByDescending(x => x).Last();
			double chroma = maxRGB - minRGB;

			valueHSV = maxRGB;

			if (chroma == 0) {hueHSV = 0;}
			else if (valueHSV == redPrimeRGB) {
				// I do not know this is producing the inverse of what it should, but un-inverting it makes it work, so.
				hueHSV = 60*(0 + (greenPrimeRGB - bluePrimeRGB)/chroma);
				hueHSV = 360 + hueHSV;
			}
			else if (valueHSV == greenPrimeRGB) {hueHSV = 60*(2 + (bluePrimeRGB - redPrimeRGB)/chroma);}
			else if (valueHSV == bluePrimeRGB) {hueHSV = 60*(4 + (redPrimeRGB - greenPrimeRGB)/chroma);}

			if (valueHSV == 0) {saturationHSV = 0;}
			else {saturationHSV = chroma/valueHSV;}
		}

		hueHSV = Math.Round(hueHSV);
		saturationHSV = Math.Round(saturationHSV*Math.Pow(10, 2));
		valueHSV = Math.Round(valueHSV*Math.Pow(10, 2));

		var outputHSV = (hueHSV, saturationHSV, valueHSV);
		return outputHSV;
	}

	// HSV
	public static (double, double, double) HSVtoHSL((double, double, double) inputHSV) {

		double hueHSV = inputHSV.Item1;
		double saturationHSV = inputHSV.Item2 * Math.Pow(10, -2);
		double valueHSV = inputHSV.Item3 * Math.Pow(10, -2);

		double hueHSL = -4.19;
		double saturationHSL = -4.19;
		double lightnessHSL = -4.19;

		// Catch out-of-bounds // TODO: Send back to input menu.
		var checkValuesHSV = (hueHSV, saturationHSV, valueHSV);
		bool outOfBounds = CheckOutOfBounds(checkValuesHSV, "HSV");
		if (outOfBounds == true) {Console.WriteLine("One or more invalid values."); Console.ReadKey();}

		// HSV to HSL calculations
		else {
			hueHSL = hueHSV;

			lightnessHSL = valueHSV * (1 - (saturationHSV/2));

			if (lightnessHSL == 0 || lightnessHSL == 1) {saturationHSL = 0;}
			else {saturationHSL = (valueHSV - lightnessHSL)/(Math.Min(lightnessHSL, 1-lightnessHSL));}
		}

		hueHSV = Math.Round(hueHSV);
		saturationHSL = Math.Round(saturationHSL*Math.Pow(10, 2));
		lightnessHSL = Math.Round(lightnessHSL*Math.Pow(10, 2));

		var outputHSL = (hueHSL, saturationHSL, lightnessHSL);
		return outputHSL;
	}

	// HSL
	public static (double, double, double) HSLtoHSV((double, double, double) inputHSL) {

		double hueHSL = inputHSL.Item1;
		double saturationHSL = inputHSL.Item2 * Math.Pow(10, -2);
		double lightnessHSL = inputHSL.Item3 * Math.Pow(10, -2);

		double hueHSV = -4.19;
		double saturationHSV = -4.19;
		double valueHSV = -4.19;

		// Catch out-of-bounds // TODO: Send back to input menu.
		var checkValuesHSL = (hueHSL, saturationHSL, lightnessHSL);
		bool outOfBounds = CheckOutOfBounds(checkValuesHSL, "HSV");
		if (outOfBounds == true) {Console.WriteLine("One or more invalid values."); Console.ReadKey();}

		// HSL to HSV calculations
		else {
			hueHSV = hueHSL;

			valueHSV = lightnessHSL + saturationHSL*Math.Min(lightnessHSL, 1-lightnessHSL);

			if (valueHSV == 0) {saturationHSV = 0;}
			else {saturationHSV = 2*(1-(lightnessHSL/valueHSV));} 
		}

		hueHSV = Math.Round(hueHSV);
		saturationHSV = Math.Round(saturationHSV*Math.Pow(10, 2));
		valueHSV = Math.Round(valueHSV*Math.Pow(10, 2));

		var outputHSV = (hueHSV, saturationHSV, valueHSV);
		return outputHSV;

	}

	// Check Out-of-Bounds
	public static bool CheckOutOfBounds((double, double, double) colorValues, string colorType) {

		bool isInvalid = false;

		if (colorType == "RGB") {

			double redRGB = colorValues.Item1;
			double greenRGB = colorValues.Item2;
			double blueRGB = colorValues.Item3;

			if (redRGB < 0 || redRGB > 255) {
				Console.WriteLine($"RGB red value {redRGB} is out-of-bounds (0–255).");
				isInvalid = true;
			}
			if (greenRGB < 0 || greenRGB > 255) {
				Console.WriteLine($"RGB green value {greenRGB} is out-of-bounds (0–255).");
				isInvalid = true;
			}
			if (blueRGB < 0 || blueRGB > 255) {
				Console.WriteLine($"RGB blue value {blueRGB} is out-of-bounds (0–255).");
				isInvalid = true;
			}
			else {isInvalid = false;}
		}

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

		if (colorType == "HSL") {

			double hueHSL = colorValues.Item1;
			double saturationHSL = colorValues.Item2;
			double lightnessHSL = colorValues.Item3;

			if (hueHSL < 0 || hueHSL > 360) {
				Console.WriteLine($"HSV Hue value {hueHSL} is out-of-bounds (0–360).");
				isInvalid = true;
			}
			if (saturationHSL < 0 || saturationHSL > 100) { 
				Console.WriteLine($"HSL Saturation value {saturationHSL} is out-of-bounds (0–1)");
				isInvalid = true;
			}
			if (lightnessHSL < 0 || lightnessHSL > 100) {
				Console.WriteLine($"HSL Lightness value {lightnessHSL} is out-of-bounds (0–1)");
				isInvalid = true;
			}
			else {isInvalid = false;}
		}

		return isInvalid;
	}
}