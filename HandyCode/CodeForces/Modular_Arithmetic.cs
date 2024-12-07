//Commonly used in problems involving large numbers and modular constraints.

const int MOD = 1000000007;

int Add(int a, int b) {
    return (a + b) % MOD;
}

int Subtract(int a, int b) {
    return (a - b + MOD) % MOD;
}

int Multiply(int a, int b) {
    return (int)((long)a * b % MOD);
}

int Power(int base, int exp) {
    int result = 1;
    while (exp > 0) {
        if ((exp & 1) == 1) {
            result = Multiply(result, base);
        }
        base = Multiply(base, base);
        exp >>= 1;
    }
    return result;
}

int ModInverse(int a) {
    return Power(a, MOD - 2);
}
