public class Solution {
    public int LengthOfLongestSubstring(string s) {
        Dictionary<char, int> map = new Dictionary<char, int>();

        int max = 0;
        int l = 0;
        int r = 0;
        while(r < s.Length)
        {
            if (map.TryGetValue(s[r], out int i))
            {
                l = Math.Max(l, i + 1);
            }
            
            max = Math.Max(max, r - l + 1);
            map[s[r]] = r;
            r++;
        }

        return max;
    }
}
