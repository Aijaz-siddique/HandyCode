//Useful for range sum queries.
  
int[] array = {1, 2, 3, 4, 5};
int[] prefixSum = new int[array.Length + 1];

for (int i = 0; i < array.Length; i++) {
    prefixSum[i + 1] = prefixSum[i] + array[i];
}

// Query sum from index l to r
int l = 1, r = 3;
int sum = prefixSum[r + 1] - prefixSum[l];
Console.WriteLine($"Sum from index {l} to {r} is {sum}");
