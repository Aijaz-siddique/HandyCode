public class NumArray {

    int[] _segmentTree;
    int _n;
    public NumArray(int[] nums) {
        _n = nums.Length;
        _segmentTree = new int[4*_n];

        //(rootNodeIndex, leftBoundary, rightBoundary, nums)
        BuildSegmentTree(0, 0, _n-1, nums);
    }
    
    private void BuildSegmentTree(int i, int l, int r, int[] nums){

        //leaf node
        if(l == r){
            _segmentTree[i] = nums[l];
            return;
        }

        int mid = l +((r-l)>>1);
        BuildSegmentTree(2*i+1, l, mid, nums);
        BuildSegmentTree(2*i+2, mid+1, r, nums);
        _segmentTree[i] = _segmentTree[2*i+1] + _segmentTree[2*i+2];

    }
    
    public void Update(int index, int val) {
        UpdateSegmentTree(index, val, 0, 0, _n-1);
    }

    private void UpdateSegmentTree(int Idx, int val, int i, int l, int r){

        if(l == r){
            _segmentTree[i] = val;
            return;
        }

        int mid = l+((r-l)>>1);
        //Go to left child
        if(Idx <= mid){
            UpdateSegmentTree(Idx, val, 2*i+1, l, mid);
        }else{ //Go to right child
            UpdateSegmentTree(Idx, val, 2*i+2, mid+1, r);
        }
        _segmentTree[i] = _segmentTree[2*i+1] + _segmentTree[2*i+2];
    }
    
    public int SumRange(int left, int right) {
        return QuerySegmentTree(left, right, 0, 0, _n-1);
    }

    private int QuerySegmentTree(int left, int right, int i, int start, int end){
        //No overlapping
        if(start > right || end < left){
            return 0;
        }

        //total overlap
        if(start >= left && end <= right){
            return _segmentTree[i];
        }

        //Partial Overlap
        int mid = start+((end-start) >> 1);
        return QuerySegmentTree(left, right, 2*i+1, start, mid) + QuerySegmentTree(left, right, 2*i+2, mid+1, end);
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */
