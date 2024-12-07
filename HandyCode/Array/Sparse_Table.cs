//Useful for range minimum/maximum queries in static arrays.

//C#

class SparseTable {
    private int[,] table;
    private int[] log;

    public SparseTable(int[] array) {
        int n = array.Length;
        int logN = (int)Math.Log2(n) + 1;
        table = new int[n, logN];
        log = new int[n + 1];

        for (int i = 2; i <= n; i++) {
            log[i] = log[i / 2] + 1;
        }

        for (int i = 0; i < n; i++) {
            table[i, 0] = array[i];
        }

        for (int j = 1; j < logN; j++) {
            for (int i = 0; i + (1 << j) <= n; i++) {
                table[i, j] = Math.Min(table[i, j - 1], table[i + (1 << (j - 1)), j - 1]);
            }
        }
    }

    public int Query(int l, int r) {
        int j = log[r - l + 1];
        return Math.Min(table[l, j], table[r - (1 << j) + 1, j]);
    }
}
