using System;
using MatrixCalculator.Models;
using MatrixCalculator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixCalculator.Tests
{
    [TestClass]
    public class CalculatorDeterminant
    {
        [TestMethod]
        public void Matrix2x2()
        {
            Matrix m = new Matrix(2, 2, new double[2, 2] { { 1, 3 }, { 4, 5 } });

            Calculator calculator = new Calculator();

            double expected = -7;

            double result = calculator.Determinant(m);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Matrix3x3()
        {
            Matrix m = new Matrix(3, 3, new double[3, 3] { { 1, 3, 8 }, { 4, 5, 0 }, { 6, 3, 1 } });

            Calculator calculator = new Calculator();

            double expected = -151;

            double result = calculator.Determinant(m);

            Assert.AreEqual(expected, result);
        }
    }
}
