public class Solution {
    public int MaxProduct(int[] nums) {
        int res = nums[0];
        int curMin = 1, curMax = 1;

        foreach (int n in nums)
        {
            int prevMin = curMin;
            int prevMax = curMax;

            curMin = Math.Min(Math.Min(n * prevMax, n * prevMin), n);
            curMax = Math.Max(Math.Max(n * prevMax, n * prevMin), n);
            res = Math.Max(res, curMax);
        }

        return res;
    }
}
