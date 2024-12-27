namespace CP
{
    public class SegmentTree
    {
        public int[] _segmentTree;

        #region Segment Tree
        public void BuildSegmentTree(int i, int l, int r, int[] arr)
        {
            if(l == r) // We are at leaf node
            {
                _segmentTree[i] = arr[l]; //_segmentTree[i] = arr[r] is also valid.
                return;
            }

            int mid = l + ((r - l) >> 1);
            BuildSegmentTree(2*i+1, l, mid, arr);
            BuildSegmentTree(2*i+2, mid+1, r, arr);
            _segmentTree[i] = _segmentTree[2*i+1] + _segmentTree[2*i+2];
        }

        public void PointUpdate(int Idx, int val, int i, int l, int r)
        {
            //If leaf node, means index to update was leaf node
            if(l == r)
            {
                _segmentTree[Idx] = val; //_segmentTree[i] = val; is also valid.
            }

            int mid = l + ((r - l) >> 1);
            if(Idx <= mid) // means index is in left subtree
            {
                PointUpdate(Idx, val, 2*i+1, l, mid);
            }
            else
            {
                PointUpdate(Idx, val, 2*i+2, mid + 1, r);
            }

            _segmentTree[i] = _segmentTree[2 * i + 1] + _segmentTree[2 * i + 2];
        }

        public int QuerySegmentTree(int i, int start, int end, int l, int r)
        {
            //Out of range
            if(r < start || l > end)
            {
                return 0;
            }

            //Completely overlap
            if(l >= start && r <= end)
            {
                return _segmentTree[i];
            }

            int mid = l + ((r - l) >> 1);
            return QuerySegmentTree(2 * i + 1, start, end, l, mid) +
                   QuerySegmentTree(2 * i + 2, start, end, mid+1, r);

        }

        #endregion Segment Tree


        #region Lazy Propogation (Range Update Segment Tree)
        public void RangeUpdate(int i ,int start, int end, int l, int r, int val, int[] lazy)
        {
            if (lazy[i] != 0)
            {
                _segmentTree[i] += (r - l + 1) * lazy[i];
                if(l != r) //means we are not dealing with the leaf node
                {
                    lazy[2 * i + 1] += lazy[i];
                    lazy[2 * i + 2] += lazy[i];
                }
                lazy[i] = 0; //resetting the value of the lazy[i]. Idea was to update the lazy[i] when we revisit it.
            }

            //Out of range. Do Nothing
            if(r < start || l > end)
            {
                return;
            }

            //Completely within the range
            if(l >= start && r <= end)
            {
                _segmentTree[i] += (r - l + 1) * val;
                if(l != r)
                {
                    lazy[2 * i + 1] += val;
                    lazy[2 * i + 2] += val;
                }
                return;
            }

            //Partial Overlap
            int mid = l + ((r - l) >> 1);
            RangeUpdate(2*i+1, start, end, l, mid, val, lazy);
            RangeUpdate(2*i+1, start, end, mid+1, r, val, lazy);
            _segmentTree[i] = _segmentTree[2 * i + 1] + _segmentTree[2 * i + 2];
        }


        #endregion Lazy Propogation (Range Update Segment Tree)


        public void Solve()
        {
            int[] arr = new int[4];
            int n = arr.Length;
            _segmentTree = new int[4 * n];

            BuildSegmentTree(0, 0, n-1, arr); //BuildSegmentTree(rootIndex, leftBoundaryCoveredByRoot, rightBoundaryCoveredByRoot, arr);

        }
    }
}
