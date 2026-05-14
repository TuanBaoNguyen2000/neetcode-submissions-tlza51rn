public class Solution {
    public int MinCostClimbingStairs(int[] cost) {

        Dictionary<int, int> dp = new();

        int DFS(int step)
        {
            if (step >= cost.Length)
                return 0;

            if (!dp.ContainsKey(step))
            {
                dp[step] = cost[step] + Math.Min(
                    DFS(step + 1),
                    DFS(step + 2)
                );
            }

            return dp[step];
        }

        return Math.Min(DFS(0), DFS(1));
    }
}