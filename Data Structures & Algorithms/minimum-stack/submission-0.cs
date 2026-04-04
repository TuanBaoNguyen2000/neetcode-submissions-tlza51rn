public class MinStack {

    Stack<int> stack;
    Stack<int> minStack;

    public MinStack() {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }
    
    public void Push(int val) {
        if (minStack.Count == 0 || val <= minStack.Peek())
            minStack.Push(val);

        stack.Push(val);
    }
    
    public void Pop() {
        if (stack.Count == 0) throw new InvalidOperationException();

        if (stack.Peek() == minStack.Peek())
            minStack.Pop();
        stack.Pop();
    }
    
    public int Top() {
        if (stack.Count == 0) throw new InvalidOperationException();
        return stack.Peek();
    }
    
    public int GetMin() {
        if (stack.Count == 0) throw new InvalidOperationException();
        return minStack.Peek();
    }
}
