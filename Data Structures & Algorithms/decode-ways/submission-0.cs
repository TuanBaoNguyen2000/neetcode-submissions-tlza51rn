public class Solution {
    public int NumDecodings(string s) {

        Dictionary<int, int> memo = new();

        int DFS(int idx)
        {
            if (idx == s.Length)
                return 1;

            if (s[idx] == '0')
                return 0;

            if (memo.ContainsKey(idx))
                return memo[idx];

            int count = 0;

            // 1 digit
            count += DFS(idx + 1);

            // 2 digit
            if (idx + 1 < s.Length)
            {
                int num = int.Parse(s.Substring(idx, 2));

                if (num >= 10 && num <= 26)
                {
                    count += DFS(idx + 2);
                }
            }

            memo[idx] = count;
            return count;
        }

        return DFS(0);
    }
}