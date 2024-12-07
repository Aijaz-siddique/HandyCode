//Suffix array is used for efficient string matching and substring queries.

//C#

int[] BuildSuffixArray(string s) {
    int n = s.Length;
    int[] suffixArray = new int[n];
    int[] rank = new int[n];
    int[] temp = new int[n];
    for (int i = 0; i < n; i++) {
        suffixArray[i] = i;
        rank[i] = s[i];
    }
    for (int k = 1; k < n; k *= 2) {
        Array.Sort(suffixArray, (a, b) => rank[a] != rank[b] ? rank[a].CompareTo(rank[b]) : (a + k < n ? rank[a + k] : -1).CompareTo(b + k < n ? rank[b + k] : -1));
        temp[suffixArray[0]] = 0;
        for (int i = 1; i < n; i++) {
            temp[suffixArray[i]] = temp[suffixArray[i - 1]] + (rank[suffixArray[i]] != rank[suffixArray[i - 1]] || (suffixArray[i] + k < n ? rank[suffixArray[i] + k] : -1) != (suffixArray[i - 1] + k < n ? rank[suffixArray[i - 1] + k] : -1) ? 1 : 0);
        }
        Array.Copy(temp, rank, n);
    }
    return suffixArray;
}
