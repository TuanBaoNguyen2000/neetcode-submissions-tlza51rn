public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            int m = l + (r - l) / 2;

            if (nums[m] == target)
                return m;

            // left sorted
            if (nums[l] <= nums[m])
            {
                if (nums[l] <= target && target < nums[m])
                    r = m - 1;
                else
                    l = m + 1;
            }
            else
            {
                // right sorted
                if (nums[m] < target && target <= nums[r])
                    l = m + 1;
                else
                    r = m - 1;
            }
        }

        return -1;
    }
}