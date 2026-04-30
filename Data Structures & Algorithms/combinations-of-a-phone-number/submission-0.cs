public class Solution {
    public List<string> LetterCombinations(string digits) {

        if (digits == null || digits.Length == 0) 
            return new List<string>();

        Dictionary<char, string> map = new Dictionary<char, string>
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" }
        };

        List<string> res = new List<string>();
        DFS(0, "");
        return res;

        void DFS(int idx, string str)
        {
            if (str.Length == digits.Length)
            {
                res.Add(str);
                return;
            }

            char digit = digits[idx];
            if (map.TryGetValue(digit, out string characters))
            {
                foreach(char c in characters)
                {
                    DFS(idx + 1, str + c);
                }
            }
        }
    }
}
