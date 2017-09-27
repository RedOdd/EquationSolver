using EquationSolverNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquationSolverUnitTestProject
{
    [TestClass]
    public class EquationSolverUnitTest
    {
        [TestMethod]
        public void CheckParserParseEquation_ShouldBeTrue_MinusPLusPlus()
        {
            var equation = "-8x^2+                  3x   +                    3=0";
            var coefficients = new[] { -8, +3, 3 };
            var parsedСoefficients = EquationSolver.ParseEquation(equation);
            var isArrayEquals = true;
            for (int count = 0; count < coefficients.Length; count++)
            {
                if (!(coefficients[count] == parsedСoefficients[count]))
                {
                    isArrayEquals = false;
                }
            }

            Assert.IsTrue(isArrayEquals);
        }

        [TestMethod]
        public void CheckParserParseEquation_ShouldBeTrue_PlusMinusPlusWithTwo()
        {
            var equation = "1x^2+           -       2x   +                    1=0";
            var coefficients = new[] { 1, -2, 1 };
            var parsedСoefficients = EquationSolver.ParseEquation(equation);
            var isArrayEquals = true;
            for (int count = 0; count < coefficients.Length; count++)
            {
                if (!(coefficients[count] == parsedСoefficients[count]))
                {
                    isArrayEquals = false;
                }
            }

            Assert.IsTrue(isArrayEquals);
        }

        [TestMethod]
        public void CheckParserParseEquation_ShouldBeTrue_PlusMinusPlus()
        {
            var equation = "8x^2-        +      3x+3=0";
            var coefficients = new[] { 8, -3, 3 };
            var parsedСoefficients = EquationSolver.ParseEquation(equation);
            var isArrayEquals = true;
            for (int count = 0; count < coefficients.Length; count++)
            {
                if (!(coefficients[count] == parsedСoefficients[count]))
                {
                    isArrayEquals = false;
                }
            }

            Assert.IsTrue(isArrayEquals);
        }

        [TestMethod]
        public void CheckParserParseEquation_ShouldBeTrue_MinusPlusMinus()
        {
            var equation = "-8x^2     --       3x-3=0";
            var coefficients = new[] { -8, +3, -3 };
            var parsedСoefficients = EquationSolver.ParseEquation(equation);
            var isArrayEquals = true;
            for (int count = 0; count < coefficients.Length; count++)
            {
                if (!(coefficients[count] == parsedСoefficients[count]))
                {
                    isArrayEquals = false;
                }
            }

            Assert.IsTrue(isArrayEquals);
        }

        [TestMethod]
        public void CheckParserParseEquation_ShouldBeTrue_ZeroMinusPlus()
        {
            var equation = "-1   x^2-0x--3=0";
            var coefficients = new[] { -1, 0, +3 };
            var parsedСoefficients = EquationSolver.ParseEquation(equation);
            var isArrayEquals = true;
            for (int count = 0; count < coefficients.Length; count++)
            {
                if (!(coefficients[count] == parsedСoefficients[count]))
                {
                    isArrayEquals = false;
                }
            }

            Assert.IsTrue(isArrayEquals);
        }

        [TestMethod]
        public void CheckParserParseEquation_ShouldBeTrue_ZeroZeroZero()
        {
            var equation = "0x^2-0x+   0=0";
            var coefficients = new[] { 0, 0, 0 };
            var parsedСoefficients = EquationSolver.ParseEquation(equation);
            var isArrayEquals = true;
            for (int count = 0; count < coefficients.Length; count++)
            {
                if (!(coefficients[count] == parsedСoefficients[count]))
                {
                    isArrayEquals = false;
                }
            }

            Assert.IsTrue(isArrayEquals);
        }


        [TestMethod]
        public void CheckFindDiscriminant_ShouldBeEqual()
        {
            var arrayTestDiscriminant = new[] { 1, 4, 3 };
            var ourTestDiscriminant = 4;
            var testDiscriminant = EquationSolver.FindDiscriminant(arrayTestDiscriminant);
            Assert.AreEqual(testDiscriminant, ourTestDiscriminant);
        }

        [TestMethod]
        public void CheckValidDiscriminant_ShouldBeEqual_Plus()
        {
            var discriminantIsTrue = true;
            var testDiscriminantIsTrue = EquationSolver.IsValidationOfDiscriminantIsTrue(1);
            Assert.AreEqual(discriminantIsTrue, testDiscriminantIsTrue);
        }

        [TestMethod]
        public void CheckValidDiscriminant_ShouldBeEqual_Zero()
        {
            var discriminantIsTrue = true;
            var testDiscriminantIsTrue = EquationSolver.IsValidationOfDiscriminantIsTrue(0);
            Assert.AreEqual(discriminantIsTrue, testDiscriminantIsTrue);
        }

        [TestMethod]
        public void CheckValidDiscriminant_ShouldBeEqual_Minus()
        {
            var discriminantIsTrue = false;
            var testDiscriminantIsTrue = EquationSolver.IsValidationOfDiscriminantIsTrue(-1);
            Assert.AreEqual(discriminantIsTrue, testDiscriminantIsTrue);
        }

        [TestMethod]
        public void CheckFindingFirstValue_ShouldBeEqual_PlusPlusPlus()
        {
            var сoefficients = new[] { 7, 8, 1 };
            var discriminant = 36;
            var firstValue = -0.143;
            var testFirstValue = EquationSolver.FindFirstValue(сoefficients, discriminant);
            Assert.AreEqual(firstValue, testFirstValue);
        }

        [TestMethod]
        public void CheckFindingFirstValue_ShouldBeEqual_PlusMinusPlus()
        {
            var сoefficients = new[] { 7, -8, 1 };
            var discriminant = 36;
            var firstValue = 1;
            var testFirstValue = EquationSolver.FindFirstValue(сoefficients, discriminant);
            Assert.AreEqual(firstValue, testFirstValue);
        }

        [TestMethod]
        public void CheckFindingFirstValue_ShouldBeEqual_MinusPlusMinus()
        {
            var сoefficients = new[] { -7, 8, -1 };
            var discriminant = 36;
            var firstValue = 0.143;
            var testFirstValue = EquationSolver.FindFirstValue(сoefficients, discriminant);
            Assert.AreEqual(firstValue, testFirstValue);
        }

        [TestMethod]
        public void CheckFindingFirstValue_ShouldBeEqual_MinusZeroPlus()
        {
            var сoefficients = new[] { -2, 0, 2 };
            var discriminant = 16;
            var firstValue = -1;
            var testFirstValue = EquationSolver.FindFirstValue(сoefficients, discriminant);
            Assert.AreEqual(firstValue, testFirstValue);
        }

        [TestMethod]
        public void CheckFindingSecondValue_ShouldBeEqual_PlusPlusPlus()
        {
            var сoefficients = new[] { 7, 8, 1 };
            var discriminant = 36;
            var secondValue = -1;
            var testSecondValue = EquationSolver.FindSecondValue(сoefficients, discriminant);
            Assert.AreEqual(secondValue, testSecondValue);
        }

        [TestMethod]
        public void CheckFindingSecondValue_ShouldBeEqual_PlusMinusPlus()
        {
            var сoefficients = new[] { 7, -8, 1 };
            var discriminant = 36;
            var secondValue = 0.143;
            var testSecondValue = EquationSolver.FindSecondValue(сoefficients, discriminant);
            Assert.AreEqual(secondValue, testSecondValue);
        }

        [TestMethod]
        public void CheckFindingSecondValue_ShouldBeEqual_MinusPlusMinus()
        {
            var сoefficients = new[] { -7, 8, -1 };
            var discriminant = 36;
            var secondValue = 1;
            var testSecondValue = EquationSolver.FindSecondValue(сoefficients, discriminant);
            Assert.AreEqual(secondValue, testSecondValue);
        }

        [TestMethod]
        public void CheckFindingSecondValue_ShouldBeEqual_MinusZeroPlus()
        {
            var сoefficients = new[] { -2, 0, 2 };
            var discriminant = 16;
            var secondValue = 1;
            var testSecondValue = EquationSolver.FindSecondValue(сoefficients, discriminant);
            Assert.AreEqual(secondValue, testSecondValue);
        }

        [TestMethod]
        public void CheckViewValues_ShouldBeTrue()
        {
            var firstValue = 10;
            var secondValue = 5;
            var ourTestArrayTwoValues = new[] { 10, 5 };
            var testArrayTwoValues = EquationSolver.ViewTwoValues(firstValue, secondValue);
            var isTrueEqualArray = true;
            for (var count = 0; count < testArrayTwoValues.Length; count++)
            {
                if (!(testArrayTwoValues[count] == ourTestArrayTwoValues[count]))
                {
                    isTrueEqualArray = false;
                }
            }

            Assert.IsTrue(isTrueEqualArray);
        }
    }
}
