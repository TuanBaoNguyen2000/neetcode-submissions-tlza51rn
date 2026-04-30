public class Solution {
    public List<List<string>> Partition(string s) {

        int n = s.Length;
        bool?[,] dp = new bool?[n, n];

        List<List<string>> res = new List<List<string>>();
        List<string> part = new List<string>();
        
        bool IsPalindrome(int l, int r)
        {
            if (dp[l, r] != null)
                return dp[l, r].Value;

            int i = l, j = r;

            while (i < j)
            {
                if (s[i] != s[j])
                {
                    dp[l, r] = false;
                    return false;
                }
                i++;
                j--;
            }

            dp[l, r] = true;
            return true;
        }
        
        void DFS(int idx)
        {
            if (idx == n)
            {
                res.Add(new List<string>(part));
                return;
            }

            for (int i = idx; i < n; i++)
            {
                if (!IsPalindrome(idx, i)) continue;

                part.Add(s.Substring(idx, i - idx + 1));
                DFS(i + 1);
                part.RemoveAt(part.Count - 1);
            }
        }

        DFS(0);
        return res;
    }
}