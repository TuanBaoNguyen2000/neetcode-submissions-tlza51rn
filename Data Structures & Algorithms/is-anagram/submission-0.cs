public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> countS = new Dictionary<char, int>();
        Dictionary<char, int> countT = new Dictionary<char, int>();
        int n = s.Length;

        for(int i = 0; i < n; i++)
        {
            char cS = s[i];
            char cT = t[i];

            if (countS.ContainsKey(cS))
                countS[cS]++;
            else
                countS[cS] = 1;

            if (countT.ContainsKey(cT))
                countT[cT]++;
            else
                countT[cT] = 1;
        }

        foreach(var kvp in countS)
        {
            if (!countT.TryGetValue(kvp.Key, out int count) || count != kvp.Value)
                return false;
        }

        return true;
    }
}