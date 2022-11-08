namespace MatrixCalculator.Tests;

public class MatrixTests
{
    // Create matrix given one element
    [Test]
    public void GivenOneElementWhenMatrixCreatedCheckMatrixHasEqualElements()
    {
        Matrix matrix = new Matrix(2, 2, 1);
        float[,] expected = new float[2, 2] { { 1, 1 }, { 1, 1 } };
        float[,] actual = matrix.matrix;

        Assert.That(actual, Is.EqualTo(expected));
    }

    // Create matrix given array of elements
    [Test]
    public void GivenArrayOfElementsWhenMatrixCreatedCheckMatrixCreatedCorrectly()
    {
        float[] elements = new float[4] { 1, 2, 3, 4 };
        Matrix matrix = new Matrix(2, 2, elements);
        float[,] expected = new float[2, 2] { { 1, 2 }, { 3, 4 } };
        float[,] actual = matrix.matrix;

        Assert.That(actual, Is.EqualTo(expected));
    }

    // Create matrix using another matrix
    [Test]
    public void GivenMatrixWhenMatrixCreatedCheckMatrixCreatedCorrectly()
    {
        float[] elements = new float[4] { 1, 2, 3, 4 };
        Matrix matrix1 = new Matrix(2, 2, elements);
        Matrix matrix2 = new Matrix(matrix1);
        float[,] expected = new float[2, 2] { { 1, 2 }, { 3, 4 } };
        float[,] actual = matrix2.matrix;

        Assert.That(actual, Is.EqualTo(expected));
    }

    // Raise error when given incorrect number of elements
    [Test]
    public void GivenIncompatibleArrayOfElementsWhenMatrixCreatedCheckErrorRaised()
    {
        float[] elements = new float[6] { 1, 2, 3, 4, 5, 6 };

        Assert.Throws<Exception>(() => new Matrix(2, 2, elements));
    }

    // Check addition of two matrices
    [Test]
    public void GivenTwoMatricesWhenAddingThenCheckNewMatrixCorrectlyCalculated()
    {
        Matrix matrix1 = new Matrix(2, 2, 1);
        Matrix matrix2 = new Matrix(2, 2, 2);

        float[,] expected = new float[2, 2] { { 3, 3 }, { 3, 3 } };
        float[,] actual = (matrix1 + matrix2).matrix;

        Assert.That(actual, Is.EqualTo(expected));
    }

    // Check subtraction of two matrices
    [Test]
    public void GivenTwoMatricesWhenSubtractingThenCheckNewMatrixCorrectlyCalculated()
    {
        Matrix matrix1 = new Matrix(2, 2, 3);
        Matrix matrix2 = new Matrix(2, 2, 2);

        float[,] expected = new float[2, 2] { { 1, 1 }, { 1, 1 } };
        float[,] actual = (matrix1 - matrix2).matrix;

        Assert.That(actual, Is.EqualTo(expected));
    }

    // Raise error when adding two matrices with incompatible shapes
    [Test]
    public void GivenTwoMatricesWithIncompatibleShapesWhenAddingThenCheckErrorRaised()
    {
        Matrix matrix1 = new Matrix(2, 2, 1);
        Matrix matrix2 = new Matrix(3, 3, 2);

        Assert.Throws<Exception>(() =>
        {
            Matrix newMatrix = matrix1 + matrix2;
        });
    }

    // Raise error when subtracting two matrices with incompatible shapes
    [Test]
    public void GivenTwoMatricesWithIncompatibleShapesWhenSubtractingThenCheckErrorRaised()
    {
        Matrix matrix1 = new Matrix(2, 2, 1);
        Matrix matrix2 = new Matrix(3, 3, 2);

        Assert.Throws<Exception>(() =>
        {
            Matrix newMatrix = matrix1 - matrix2;
        });
    }

    // Check addition of scalar to matrix
    [Test]
    public void GivenMatrixAndScalarWhenAddingThenCheckNewMatrixCorrectlyCalculated()
    {
        Matrix matrix = new Matrix(2, 2, 1);
        float num = 2;

        float[,] expected = new float[2, 2] { { 3, 3 }, { 3, 3 } };
        float[,] actual = (matrix + num).matrix;

        Assert.That(actual, Is.EqualTo(expected));
    }

    // Check subtraction of scalar to matrix
    [Test]
    public void GivenMatrixAndScalarWhenSubtractingThenCheckNewMatrixCorrectlyCalculated()
    {
        Matrix matrix = new Matrix(2, 2, 3);
        float num = 2;

        float[,] expected = new float[2, 2] { { 1, 1 }, { 1, 1 } };
        float[,] actual = (matrix - num).matrix;

        Assert.That(actual, Is.EqualTo(expected));
    }

    // Check flipping signs of matrix
    [Test]
    public void GivenSquareMatrixWhenFlippingSignsThenCheckNewMatrixCorrectlyCalculated()
    {
        Matrix matrix = new Matrix(2, 2, new float[4] { 1, 2, 3, 4 });

        Matrix expected = new Matrix(2, 2, new float[4] { -1, -2, -3, -4 });
        Matrix actual = -matrix;

        Assert.That(actual.matrix, Is.EqualTo(expected.matrix));
    }

    [Test]
    public void GivenMatrixWhenFlippingSignsThenCheckNewMatrixCorrectlyCalculated()
    {
        Matrix matrix = new Matrix(2, 3, new float[6] { 1, 2, 3, 4, 5, 6 });

        Matrix expected = new Matrix(2, 3, new float[6] { -1, -2, -3, -4, -5, -6 });
        Matrix actual = -matrix;

        Assert.That(actual.matrix, Is.EqualTo(expected.matrix));
    }

    // Check multiplication of matrix by scalar
    [Test]
    public void GivenMatrixAndScalarWhenMultiplyingThenCheckNewMatrixCorrectlyCalculated()
    {
        Matrix matrix = new Matrix(2, 2, new float[4] { 1, 2, 3, 4 });
        float num = 2;

        Matrix expected = new Matrix(2, 2, new float[4] { 2, 4, 6, 8 });
        Matrix actual = matrix * num;

        Assert.That(actual.matrix, Is.EqualTo(expected.matrix));
    }

    // Check multiplication of two matrices
    [Test]
    public void GivenTwoMatricesWhenMultiplyingThenCheckNewMatrixCorrectlyCalculated()
    {
        Matrix matrix1 = new Matrix(3, 2, new float[6] { 1, 2, 3, 4, 5, 6 });
        Matrix matrix2 = new Matrix(2, 3, new float[6] { 1, 2, 3, 4, 5, 6 });

        Matrix expected = new Matrix(3, 3, new float[9] { 9, 12, 15, 19, 26, 33, 29, 40, 51 });
        Matrix actual = matrix1 * matrix2;

        Assert.That(actual.matrix, Is.EqualTo(expected.matrix));
    }

    // Raise error when multiplying two matrices with incompatible shapes
    [Test]
    public void GivenTwoMatricesWithIncompatibleShapesWhenMultiplyingThenCheckErrorRaised()
    {
        Matrix matrix1 = new Matrix(2, 2, 1);
        Matrix matrix2 = new Matrix(3, 3, 2);

        Assert.Throws<Exception>(() =>
        {
            Matrix newMatrix = matrix1 * matrix2;
        });
    }

    // Check division of matrix by scalar
    [Test]
    public void GivenMatrixAndScalarWhenDividingThenCheckNewMatrixCorrectlyCalculated()
    {
        Matrix matrix = new Matrix(2, 2, new float[4] { 2, 4, 6, 8 });
        float num = 2;

        Matrix expected = new Matrix(2, 2, new float[4] { 1, 2, 3, 4 });
        Matrix actual = matrix / num;

        Assert.That(actual.matrix, Is.EqualTo(expected.matrix));
    }

    // Example case
    [Test]
    public void GivenExampleExpressionWhenCalculatingThenCheckNewMatrixCorrect()
    {
        Matrix A = new Matrix(2, 2, new float[4] { 0, 2, 3, 6 });
        Matrix B = new Matrix(2, 2, new float[4] { 1, 2, -3, 5 });
        Matrix C = new Matrix(2, 2, 1);

        Matrix expected = new Matrix(2, 2, new float[4] { -11, 21, -29, 73 });
        Matrix actual = 2 * A * B + C;

        Assert.That(actual.matrix, Is.EqualTo(expected.matrix));
    }
}