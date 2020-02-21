using System;
using MatrixCalculator.Models;
using MatrixCalculator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MatrixCalculator.Tests
{
    [TestClass]
    public class CalculatorDeterminant
    {

        [TestMethod]
        public void ShouldReturnDeterminant()
        {
            Matrix test0 = new Matrix(1, 1, new double[1, 1] { { 5 } });
            Matrix test1 = new Matrix(2, 2, new double[2, 2] { { 1, 3 }, { 4, 5 } });
            Matrix test2 = new Matrix(3, 3, new double[3, 3] { { 1, 3, 8 }, { 4, 5, 0 }, { 6, 3, 1 } });
            Matrix test3 = new Matrix(4, 4, new double[4, 4] { { 1, 3, 8, 5 }, { 4, 5, 0, 0 }, { 6, 3, 1, 1 }, { 1, 3, 4, 6 } });

            Calculator calculator = new Calculator();

            IEnumerable<MatrixWrapperTest> testCases = new List<MatrixWrapperTest>
            {
                new MatrixWrapperTest { Expected = 5, Matrix = test0 },
                new MatrixWrapperTest { Expected = -7, Matrix = test1 },
                new MatrixWrapperTest { Expected = -151, Matrix = test2 },
                new MatrixWrapperTest { Expected = -539, Matrix = test3 }
            };

            foreach (MatrixWrapperTest testCase in testCases)
            {
                Assert.AreEqual(testCase.Expected, calculator.Determinant(testCase.Matrix));
            }

        }
       
    }
}
