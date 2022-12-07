using userinput;
// Functions for converting between color modes

/* TODO
- HEX
	[x] HEX to HSL
	[x] HEX to HSV
	[x] HEX to RGB
- HSL
	[x] HSL to HEX
	[x] HSL to HSV
	[x] HSL to RGB
- HSV
	[x] HSV to HEX
	[x] HSV to HSL
	[x] HSV to RGB
- RGB
	[x] RGB to HEX
	[x] RGB to HSL
	[x] RGB to HSV
*/

public class ConvertMode {

	// HEX
	// Due to the way that HSL and HSV values are stored, 
	// it is necessary to first convert to RGB and then use the respective "RGBto..." method.

	public static (double, double, double) HEXtoHSL(string inputHEX) {

		var stepRGB = HEXtoRGB(inputHEX);
		var outputHSL = RGBtoHSL(stepRGB);

		return outputHSL;
	}
	public static (double, double, double) HEXtoHSV(string inputHEX) {

		var stepRGB = HEXtoRGB(inputHEX);
		var outputHSV = RGBtoHSV(stepRGB);

		return outputHSV;
	}
	public static (double, double, double) HEXtoRGB(string inputHEX) {
		int decimalInteger = UserInput.ConvertToInteger(inputHEX);
		byte[] valueBytes = BitConverter.GetBytes(decimalInteger);

		// Byte array is in reverse "RGB" order, thus backwards indexes.
		int redRGB = valueBytes[2];
		int greenRGB = valueBytes[1];
		int blueRGB = valueBytes[0];

		var outputRGB = ((double)redRGB, (double)greenRGB, (double)blueRGB);
		return outputRGB;
	}

	// RGB
	public static string RGBtoHEX((double, double, double) inputRGB) {

		int redRGB = (int)inputRGB.Item1;
		int greenRGB = (int)inputRGB.Item2;
		int blueRGB = (int)inputRGB.Item3;

		byte[] valueBytes = new byte[] {

			Convert.ToByte(blueRGB),
			Convert.ToByte(greenRGB),
			Convert.ToByte(redRGB),
			0,
		};

		int intValue = BitConverter.ToInt32(valueBytes, 0);
		string outputHEX = UserInput.ConvertToHexadecimal(intValue);
		return outputHEX;
	}	
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
				// I do not know why this is producing the inverse of what it should, but un-inverting it makes it work, so.
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
	public static (double, double, double) RGBtoHSL((double, double, double) inputRGB) {

		double redPrimeRGB = inputRGB.Item1/255;
		double greenPrimeRGB = inputRGB.Item2/255;
		double bluePrimeRGB = inputRGB.Item3/255;

		double hueHSL = -4.19;
		double saturationHSL = -4.19;
		double lightnessHSL = -4.19;

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

			if (chroma == 0) {hueHSL = 0;}
			else if (maxRGB == redPrimeRGB) {
				// I do not know why this is producing the inverse of what it should, but un-inverting it makes it work, so.
				hueHSL = 60*(0 + (greenPrimeRGB - bluePrimeRGB)/chroma);
				hueHSL = 360 + hueHSL;
			}
			else if (maxRGB == greenPrimeRGB) {hueHSL = 60*(2 + (bluePrimeRGB - redPrimeRGB)/chroma);}
			else if (maxRGB == bluePrimeRGB) {hueHSL = 60*(4 + (redPrimeRGB - greenPrimeRGB)/chroma);}

			lightnessHSL = (maxRGB + minRGB)/2;

			if (lightnessHSL == 0 || lightnessHSL == 1) {saturationHSL = 0;}
			else {saturationHSL = (maxRGB - lightnessHSL)/Math.Min(lightnessHSL, 1-lightnessHSL);}
		}

		hueHSL = Math.Round(hueHSL);
		saturationHSL = Math.Round(saturationHSL*Math.Pow(10, 2));
		lightnessHSL = Math.Round(lightnessHSL*Math.Pow(10, 2));

