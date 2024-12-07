//Fenwick Trees are used for efficient prefix sum queries and updates.
class FenwickTree {
    private int[] tree;

    public FenwickTree(int size) {
        tree = new int[size + 1];
    }

    public void Update(int index, int delta) {
        for (int i = index; i < tree.Length; i += i & -i) {
            tree[i] += delta;
        }
    }

    public int Query(int index) {
        int sum = 0;
        for (int i = index; i > 0; i -= i & -i) {
            sum += tree[i];
        }
        return sum;
    }
}
