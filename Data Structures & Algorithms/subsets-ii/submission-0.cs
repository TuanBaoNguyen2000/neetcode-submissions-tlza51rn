public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums, (a, b) => a.CompareTo(b));
        List<List<int>> res = new List<List<int>>();
        List<int> cur = new List<int>();

        void DFS(int start)
        {
            res.Add(new List<int>(cur));

            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) continue;
                
                cur.Add(nums[i]);

                DFS(i + 1);

                cur.RemoveAt(cur.Count - 1);
            }
        }

        DFS(0);
        return res;
    }
}
