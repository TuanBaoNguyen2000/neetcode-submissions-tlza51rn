public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> res = new List<List<int>>();
        List<int> cur = new List<int>();

        void DFS(int start)
        {
            res.Add(new List<int>(cur)); // add ở mọi node

            for (int i = start; i < nums.Length; i++)
            {
                cur.Add(nums[i]);
                DFS(i + 1);
                cur.RemoveAt(cur.Count - 1);
            }
        }

        DFS(0);
        return res;
    }
}
