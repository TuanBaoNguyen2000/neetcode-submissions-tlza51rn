public class Solution {
    public int Rob(int[] nums) {
        Dictionary<int, int> memo = new Dictionary<int, int>();

        int DFS(int index)
        {
            if (index >= nums.Length)
                return 0;

            if (memo.ContainsKey(index))
                return memo[index];

            int robCurrent = nums[index] + DFS(index + 2);
            int skipCurrent = DFS(index + 1);

            memo[index] = Math.Max(robCurrent, skipCurrent);
            return memo[index];
        }

        return DFS(0);
    }
}