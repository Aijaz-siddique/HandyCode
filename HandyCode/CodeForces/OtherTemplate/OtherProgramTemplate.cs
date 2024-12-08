using System.Globalization;
using System.Text;
using static System.Double;
 
 
TextReader reader = new StreamReader(Console.OpenStandardInput());
TextWriter writer = Console.Out;
 
 
void Solve()
{
	var nk = ReadIntArray();
	var k = nk[1];
	var participants = ReadIntArray();
	var border = Math.Max(participants[k - 1], 1);
	var ans = participants.Count(x => x >= border);
	Write(ans);
}
 
#region Read / Write
Queue<string> currentLineTokens = new Queue<string>();
string[] ReadAndSplitLine() => reader.ReadLine().Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries);
string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
int ReadInt() => int.Parse(ReadToken());
long ReadLong() => long.Parse(ReadToken());
double ReadDouble() => Parse(ReadToken(), CultureInfo.InvariantCulture);
int[] ReadIntArray() => ReadAndSplitLine().Select(int.Parse).ToArray();
long[] ReadLongArray() => ReadAndSplitLine().Select(long.Parse).ToArray();
double[] ReadDoubleArray() => ReadAndSplitLine().Select(s => Parse(s, CultureInfo.InvariantCulture)).ToArray();
decimal[] ReadDecimalArray() => ReadAndSplitLine().Select(s => decimal.Parse(s, CultureInfo.InvariantCulture)).ToArray();
int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }
int[][] ReadAndTransposeIntMatrix(int numberOfRows)
{
	int[][] matrix = ReadIntMatrix(numberOfRows); int[][] ret = new int[matrix[0].Length][];
	for (int i = 0; i < ret.Length; i++) { ret[i] = new int[numberOfRows]; for (int j = 0; j < numberOfRows; j++) ret[i][j] = matrix[j][i]; }
	return ret;
}
string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }
void WriteArray<T>(IEnumerable<T> array) { writer.WriteLine(string.Join(" ", array)); }
void Write(params object[] array) { WriteArray(array); }
void WriteLines<T>(IEnumerable<T> array) { foreach (var a in array) writer.WriteLine(a); }
T[] Init<T>(int size) where T : new() { var ret = new T[size]; for (int i = 0; i < size; i++) ret[i] = new T(); return ret; }
#endregion
 
Solve();
 
// reader = new StreamReader("input.txt");
// writer = new StreamWriter("output.txt");
 
#region Alg
 
 
long GCD(long a, long b)
{
	return b == 0 ? a : GCD(b, a % b);
}
 
int Power(int x, int y, int p)
{
	int res = 1; x = x % p;
	if (x == 0) return 0;
	while (y > 0) { if ((y & 1) != 0) res = (res * x) % p; y = y >> 1; x = (x * x) % p; }
	return res;
}
 
long LCM(long a, long b) { return a / GCD(a, b) * b; }
 
#endregion
 
#region Treap
 
public class Treap<T>
where T : IComparable<T>
{
	public Treap<T>? Left { get; set; }
	public Treap<T>? Right { get; set; }
 
	//public long Value { get; set; }
	public T Key { get; set; }
	public long Priority { get; set; }
	
	public static Treap<T> Create(T key)
	{
        Treap<T> tree = new()
        {
            Key = key,
            Priority = TreapRandom.NextInt64(),
            Right = null,
            Left = null
        };
 
        return tree;
	}
 
	public static Treap<T>? Insert(Treap<T> tree, T key)
	{
		var (lower, higher) = Split(tree, key);
		var toInsert = Create(key);
 
		lower = Merge(lower, toInsert);
		return Merge(lower, higher);
	}
	
	public static Treap<T>? Erase(Treap<T>? tree, T key)
	{
		if (tree == null) return tree;
 
		var compareResult = tree.Key.CompareTo(key);
		
		switch (compareResult)
		{
			case 0:
				return Merge(tree.Left, tree.Right);
			case < 0:
				tree.Right = Erase(tree.Right, key);
				break;
			default:
				tree.Left = Erase(tree.Left, key);
				break;
		}
 
		return tree;
	}
 
	public static Treap<T>? Merge(Treap<T>? lowerKeyTree, Treap<T>? higherKeyTree)
	{
		if (lowerKeyTree == null) return higherKeyTree;
		if (higherKeyTree == null) return lowerKeyTree;
 
		if (lowerKeyTree.Priority > higherKeyTree.Priority)
		{
			lowerKeyTree.Right = Merge(lowerKeyTree.Right, higherKeyTree);
			return lowerKeyTree;
		}
 
		higherKeyTree.Left = Merge(lowerKeyTree, higherKeyTree.Left);
		
		return higherKeyTree;
	}
	
	public static (Treap<T>? lowerThanKeyTree, Treap<T>? higherThanKeyTree) Split(Treap<T>? tree, T keyToSplit) // key would be in right part
	{
		if (tree == null) return (null, null);
 
		var compareResult = tree.Key.CompareTo(keyToSplit);
		
		if (compareResult < 0)
		{
			var (lowerThanKeyTree, higherThanKeyTree) = Split(tree.Right, keyToSplit);
			tree.Right = lowerThanKeyTree;
			
			return (tree, higherThanKeyTree);
		}
		else
		{
			var (lowerThanKeyTree, higherThanKeyTree) = Split(tree.Left, keyToSplit);
			tree.Left = higherThanKeyTree;
 
			return (lowerThanKeyTree, tree);
		}
	}
 
	public void GetString(StringBuilder sb)
	{
		Left?.GetString(sb);
		sb.Append($"{Key} ");
		Right?.GetString(sb);
	}
 
	private static readonly Random TreapRandom = new(53465789);
}

#endregion
