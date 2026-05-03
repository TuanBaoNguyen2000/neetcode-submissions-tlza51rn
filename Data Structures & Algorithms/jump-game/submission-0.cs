public class Solution {
    public bool CanJump(int[] nums) {
        int maxReach = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (maxReach < i) return false;
            
            maxReach = Math.Max(maxReach, i + nums[i]);
        }

        return maxReach >= nums.Length - 1;
    }
}
