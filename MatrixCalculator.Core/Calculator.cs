using MatrixCalculator.Core.Contracts;
using MatrixCalculator.Core.Models;
using System;

namespace MatrixCalculator.Core
{
    public class Calculator : IMatrixCalculator
    {
        public Matrix Cofactor(Matrix m)
        {
            double[,] cofactor = new double[m.NumberOfRows, m.NumberOfColumns];

            for(int i = 0; i < m.NumberOfRows; i++)
            {
                for(int j = 0; j < m.NumberOfColumns; j++)
                {
                    Matrix cofactorOfElement = CofactorElement(i, j, m);

                    cofactor[i, j] = Math.Pow(-1, (i + j)) * Determinant(cofactorOfElement);
                }
            }

            return new Matrix(m.NumberOfRows, m.NumberOfColumns, cofactor);
        }

        public Matrix CofactorElement(int i, int j, Matrix m)
        {
            int newNumberOfRows = m.NumberOfRows - 1;
            int newNumberOfColumns = m.NumberOfColumns - 1;
            int newRow = 0, newColumn = 0;

            double[,] cofactorElement = new double[newNumberOfRows, newNumberOfColumns];
            
            for (int row = 0; row < m.NumberOfRows; row++)
            {
                if (row == i)
                    continue;

                newColumn = 0;
                for(int column = 0; column < m.NumberOfColumns; column++)
                {
                    if (column == j) continue;

                    cofactorElement[newRow, newColumn++] = m.GetItem(row, column);
                }
                newRow++;
            }

            return new Matrix(newNumberOfRows, newNumberOfColumns, cofactorElement);
        }

        public double Determinant(Matrix matrix)
        {
            if (matrix.NumberOfColumns != matrix.NumberOfRows)
                throw new InvalidOperationException("Não é possível calcular o determinante de uma matriz não quadrada");

            if (matrix.NumberOfColumns == 1 && matrix.NumberOfRows == 1)
                return matrix.GetItem(0, 0);

            double determinant = 0.0;

            if (matrix.NumberOfColumns == 2 && matrix.NumberOfRows == 2)
            {
                determinant += matrix.GetItem(0, 0) * matrix.GetItem(1, 1);
                determinant -= matrix.GetItem(1, 0) * matrix.GetItem(0, 1);

                return determinant;
            }

            // aqui utilizamos o teorema de laplace para calcular
            // sempre usaremos a primeira coluna para o calculo

            int columnChoosed = 0;

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                Matrix cofactorElement = CofactorElement(i, columnChoosed, matrix);
                determinant += 
                    Math.Pow((-1), (i + columnChoosed)) 
                    * matrix.GetItem(i, columnChoosed)
                    * Determinant(cofactorElement); 
            }

            return determinant;
        }

        public Matrix Inverse(Matrix m)
        {
            double det = Determinant(m);

            return Scalar((1.0 / det), Adjuntage(m));
        }

        public Matrix Adjuntage(Matrix m) => Transpose(Cofactor(m));
        

        public Matrix Product(Matrix m1, Matrix m2)
        {
            if (m1.NumberOfColumns != m2.NumberOfRows)
                throw new InvalidOperationException("Matriz com número de colunas diferente do número de linhas");

            double[,] product = new double[m1.NumberOfRows, m2.NumberOfColumns];

            for (int rowM1 = 0; rowM1 < m1.NumberOfRows; rowM1++)
            {
                for (int columnM2 = 0; columnM2 < m2.NumberOfColumns; columnM2++)
                {
                    for (int columnM1 = 0; columnM1 < m1.NumberOfColumns; columnM1++)
                    {
                        product[rowM1, columnM2] += m1.GetItem(rowM1, columnM1) * m2.GetItem(columnM1, columnM2);
                    }
                }
            }

            return new Matrix(m1.NumberOfRows, m2.NumberOfColumns, product);
        }

        public Matrix Scalar(double scalar, Matrix m)
        {
            for(int i = 0; i < m.NumberOfRows; i++)
            {
                for(int j = 0; j < m.NumberOfColumns; j++)
                {
                    m.SetItem(i, j, m.GetItem(i, j) * scalar);
                }
            }

            return m;
        }

        public Matrix Subtract(Matrix m1, Matrix m2) => SimilarCalculus('-', m1, m2);
        public Matrix Sum(Matrix m1, Matrix m2) => SimilarCalculus('+', m1, m2);

        private Matrix SimilarCalculus(char operation, Matrix m1, Matrix m2)
        {
            if (m1.NumberOfRows != m2.NumberOfRows || m1.NumberOfColumns != m2.NumberOfColumns)
                throw new InvalidOperationException();

            Matrix newMatrix = new Matrix(m1.NumberOfRows, m2.NumberOfColumns);

            for (int i = 0; i < m1.NumberOfRows; i++)
            {
                for (int j = 0; j < m1.NumberOfColumns; j++)
                {
                    if (operation == '+')
                        newMatrix.AddItem(m1.GetItem(i, j) + m2.GetItem(i, j));
                    else if (operation == '-')
                        newMatrix.AddItem(m1.GetItem(i, j) - m2.GetItem(i, j));

                }
            }

            return newMatrix;
        }



        public Matrix Transpose(Matrix m)
        {
            Matrix transpose = new Matrix(m.NumberOfRows, m.NumberOfColumns);
            for(int i = 0; i < m.NumberOfRows; i++)
            {
                for(int j = 0; j < m.NumberOfColumns; j++)
                {
                    transpose.SetItem(j, i, m.GetItem(i, j));
                }
            }

            return transpose;
        }

        public bool AreEqual(Matrix m1, Matrix m2)
        {
            if (m1.NumberOfColumns != m2.NumberOfColumns
               || m1.NumberOfRows != m2.NumberOfRows)
                return false;

            for(int i = 0; i < m1.NumberOfRows; i++)
            {
                for(int j = 0; j < m1.NumberOfColumns; j++)
                {
                    if (m1.GetItem(i, j) != Math.Round(m2.GetItem(i, j), 2))
                        return false;
                }
            }

            return true;
        }
    }
}
