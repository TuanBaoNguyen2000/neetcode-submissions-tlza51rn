public class Solution 
{
    public bool CanPartition(int[] nums) 
    {
        int sum = nums.Sum();

        if (sum % 2 != 0)
            return false;

        int target = sum / 2;

        bool[] dp = new bool[target + 1];

        dp[0] = true;

        foreach (int num in nums)
        {
            for (int s = target; s >= num; s--)
            {
                dp[s] = dp[s] || dp[s - num];
            }
        }

        return dp[target];
    }
}