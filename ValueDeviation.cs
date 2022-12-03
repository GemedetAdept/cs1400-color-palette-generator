public class ValueDeviation {

	// An implementation of my custom logistic function (https://www.geogebra.org/classic/vmd7cvjj)
	// Constructed from (https://en.wikipedia.org/wiki/Logistic_function), based on: Verhulst, Pierre-François (1838), Correspondance Mathématique et Physique. Vol. 10: p. 116
	public static double ClampByLogistic() {

		// Given:
		//	x :: Input; value to be fitted to function
		//	K :: Ceiling value; if the input is greater than K, it is culled to equal K.
		//	A :: Floor value; if the input is less than A, it is culled to equal A
		//	k :: Logistic Slope; the rate of value change between A and K
		//	n :: Slope Modulator; fine-tune the rate of value change without changing the base value k
		//	x₀ :: x-Origin; x-value of the function origin
		//	y₀ :: y-Origin; y-value of the function origin
		//
		// ⨍(x) = y₀+((K-A)/(1 + e^(-k*x*n-x₀))) + A

	}
}