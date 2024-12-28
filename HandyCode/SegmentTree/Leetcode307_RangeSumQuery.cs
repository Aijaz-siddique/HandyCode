public class NumArray {
    public int[] _segmentTree;
    public int _n = 1;

    public void BuildSegmentTree(int i, int l, int r, int[] arr){
        if(l == r){
            _segmentTree[i] = arr[l];
            return;
        }

        int mid = l+((r-l)/2);
        BuildSegmentTree(2*i+1, l, mid, arr);
        BuildSegmentTree(2*i+2, mid+1, r, arr);
        _segmentTree[i] = _segmentTree[2*i+1] + _segmentTree[2*i+2];

    }
  
    public void UpdateSegmentTree(int i, int l, int r,int Idx, int val){
        if(l == r){
            _segmentTree[i] = val;
            return;
        }

        int mid = l + ((r-l)/2);
        if(Idx <= mid)
            UpdateSegmentTree(2*i+1, l, mid, Idx, val);
        else
            UpdateSegmentTree(2*i+2, mid+1, r, Idx, val);

        _segmentTree[i] = _segmentTree[2*i+1] + _segmentTree[2*i+2];

    }

    public int QuerySegmentTree(int start, int end, int i, int l, int r){

        //no overlap
        if(l > end || r < start){
            return 0;
        }

        //Completely Overlap
        if(l >= start && r <= end){
            return _segmentTree[i];
        }

        int mid = l+((r-l)/2);
        //Partial Overlap
        return QuerySegmentTree( start, end, 2*i+1, l, mid)+QuerySegmentTree(  start, end, 2*i+2, mid+1, r);

    }

  /**
   * Your NumArray object will be instantiated and called as such:
   * NumArray obj = new NumArray(nums);
   * obj.Update(index,val);
   * int param_2 = obj.SumRange(left,right);
   */
    public NumArray(int[] nums) {
        
        _n = nums.Length;
        _segmentTree = new int[4*_n];
        BuildSegmentTree(0, 0, _n-1, nums);

    }

    public void Update(int index, int val) {
        UpdateSegmentTree(0, 0, _n-1, index, val);
    }
    
    public int SumRange(int left, int right) {
       return QuerySegmentTree( left, right, 0, 0, _n-1);
    }

    
    
}
