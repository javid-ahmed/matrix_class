namespace MatrixCalculator;
public class Matrix
{
    public float[,] matrix;

    public Matrix(Matrix otherMatrix)
    {
        matrix = otherMatrix.matrix;
    }

    public Matrix(float[,] otherMatrix)
    {
        matrix = otherMatrix;
    }

    public Matrix(int rows, int cols, float element)
    {
        matrix = new float[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = element;
            }
        }
    }

    public Matrix(int rows, int cols, float[] elements)
    {
        if (rows * cols != elements.Length)
        {
            throw new Exception($"Number of elements must equal rows * cols! Expected: {rows * cols} elements, got {elements.Length}");
        }

        matrix = new float[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = elements[(i * cols) + (j)];
            }
        }
    }

    public static Matrix operator +(Matrix matrix, Matrix otherMatrix)
    {
        int rows = matrix.matrix.GetLength(0);
        int cols = matrix.matrix.GetLength(1);
        int otherRows = otherMatrix.matrix.GetLength(0);
        int otherCols = otherMatrix.matrix.GetLength(0);

        if (rows != otherRows && cols != otherCols)
        {
            throw new Exception($"Cannot add matrix with shape ({otherRows}, {otherCols}) to matrix with shape ({rows}, {cols})");
        }

        float[,] newMatrix = new float[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                newMatrix[i, j] = matrix.matrix[i, j] + otherMatrix.matrix[i, j];
            }
        }

        return new Matrix(newMatrix);
    }

    public static Matrix operator +(Matrix matrix, float num)
    {
        int rows = matrix.matrix.GetLength(0);
        int cols = matrix.matrix.GetLength(1);

        return matrix + new Matrix(rows, cols, num);
    }

    public static Matrix operator -(Matrix matrix, Matrix otherMatrix)
    {
        int rows = matrix.matrix.GetLength(0);
        int cols = matrix.matrix.GetLength(1);
        int otherRows = otherMatrix.matrix.GetLength(0);
        int otherCols = otherMatrix.matrix.GetLength(0);

        if (rows != otherRows && cols != otherCols)
        {
            throw new Exception($"Cannot subtract matrix with shape ({otherRows}, {otherCols}) from matrix with shape ({rows}, {cols})");
        }

        float[,] newMatrix = new float[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                newMatrix[i, j] = matrix.matrix[i, j] - otherMatrix.matrix[i, j];
            }
        }

        return new Matrix(newMatrix);
    }

    public static Matrix operator -(Matrix matrix, float num)
    {
        int rows = matrix.matrix.GetLength(0);
        int cols = matrix.matrix.GetLength(1);

        return matrix - new Matrix(rows, cols, num);
    }

    public static Matrix operator -(Matrix matrix)
    {
        int rows = matrix.matrix.GetLength(0);
        int cols = matrix.matrix.GetLength(1);

        float[,] newMatrix = new float[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                newMatrix[i, j] = -matrix.matrix[i, j];
            }
        }

        return new Matrix(newMatrix);
    }

    public static Matrix operator *(Matrix matrix, Matrix otherMatrix)
    {
        int rows = matrix.matrix.GetLength(0);
        int cols = matrix.matrix.GetLength(1);
        int otherRows = otherMatrix.matrix.GetLength(0);
        int otherCols = otherMatrix.matrix.GetLength(1);

        if (cols != otherRows)
        {
            throw new Exception($"Cannot multiply matrix with shape ({rows}, {cols}) and matrix with shape ({otherRows}, {otherCols})");
        }

        float[,] newMatrix = new float[rows, otherCols];

        for (int i1 = 0; i1 < rows; i1++)
        {
            for (int j2 = 0; j2 < otherCols; j2++)
            {
                for (int j1 = 0; j1 < cols; j1++)
                {
                    newMatrix[i1, j2] += matrix.matrix[i1, j1] * otherMatrix.matrix[j1, j2];
                }
            }
        }

        return new Matrix(newMatrix);
    }

    public static Matrix operator *(Matrix matrix, float num)
    {
        int rows = matrix.matrix.GetLength(0);
        int cols = matrix.matrix.GetLength(1);

        float[,] newMatrix = new float[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                newMatrix[i, j] = matrix.matrix[i, j] * num;
            }
        }

        return new Matrix(newMatrix);
    }

    public static Matrix operator *(float num, Matrix matrix)
    {
        return matrix * num;
    }

    public static Matrix operator /(Matrix matrix, float num)
    {
        int rows = matrix.matrix.GetLength(0);
        int cols = matrix.matrix.GetLength(1);

        float[,] newMatrix = new float[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                newMatrix[i, j] = matrix.matrix[i, j] / num;
            }
        }

        return new Matrix(newMatrix);
    }
}
