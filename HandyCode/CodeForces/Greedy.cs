//Useful for optimization problems where local choices lead to a global optimum.

// Activity Selection Problem
int ActivitySelection(int[] start, int[] end) {
    int n = start.Length;
    List<(int, int)> activities = new List<(int, int)>();
    for (int i = 0; i < n; i++) {
        activities.Add((end[i], start[i]));
    }
    activities.Sort();
    int count = 1;
    int lastEndTime = activities[0].Item1;
    for (int i = 1; i < n; i++) {
        if (activities[i].Item2 >= lastEndTime) {
            count++;
            lastEndTime = activities[i].Item1;
        }
    }
    return count;
}
