//Ternary search is used for finding the maximum or minimum value of a unimodal function.

//C#

double TernarySearch(Func<double, double> f, double left, double right, double epsilon = 1e-9) {
    while (right - left > epsilon) {
        double mid1 = left + (right - left) / 3;
        double mid2 = right - (right - left) / 3;
        if (f(mid1) < f(mid2)) {
            left = mid1;
        } else {
            right = mid2;
        }
    }
    return (left + right) / 2;
}
