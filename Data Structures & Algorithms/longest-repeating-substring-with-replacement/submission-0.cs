public class Solution {
    public int CharacterReplacement(string s, int k) {
        Dictionary<char, int> map = new Dictionary<char, int>();

        int res = 0;
        int l = 0;
        int maxF = 0;

        for (int r = 0; r < s.Length; r++){
            if (map.ContainsKey(s[r]))
                map[s[r]]++;
            else
                map[s[r]] = 1;

            maxF = Math.Max(map[s[r]], maxF);

            while (r - l + 1 - maxF > k){
                map[s[l]]--;
                l++;
            }

            res = Math.Max(res, r - l + 1);
        }

        return res;
    }                       
}
