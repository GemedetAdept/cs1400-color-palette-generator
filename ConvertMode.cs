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
	[~] HSV to RGB
- RGB
	- RGB to HEX
	- RGB to HSL
	[~] RGB to HSV
*/

public class ConvertMode {

	// RGB
	

	// HSV
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
	public static (double, double, double) HSLtoHSV((double, double, double) inputHSL) {

		double hueHSL = inputHSL.Item1;
		double saturationHSL = inputHSL.Item2 * Math.Pow(10, -2);
		double lightnessHSL = inputHSL.Item3 * Math.Pow(10, -2);

		double hueHSV = -99.0;
		double saturationHSV = -99.0;
		double valueHSV = -99.0;

		// Catch out-of-bounds // TODO: Send back to input menu.
		var checkValuesHSL = (hueHSL, saturationHSL, lightnessHSL);
		bool outOfBounds = CheckOutOfBounds(checkValuesHSL, "HSV");
		if (outOfBounds == true) { Console.WriteLine("One or more invalid values."); Console.ReadKey(); }

		// HSL to HSV calculations
		else {
			hueHSV = hueHSL;

			valueHSV = lightnessHSL + saturationHSL*Math.Min(lightnessHSL, 1-lightnessHSL);

			if (valueHSV == 0) {saturationHSV = 0;}
			else {saturationHSV = 2*(1-(lightnessHSL/valueHSV));} 
		}

		saturationHSV = Math.Round(saturationHSV*Math.Pow(10, 2));
		valueHSV = Math.Round(valueHSV*Math.Pow(10, 2));

		var outputHSV = (hueHSV, saturationHSV, valueHSV);
		return outputHSV;

	}

	// Check Out-of-Bounds
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

// TODO: Implementation of conversions is slightly off and broken.