public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();

        var ops = new Dictionary<string, Func<int, int, int>>()
        {
            { "+", (a, b) => a + b },
            { "-", (a, b) => a - b },
            { "*", (a, b) => a * b },
            { "/", (a, b) => a / b }
        };

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int num))
            {
                stack.Push(num);
            }
            else
            {
                int b = stack.Pop();
                int a = stack.Pop();
                stack.Push(ops[token](a, b));
            }
        }

        return stack.Peek();
    }
}