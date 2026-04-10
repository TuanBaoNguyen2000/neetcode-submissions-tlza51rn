public class Solution {
    public int MaxProfit(int[] prices) {
        int max = 0;
        int l = 0;
        int r = 1;
        
        while (r < prices.Length)
        {
            if (prices[r] >= prices[l])
            {
                max = Math.Max(max, prices[r] - prices[l]);
                r++;
            }
            else
            {
                l = r;
                r++;
            }
        }

        return max;
    }
}
