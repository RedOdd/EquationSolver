using System;
using System.Text.RegularExpressions;

namespace EquationSolverNamespace
{
    public class EquationSolver
    {
        public static int[] ParseEquation(string rawEquation)

        {
            var intParsingCoefficients = new int[3];
            string[] stringParsingCoefficients;

            var regexWithoutSpace = (@"\s");
            rawEquation = Regex.Replace(rawEquation, regexWithoutSpace, "");

            var helperWithSigns = rawEquation.ToCharArray();
            for (var count = 0; count < helperWithSigns.Length - 1; count++)
            {
                if (((helperWithSigns[count] == helperWithSigns[count + 1]) && (helperWithSigns[count] == '-')) | ((helperWithSigns[count] == '-') && (helperWithSigns[count + 1] == '+')) | ((helperWithSigns[count + 1] == '-') && (helperWithSigns[count] == '+')))
                {
                    if ((helperWithSigns[count] == helperWithSigns[count + 1]) && (helperWithSigns[count] == '-'))
                    {
                        helperWithSigns[count] = '+';
                        for (var countIntoCycle = count + 1; countIntoCycle < helperWithSigns.Length - 1; countIntoCycle++)
                        {
                            helperWithSigns[countIntoCycle] = helperWithSigns[countIntoCycle + 1];
                        }
                    }
                    else
                    {
                        if ((helperWithSigns[count] == '-') && (helperWithSigns[count + 1] == '+'))
                        {

                            for (var countIntoCycle = count + 1; countIntoCycle < helperWithSigns.Length - 1; countIntoCycle++)
                            {
                                helperWithSigns[countIntoCycle] = helperWithSigns[countIntoCycle + 1];
                            }
                        }
                        else
                        {
                            var temp = helperWithSigns[count];
                            helperWithSigns[count] = helperWithSigns[count + 1];
                            helperWithSigns[count + 1] = temp;
                            for (var countIntoCycle = count + 1; countIntoCycle < helperWithSigns.Length - 1; countIntoCycle++)
                            {
                                helperWithSigns[countIntoCycle] = helperWithSigns[countIntoCycle + 1];
                            }
                        }
                    }

                }

            }

            rawEquation = "";
            for (var count = 0; count < helperWithSigns.Length; count++)
            {
                rawEquation += helperWithSigns[count];
            }

            Regex regexSign = new Regex(@"[x]|[=]");
            stringParsingCoefficients = regexSign.Split(rawEquation);

            var arrayCountForInt = 0;
            var regexWithoutPower = (@"\^2");

            for (var count = 0; count < stringParsingCoefficients.Length; count++)
            {
                stringParsingCoefficients[count] = Regex.Replace(stringParsingCoefficients[count], regexWithoutSpace, "");
                stringParsingCoefficients[count] = Regex.Replace(stringParsingCoefficients[count], regexWithoutPower, "");
                if ((!(stringParsingCoefficients[count] == "")) & (arrayCountForInt < intParsingCoefficients.Length))
                {
                    int.TryParse(stringParsingCoefficients[count], out intParsingCoefficients[arrayCountForInt]);
                    arrayCountForInt++;
                }
            }
            return intParsingCoefficients;
        }

        public static int FindDiscriminant(int[] coefficients)
        {
            var discriminant = coefficients[1] * coefficients[1] - 4 * coefficients[0] * coefficients[2];
            return discriminant;
        }

        public static bool IsValidationOfDiscriminantIsTrue(int discriminant)
        {
            var discriminantIsTrue = false;
            if (discriminant >= 0)
            {
                discriminantIsTrue = true;
            }
            return discriminantIsTrue;
        }

        public static double FindFirstValue(int[] coefficients, int discriminant)
        {
            var firstValue = Math.Round(((-coefficients[1] + Math.Sqrt(discriminant)) / (2 * coefficients[0])), 3);
            return firstValue;
        }

        public static double FindSecondValue(int[] coefficients, int discriminant)
        {
            var secoundValue = Math.Round(((-coefficients[1] - Math.Sqrt(discriminant)) / (2 * coefficients[0])), 3);
            return secoundValue;
        }

        public static double[] ViewTwoValues(double firstValue, double secondValue)
        {
            var arrayOfValues = new[] { firstValue, secondValue };
            return arrayOfValues;
        }
    }
}
