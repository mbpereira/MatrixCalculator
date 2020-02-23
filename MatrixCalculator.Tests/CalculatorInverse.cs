using System;
using System.Collections.Generic;
using MatrixCalculator.Core.Contracts;
using MatrixCalculator.Core;
using MatrixCalculator.Core.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixCalculator.Tests
{
    [TestClass]
    public class CalculatorInverse
    {
        [TestMethod]
        public void ShouldReturnInverseMatrix()
        {
            Matrix test1 = new Matrix(2, 2, new double[2, 2] { { 1, 3 }, { 4, 5 } });
            Matrix test2 = new Matrix(3, 3, new double[3, 3] { { 1, 3, 8 }, { 4, 5, 0 }, { 6, 3, 1 } });
            Matrix test3 = new Matrix(4, 4, new double[4, 4] { { 1, 3, 8, 5 }, { 4, 5, 0, 0 }, { 6, 3, 1, 1 }, { 1, 3, 4, 6 } });

            Matrix expected1 = new Matrix(2, 2, new double[2, 2] { { -0.71, 0.43 }, { 0.57, -0.14 } });
            Matrix expected2 = new Matrix(3, 3, new double[3, 3] { { -0.03, -0.14, 0.26 }, { 0.03, 0.31, -0.21 }, { 0.12, -0.10, 0.05 } });
            Matrix expected3 = new Matrix(4, 4, new double[4, 4] { { -0.02, -0.13, 0.26, -0.03 }, { 0.01, 0.3, -0.21, 0.02 }, { 0.21, -0.03, 0.01, -0.18 }, { -0.15, -0.11, 0.05, 0.28 } });

            IMatrixCalculator calculator = new Calculator();

            IEnumerable<Matrix[]> testCases = new List<Matrix[]>
            {
                new Matrix[2] {expected1, test1},
                new Matrix[2] {expected2, test2},
                new Matrix[2] {expected3, test3}
            };

            foreach(Matrix[] testCase in testCases)
            {
                Assert.IsTrue(calculator.AreEqual(testCase[0], calculator.Inverse(testCase[1])));
            }
        }

    }


}
