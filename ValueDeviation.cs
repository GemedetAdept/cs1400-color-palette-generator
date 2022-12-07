public class ValueDeviation {

	public static double ClampByLogistic(double x, double xOrig, double yOrig, double K, double A, double m, double n) {
		// Implementation of an adjustable logistic function I wrote (https://www.geogebra.org/classic/vmd7cvjj)
		// Base formula referenced from (https://en.wikipedia.org/wiki/Logistic_function), 
		// Originally from: Verhulst, Pierre-François (1838), Correspondance Mathématique et Physique. Vol. 10: p. 116

		// Given:
		//	x :: Input; value to be fitted to function, used as a linear coordinate with a y value of 0
		//	K :: Ceiling value; if the input is greater than K, it is culled to equal K.
		//	A :: Floor value; if the input is less than A, it is culled to equal A
		//	m :: Logistic Slope; the rate of value change between A and K
		//	n :: Slope Modulator; fine-tune the rate of value change without changing the base value m
		//	x₀ (xOrig) :: x-Origin; x-value of the function origin
		//	y₀ (yOrig) :: y-Origin; y-value of the function origin
		//	e :: Euler's number
		// ⨍(x) = y₀+((K-A)/(1 + e^(-m*x*n-x₀))) + A

		double logisticOutput = 0.0;

		bool boundsAreValid = CheckLogisticBounds("RGB", "red", K, A);
		if (boundsAreValid == true) {

			logisticOutput = yOrig + ((K-A)/(1 + Math.Pow(Math.E, -m*x*n-xOrig))) + A;
			return logisticOutput;
		}

		return logisticOutput;
	}

	public static bool CheckLogisticBounds(string colorType, string subValue, double ceiling, double floor) {

		double minFloor = -4.19;
		double maxCeiling = -4.19;
		string errorType = "[Error: Invalid Range]";
		string errorTypeTab = "                      ";
		Action InvalidRange = () => Console.WriteLine($"{errorType} Floor-Ceiling range '[{floor}, {ceiling}]' for value '{subValue}' of color type '{colorType}' is invalid.");
		Action GiveValidRange = () => Console.WriteLine($"{errorTypeTab} Floor-Ceiling range must be within [{minFloor}, {maxCeiling}].");

		if (colorType == "HEX") {

			minFloor = 0;
			maxCeiling = 255;

			if (ceiling > 255 || floor < 0) {InvalidRange(); GiveValidRange(); return false;}
			else return true;
		}

		if (colorType == "RGB") {

			minFloor = 0;
			maxCeiling = 255;

			if (ceiling > 255 || floor < 0) {InvalidRange(); GiveValidRange(); return false;}
			else return true;
		}

		if (colorType == "HSV") {

			// For hue only
			minFloor = 0;
			maxCeiling = 360;

			if (ceiling > 255 || floor < 0) {InvalidRange(); GiveValidRange(); return false;}
			else return true;
		}

		if (colorType == "HSL") {

			// For hue only
			minFloor = 0;
			maxCeiling = 360;

			if (ceiling > 255 || floor < 0) {InvalidRange(); GiveValidRange(); return false;}
			else return true;
		}

		else return true;
	}
}