//Binary search is used for finding an element in a sorted array or for searching in a range.

//C#

int BinarySearch(int[] array, int target) {
    int left = 0, right = array.Length - 1;
    while (left <= right) {
        int mid = left + (right - left) / 2;
        if (array[mid] == target) {
            return mid;
        } else if (array[mid] < target) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return -1; // Target not found
}
