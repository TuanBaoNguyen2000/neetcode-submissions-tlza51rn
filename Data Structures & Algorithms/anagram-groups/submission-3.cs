public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {

        Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

        foreach(string s in strs)
        {
            char[] charArray = s.ToCharArray();
            Array.Sort(charArray);
            string sortedS = new string(charArray);
            if(!result.ContainsKey(sortedS))
                result[sortedS] = new List<string>();
            
            result[sortedS].Add(s);
        }

        return result.Values.ToList<List<string>>();
    }
}
