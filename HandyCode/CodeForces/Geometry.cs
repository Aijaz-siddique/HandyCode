// Calculate the Euclidean distance between two points
double Distance(double x1, double y1, double x2, double y2) {
    return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
}

// Check if three points are collinear
bool AreCollinear(double x1, double y1, double x2, double y2, double x3, double y3) {
    return (y2 - y1) * (x3 - x2) == (y3 - y2) * (x2 - x1);
}

// Calculate the area of a triangle given its vertices
double TriangleArea(double x1, double y1, double x2, double y2, double x3, double y3) {
    return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
}
