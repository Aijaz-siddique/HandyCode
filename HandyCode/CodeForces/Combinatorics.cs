//Precompute factorials and inverse factorials for combinatorial calculations.

const int MAX = 1000000;
const int MOD = 1000000007;
int[] fact = new int[MAX + 1];
int[] invFact = new int[MAX + 1];

void PrecomputeFactorials() {
    fact[0] = 1;
    for (int i = 1; i <= MAX; i++) {
        fact[i] = Multiply(fact[i - 1], i);
    }
    invFact[MAX] = ModInverse(fact[MAX]);
    for (int i = MAX - 1; i >= 0; i--) {
        invFact[i] = Multiply(invFact[i + 1], i + 1);
    }
}

int Combination(int n, int k) {
    if (k > n) return 0;
    return Multiply(fact[n], Multiply(invFact[k], invFact[n - k]));
}
