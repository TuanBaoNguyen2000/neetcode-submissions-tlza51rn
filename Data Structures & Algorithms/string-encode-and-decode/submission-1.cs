public class Solution {

    public string Encode(IList<string> strs) {
        string result = "";
        foreach(string str in strs)
            result += str.Length + "#" + str;
        
        return result;
    }

    public List<string> Decode(string s) {
        List<string> result = new List<string>();

        int i = 0;
        while (i < s.Length)
        {
            int j = i;
            while (s[j] != '#') {
                j++;
            }
            
            int length = int.Parse(s.Substring(i, j - i));
            int start = j + 1;
            result.Add(s.Substring(start, length));
            i = j + length + 1;
        }

        return result;
   }
}
