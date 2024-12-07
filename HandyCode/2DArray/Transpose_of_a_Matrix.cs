int[,] Transpose(int[,] array)
{
    int rows = array.GetLength(0);
    int cols = array.GetLength(1);
    int[,] transposed = new int[cols, rows];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            transposed[j, i] = array[i, j];
        }
    }
    return transposed;
}
