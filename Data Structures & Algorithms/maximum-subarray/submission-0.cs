public class Solution {
    public int MaxSubArray(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;

        int max = nums[0];
        int curSum = 0;

        foreach(int num in nums)
        {
            if (curSum < 0)
                curSum = 0;
            
            curSum += num;
            max = Math.Max(max, curSum);
        }

        return max;
    }
}