		var outputHSL = (hueHSL, saturationHSL, lightnessHSL);
		return outputHSL;
	}

	// HSV
	public static string HSVtoHEX((double, double, double) inputHSV) {

		var stepRGB = HSVtoRGB(inputHSV);
		var outputHEX = RGBtoHEX(stepRGB);

		return outputHEX;
	}
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

		hueHSL = Math.Round(hueHSL);
		saturationHSL = Math.Round(saturationHSL*Math.Pow(10, 2));
		lightnessHSL = Math.Round(lightnessHSL*Math.Pow(10, 2));

		var outputHSL = (hueHSL, saturationHSL, lightnessHSL);
		return outputHSL;
	}
	public static (double, double, double) HSVtoRGB((double, double, double) inputHSV) {

		double hueHSV = inputHSV.Item1;
		double saturationHSV = inputHSV.Item2 * Math.Pow(10, -2);
		double valueHSV = inputHSV.Item3 * Math.Pow(10, -2);

		double redRGB = -4.19;
		double greenRGB = -4.19;
		double blueRGB = -4.19;		

		// Catch out-of-bounds // TODO: Send back to input menu.
		var checkValuesHSV = (hueHSV, saturationHSV, valueHSV);
		bool outOfBounds = CheckOutOfBounds(checkValuesHSV, "HSV");
		if (outOfBounds == true) {Console.WriteLine("One or more invalid values."); Console.ReadKey();}

		// HSV to RGB calculations
			// Alternative HSV to RGB from https://en.wikipedia.org/wiki/HSL_and_HSV#HSV_to_RGB_alternative
			// Given: H ∈ [0,360], S ∈ [0,1], V ∈ [0,1],
			// ⨍(n) = V - V*S* max(0, min(k, 4-k, 1))
			//		Where k,n ∈ R≥₀, and:
			//			k = (n + (H/60)) % 6
			// (R,G,B) = (⨍(5), ⨍(3), ⨍(1))
		else {
			Func<double, double> valueK = n => (n + hueHSV/60)%6;
			Func<double, double> altConvert = n => valueHSV-valueHSV*saturationHSV * Math.Max(0, Math.Min(valueK(n), Math.Min(4-valueK(n), 1)));

			redRGB = altConvert(5);
			greenRGB = altConvert(3);
			blueRGB = altConvert(1);
		}

		redRGB = Math.Round(redRGB*255);
		greenRGB = Math.Round(greenRGB*255);
		blueRGB = Math.Round(blueRGB*255);

		var outputRGB = (redRGB, greenRGB, blueRGB);
		return outputRGB;
	}

	// HSL
	public static string HSLtoHEX((double, double, double) inputHSL) {

		var stepRGB = HSLtoRGB(inputHSL);
		var outputHEX = RGBtoHEX(stepRGB);

		return outputHEX;
	}
	public static (double, double, double) HSLtoRGB((double, double, double) inputHSL) {

		double hueHSL = inputHSL.Item1;
		double saturationHSL = inputHSL.Item2 * Math.Pow(10, -2);
		double lightnessHSL = inputHSL.Item3 * Math.Pow(10, -2);

		double redRGB = -4.19;
		double greenRGB = -4.19;
		double blueRGB = -4.19;

		// Catch out-of-bounds // TODO: Send back to input menu.
		var checkValuesHSL = (hueHSL, saturationHSL, lightnessHSL);
		bool outOfBounds = CheckOutOfBounds(checkValuesHSL, "HSL");
		if (outOfBounds == true) {Console.WriteLine("One or more invalid values."); Console.ReadKey();}

		// HSL to RGB calculations
			// Alternative HSL to RGB from https://en.wikipedia.org/wiki/HSL_and_HSV#HSL_to_RGB_alternative
			// Given: H ∈ [0,360], S ∈ [0,1], and L ∈ [0,1],
			// ⨍(n) = L - a * max(-1, min(k-3, 9-k, 1))
			//		Where k,n ∈ R≥₀, and:
			//			k = (n + (H/30)) % 12
			//			a = S*min(L, 1-L)
			// (R,G,B) = (⨍(0), ⨍(8), ⨍(4))
		else {
			double valueA = saturationHSL * Math.Min(lightnessHSL, 1-lightnessHSL);
			Func<double, double> valueK = n => (n + hueHSL/30)%12;
			Func<double, double> altConvert = n => lightnessHSL-valueA * Math.Max(-1, Math.Min(valueK(n)-3, Math.Min(9-valueK(n), 1)));
			
			redRGB = altConvert(0);
			greenRGB = altConvert(8);
			blueRGB = altConvert(4);
		}

		redRGB = Math.Round(redRGB*255);
		greenRGB = Math.Round(greenRGB*255);
		blueRGB = Math.Round(blueRGB*255);

		var outputRGB = (redRGB, greenRGB, blueRGB);
		return outputRGB;
	}
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