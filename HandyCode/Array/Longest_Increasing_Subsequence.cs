//Finding the length of the longest increasing subsequence in an array.

//C#

int LIS(int[] array) {
    List<int> lis = new List<int>();
    foreach (var num in array) {
        int pos = lis.BinarySearch(num);
        if (pos < 0) pos = ~pos;
        if (pos == lis.Count) {
            lis.Add(num);
        } else {
            lis[pos] = num;
        }
    }
    return lis.Count;
}
