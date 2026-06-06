public class Solution {
    public int MaxProfit(int[] prices) {
        Dictionary<(int, bool), int> dp = new Dictionary<(int, bool), int>();

        return DFS(0, true);

        int DFS(int i, bool canBuy)
        {
            if (i >= prices.Length) return 0;

            var key = (i, canBuy);
            if (dp.ContainsKey(key))
                return dp[key];

            int cooldown = DFS(i + 1, canBuy);

            if (canBuy)
            {
                int buy = DFS(i + 1, false) - prices[i];
                dp[key] = Math.Max(buy, cooldown);
            }
            else
            {
                int sell = DFS(i + 2, true) + prices[i];
                dp[key] = Math.Max(sell, cooldown);
            }

            return dp[key];
        }
    }
}
