//Z-Algorithm is used for pattern matching and finding the longest common prefix.

//C#

int[] ZAlgorithm(string s) {
    int n = s.Length;
    int[] Z = new int[n];
    int L = 0, R = 0;
    for (int i = 1; i < n; i++) {
        if (i > R) {
            L = R = i;
            while (R < n && s[R] == s[R - L]) R++;
            Z[i] = R - L;
            R--;
        } else {
            int k = i - L;
            if (Z[k] < R - i + 1) {
                Z[i] = Z[k];
            } else {
                L = i;
                while (R < n && s[R] == s[R - L]) R++;
                Z[i] = R - L;
                R--;
            }
        }
    }
    return Z;
}
