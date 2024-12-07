// KMP Algorithm
int[] ComputeLPSArray(string pattern) {
    int length = 0;
    int i = 1;
    int[] lps = new int[pattern.Length];
    lps[0] = 0;
    while (i < pattern.Length) {
        if (pattern[i] == pattern[length]) {
            length++;
            lps[i] = length;
            i++;
        } else {
            if (length != 0) {
                length = lps[length - 1];
            } else {
                lps[i] = 0;
                i++;
            }
        }
    }
    return lps;
}

void KMPSearch(string text, string pattern) {
    int[] lps = ComputeLPSArray(pattern);
    int i = 0, j = 0;
    while (i < text.Length) {
        if (pattern[j] == text[i]) {
            i++;
            j++;
        }
        if (j == pattern.Length) {
            Console.WriteLine("Found pattern at index " + (i - j));
            j = lps[j - 1];
        } else if (i < text.Length && pattern[j] != text[i]) {
            if (j != 0) {
                j = lps[j - 1];
            } else {
                i++;
            }
        }
    }
}
