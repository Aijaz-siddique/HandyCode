//Useful for problems involving permutations, combinations, and other combinatorial structures.

void Permute(int[] nums, int start, List<List<int>> result) {
    if (start >= nums.Length) {
        result.Add(new List<int>(nums));
        return;
    }
    for (int i = start; i < nums.Length; i++) {
        Swap(nums, start, i);
        Permute(nums, start + 1, result);
        Swap(nums, start, i);
    }
}

void Swap(int[] nums, int i, int j) {
    int temp = nums[i];
    nums[i] = nums[j];
    nums[j] = temp;
}
