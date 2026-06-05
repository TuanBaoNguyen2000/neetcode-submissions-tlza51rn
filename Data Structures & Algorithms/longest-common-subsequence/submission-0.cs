public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        int row = text1.Length;
        int col = text2.Length;
        int[,] dp = new int[row + 1, col + 1];

        for (int i = row - 1; i >= 0; i--)
        {
            for (int j = col - 1; j >= 0; j--)
            {
                if (text1[i] == text2[j])
                {
                    dp[i, j] = 1 + dp[i + 1, j + 1];
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i, j + 1], dp[i + 1, j]);
                }
            }
        }

        return dp[0, 0];
    }
}
