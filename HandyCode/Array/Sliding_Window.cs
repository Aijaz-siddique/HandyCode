//Useful for problems involving contiguous subarrays.

int[] array = { 1, 2, 3, 4, 5 };
int k = 3; // Window size
int windowSum = 0;

for (int i = 0; i < k; i++) {
    windowSum += array[i];
}

int maxSum = windowSum;

for (int i = k; i < array.Length; i++) {
    windowSum += array[i] - array[i - k];
    maxSum = Math.Max(maxSum, windowSum);
}

Console.WriteLine($"Maximum sum of {k}-length subarray is {maxSum}");
