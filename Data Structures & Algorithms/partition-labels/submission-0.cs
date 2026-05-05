public class Solution {
    public List<int> PartitionLabels(string s) {
        var res = new List<int>();
        if (s == null || s.Length == 0) return new List<int>();

        int[] last = new int[26];
        for (int i = 0; i < s.Length; i++) 
        {
            last[s[i] - 'a'] = i;
        }

        int start = 0;
        int end = 0;

        for (int i = 0; i < s.Length; i++) 
        {
            end = Math.Max(end, last[s[i] - 'a']);

            if (i == end) {
                res.Add(end - start + 1);
                start = i + 1;
            }
        }

        return res;
    }
}
