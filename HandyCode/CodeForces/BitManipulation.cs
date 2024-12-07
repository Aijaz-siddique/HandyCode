// Check if a number is a power of two
bool IsPowerOfTwo(int x) {
    return (x & (x - 1)) == 0;
}

// Count the number of set bits in an integer
int CountSetBits(int x) {
    int count = 0;
    while (x > 0) {
        count += x & 1;
        x >>= 1;
    }
    return count;
}

// Generate all subsets of a set
void GenerateSubsets(int[] set) {
    int n = set.Length;
    for (int mask = 0; mask < (1 << n); mask++) {
        List<int> subset = new List<int>();
        for (int i = 0; i < n; i++) {
            if ((mask & (1 << i)) != 0) {
                subset.Add(set[i]);
            }
        }
        Console.WriteLine(string.Join(", ", subset));
    }
}
