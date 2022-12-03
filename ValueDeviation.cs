public class ValueDeviation {

	// An implementation of my custom logistic function (https://www.geogebra.org/classic/vmd7cvjj)
	// Constructed from (https://en.wikipedia.org/wiki/Logistic_function), based on: Verhulst, Pierre-François (1838), Correspondance Mathématique et Physique. Vol. 10: p. 116
	public static double ClampByLogistic(double x, double xOrig, double yOrig, double K, double A, double m, double n) {

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
		logisticOutput = yOrig + ((K-A)/(1 + Math.Pow(Math.E, -m*x*n-xOrig))) + A;
		return logisticOutput;
	}
}