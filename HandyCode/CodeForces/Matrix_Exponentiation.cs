//Useful for problems involving linear recurrences and fast computation of powers.

int[,] MultiplyMatrices(int[,] a, int[,] b, int mod) {
    int n = a.GetLength(0);
    int[,] result = new int[n, n];
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            for (int k = 0; k < n; k++) {
                result[i, j] = (result[i, j] + a[i, k] * b[k, j]) % mod;
            }
        }
    }
    return result;
}

int[,] MatrixPower(int[,] matrix, int exp, int mod) {
    int n = matrix.GetLength(0);
    int[,] result = new int[n, n];
    for (int i = 0; i < n; i++) {
        result[i, i] = 1;
    }
    while (exp > 0) {
        if ((exp & 1) == 1) {
            result = MultiplyMatrices(result, matrix, mod);
        }
        matrix = MultiplyMatrices(matrix, matrix, mod);
        exp >>= 1;
    }
    return result;
}
