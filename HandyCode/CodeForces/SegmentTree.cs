//Segment trees are used for range queries and updates.

class SegmentTree {
    private int[] tree;
    private int n;

    public SegmentTree(int[] data) {
        n = data.Length;
        tree = new int[2 * n];
        Build(data);
    }

    private void Build(int[] data) {
        for (int i = 0; i < n; i++) {
            tree[n + i] = data[i];
        }
        for (int i = n - 1; i > 0; --i) {
            tree[i] = tree[i * 2] + tree[i * 2 + 1];
        }
    }

    public void Update(int pos, int value) {
        pos += n;
        tree[pos] = value;
        while (pos > 1) {
            pos /= 2;
            tree[pos] = tree[2 * pos] + tree[2 * pos + 1];
        }
    }

    public int Query(int left, int right) {
        left += n;
        right += n;
        int sum = 0;
        while (left < right) {
            if ((left & 1) == 1) sum += tree[left++];
            if ((right & 1) == 1) sum += tree[--right];
            left /= 2;
            right /= 2;
        }
        return sum;
    }
}