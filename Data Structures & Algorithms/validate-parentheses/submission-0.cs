public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();

        if (string.IsNullOrEmpty(s)) return false;

        for(int i = 0; i < s.Length; i++)
        {
            if (IsOpenBracket(s[i]))
            {
                stack.Push(s[i]);
            } 
            else
            {
                if (stack.Count == 0) return false;

                if (IsRightCloseBracket(stack.Peek(), s[i]))
                    stack.Pop();
                else 
                    return false;
            }
        }

        return stack.Count == 0;
    }

    public bool IsOpenBracket(char c) => c == '[' || c == '{' || c == '(';

    public bool IsRightCloseBracket(char open, char close)
    {
        switch (open)
        {
            case '[': return close == ']';
            case '{': return close == '}';
            case '(': return close == ')';
            default: 
                return false;  
        }
    }
}
