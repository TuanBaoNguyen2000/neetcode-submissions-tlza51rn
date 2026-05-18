public class Solution {
    public int CountSubstrings(string s) {
        int res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            res += CountPalindrome(s, i, i); //Odd Length
            res += CountPalindrome(s, i, i + 1); //Even Length
        }

        return res;
    }

    private int CountPalindrome(string s, int left, int right)
    {
        int count = 0;
        
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            count++;
            left--;
            right++;
        }

        return count;
    }
}
