using MatrixCalculator.Models;

namespace MatrixCalculator.Contracts
{
    public interface IMatrixCalculator
    {
        Matrix Cofactor(Matrix m);
        Matrix Inverse(Matrix m);
        Matrix CofactorElement(int i, int j, Matrix m);
        double Determinant(Matrix matrix);
        Matrix Transpose(Matrix m);
        Matrix Subtract(Matrix m1, Matrix m2);
        Matrix Sum(Matrix m1, Matrix m2);
        Matrix Product(Matrix m1, Matrix m2);
        Matrix Scalar(double scalar, Matrix m);
        Matrix Adjuntage(Matrix m);
    }
}
