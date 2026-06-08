public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        int n = nums.Length;
        Dictionary<int, int> dp = new Dictionary<int, int>();
        dp[0] = 1;

        for (int i = 0; i < n; i++)
        {
            Dictionary<int, int> nextDP = new Dictionary<int, int>();

            foreach (var entry in dp)
            {
                int total = entry.Key;
                int count = entry.Value;
                
                if (!nextDP.ContainsKey(total + nums[i]))
                {
                    nextDP[total + nums[i]] = 0;
                }
                nextDP[total + nums[i]] += count;

                if (!nextDP.ContainsKey(total - nums[i]))
                {
                    nextDP[total - nums[i]] = 0;
                }
                nextDP[total - nums[i]] += count;
            }
            dp = nextDP;
        }

        return dp.ContainsKey(target) ? dp[target] : 0;
    }
}
