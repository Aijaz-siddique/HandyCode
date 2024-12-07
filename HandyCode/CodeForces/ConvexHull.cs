//Useful for problems involving the smallest convex polygon that can enclose a set of points.

class Point {
    public int X, Y;
    public Point(int x, int y) {
        X = x;
        Y = y;
    }
}

int CrossProduct(Point O, Point A, Point B) {
    return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
}

List<Point> ConvexHull(List<Point> points) {
    points.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));
    List<Point> hull = new List<Point>();
    foreach (var p in points) {
        while (hull.Count >= 2 && CrossProduct(hull[hull.Count - 2], hull[hull.Count - 1], p) <= 0) {
            hull.RemoveAt(hull.Count - 1);
        }
        hull.Add(p);
    }
    int t = hull.Count + 1;
    for (int i = points.Count - 1; i >= 0; i--) {
        Point p = points[i];
        while (hull.Count >= t && CrossProduct(hull[hull.Count - 2], hull[hull.Count - 1], p) <= 0) {
            hull.RemoveAt(hull.Count - 1);
        }
        hull.Add(p);
    }
    hull.RemoveAt(hull.Count - 1);
    return hull;
}
