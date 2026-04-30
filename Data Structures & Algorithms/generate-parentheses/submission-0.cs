public class Solution {  
    public List<string> GenerateParenthesis(int n) {
        List<string> res = new List<string>();

        void Generate(int openRemain, int closeRemain, string str)
        {
            if (openRemain == 0 && closeRemain == 0)
            {
                res.Add(str);
                return;
            }

            if (openRemain > 0) 
            {
                Generate(openRemain - 1, closeRemain, str + "(");
            }

            if (closeRemain > 0 && closeRemain > openRemain)
            {
                Generate(openRemain, closeRemain - 1, str + ")");
            }
        }

        Generate(n, n, "");
        return res;
    }
}
