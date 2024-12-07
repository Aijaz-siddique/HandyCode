//Useful for problems involving subarrays or subsequences.
int[] array = {1, 2, 3, 4, 5};
int targetSum = 9;
int left = 0, right = 0, currentSum = 0;

while (right < array.Length) {
    currentSum += array[right];
    while (currentSum > targetSum && left <= right) {
        currentSum -= array[left];
        left++;
    }
    if (currentSum == targetSum) {
        Console.WriteLine($"Subarray found from index {left} to {right}");
    }
    right++;
}
