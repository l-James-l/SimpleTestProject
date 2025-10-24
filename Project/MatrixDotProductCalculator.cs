namespace Project;


public class MatrixDotProductCalculator
{
    public int MatrixMultiplicationCount { get; private set; } = 0;

    public int[,] CalculateDotProduct(List<int[,]> matricies)
    {
        for (int i = 0; i < matricies.Count - 1; i++)
        {
            if (matricies[i].GetLength(1) != matricies[i + 1].GetLength(0))
            {
                throw new ArgumentException("Number of columns in Matrix A must equal number of rows in Matrix B for all consecutive matricies.");
            }
        }

        int[,] factorMatrix = EvaluateMostEffcientOrder(matricies);

        return ComputeMatriciesDotProduct(matricies, factorMatrix, 0, matricies.Count-1);
    }

    private int[,] ComputeMatriciesDotProduct(List<int[,]> matricies, int[,] factorMatrix, int startIndex, int endIndex)
    {
        if (startIndex == endIndex)
        {
            return matricies[startIndex];
        }
        
        int splitIndex = factorMatrix[startIndex, endIndex];
        return CalculateDotProduct(
            ComputeMatriciesDotProduct(matricies, factorMatrix, startIndex, splitIndex),
            ComputeMatriciesDotProduct(matricies, factorMatrix, splitIndex + 1, endIndex)
        );
    }

    private int[,] EvaluateMostEffcientOrder(List<int[,]> matricies)
    {
        int[,] costsMatrix = new int[matricies.Count, matricies.Count];
        int[,] factorMatrix = new int[matricies.Count, matricies.Count];

        for (int i = 0; i < matricies.Count; i++)
        {
            costsMatrix[i, i] = 0;
        }

        for (int diagonal = 2; diagonal <= matricies.Count; diagonal++)
        {
            for (int i = 0; i <= matricies.Count - diagonal; i++)
            {
                int j = i + diagonal - 1;
                costsMatrix[i, j] = int.MaxValue;
                for (int k = i; k < j; k++)
                {
                    int cost = costsMatrix[i, k] + costsMatrix[k + 1, j] +
                               matricies[i].GetLength(0) * matricies[k].GetLength(1) * matricies[j].GetLength(1);
                    if (cost < costsMatrix[i, j])
                    {
                        costsMatrix[i, j] = cost;
                        factorMatrix[i, j] = k;
                    }
                }
            }
        }

        return factorMatrix;
    }

    public int[,] CalculateDotProduct(int[,] matrixA, int[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = matrixB.GetLength(0);
        int colsB = matrixB.GetLength(1);
        if (colsA != rowsB)
        {
            throw new ArgumentException("Number of columns in Matrix A must equal number of rows in Matrix B.");
        }
        int[,] result = new int[rowsA, colsB];
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += matrixA[i, k] * matrixB[k, j];
                    MatrixMultiplicationCount++;
                }
                result[i, j] = sum;
            }
        }
        return result;
    }
}
