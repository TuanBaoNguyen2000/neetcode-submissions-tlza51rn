public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;

        // key = (currentIndex, previousIndex)
        Dictionary<(int, int), int> memo = new();

        int DFS(int idx, int prevIdx)
        {
            if (idx == n)
                return 0;

            if (memo.ContainsKey((idx, prevIdx)))
                return memo[(idx, prevIdx)];

            // option 1: skip current
            int skip = DFS(idx + 1, prevIdx);

            // option 2: take current
            int take = 0;
            if (prevIdx == -1 || nums[idx] > nums[prevIdx])
                take = 1 + DFS(idx + 1, idx);

            int result = Math.Max(skip, take);
            memo[(idx, prevIdx)] = result;
            return result;
        }

        return DFS(0, -1);
    }
}