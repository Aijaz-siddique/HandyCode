//Kadane's algorithm is used for finding the maximum sum subarray in an array.

//C#

int Kadane(int[] array) {
    int maxSoFar = array[0], maxEndingHere = array[0];
    for (int i = 1; i < array.Length; i++) {
        maxEndingHere = Math.Max(array[i], maxEndingHere + array[i]);
        maxSoFar = Math.Max(maxSoFar, maxEndingHere);
    }
    return maxSoFar;
}
