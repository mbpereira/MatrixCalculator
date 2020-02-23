using System;
using System.Collections.Generic;
using MatrixCalculator.Core.Contracts;
using MatrixCalculator.Core;
using MatrixCalculator.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixCalculator.Tests
{
    [TestClass]
    public class CalculatorSimilars
    {
        [TestMethod]
        public void ShouldReturnDifference()
        {
            Matrix test1_1 = new Matrix(2, 2, new double[2, 2] { { 1, 3 }, { 4, 5 } });
            Matrix test1_2 = new Matrix(2, 2, new double[2, 2] { { 4, 6 }, { 0, 1 } });

            Matrix test2_1 = new Matrix(3, 3, new double[3, 3] { { 1, 3, 8 }, { 4, 5, 0 }, { 6, 3, 1 } });
            Matrix test2_2 = new Matrix(3, 3, new double[3, 3] { { 2, -3, 44 }, { 12, 50, 0 }, { 0, 3, 1 } });

            Matrix test3_1 = new Matrix(4, 4, new double[4, 4] { { 1, 3, 8, 5 }, { 4, 5, 0, 0 }, { 6, 3, 1, 1 }, { 1, 3, 4, 6 } });
            Matrix test3_2 = new Matrix(4, 4, new double[4, 4] { { 7, 13, 28, 11 }, { 43, 51, 2, -5 }, { -6, 33, 11, 10 }, { 5, 6, 7, 0 } });


            Matrix expected1 = new Matrix(2, 2, new double[2, 2] { { -3, -3 }, { 4, 4 } });
            Matrix expected2 = new Matrix(3, 3, new double[3, 3] { { -1, 6, -36 }, { -8,-45, 0 }, { 6, 0, 0 } });
            Matrix expected3 = new Matrix(4, 4, new double[4, 4] { { -6, -10, -20, -6 }, { -39, -46, -2, 5 }, { 12, -30, -10, -9 }, { -4, -3, -3, 6 } });

            IMatrixCalculator calculator = new Calculator();

            IEnumerable<Matrix[]> testCases = new List<Matrix[]>
            {
                new Matrix[2] { expected1, calculator.Subtract(test1_1, test1_2) },
                new Matrix[2] { expected2, calculator.Subtract(test2_1, test2_2) },
                new Matrix[2] { expected3, calculator.Subtract(test3_1, test3_2) }
            };

            foreach(Matrix[] testCase in testCases)
            {
                calculator.AreEqual(testCase[0], testCase[1]);
            }

        }
    }
}
