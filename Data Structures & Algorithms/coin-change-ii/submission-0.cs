public class Solution {
    public int Change(int amount, int[] coins) {
       int[] dp = new int[amount + 1]; 
       dp[0] = 1;
       
       for (int i = coins.Length - 1; i >= 0; i--)
       {
            int[] newDP = new int[amount + 1];
            newDP[0] = 1;

            for (int j = 1; j <= amount; j++)
            {
                newDP[j] = dp[j];
                if (j - coins[i] >= 0)
                {
                    newDP[j] += newDP[j - coins[i]];
                }
            }
            dp = newDP;
       }

       return dp[amount];
    }
}
