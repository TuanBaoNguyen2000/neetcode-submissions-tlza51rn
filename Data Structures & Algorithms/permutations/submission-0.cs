public class Solution {
    public List<List<int>> Permute(int[] nums) {
        List<List<int>> res = new List<List<int>>();
        List<int> cur = new List<int>();
        HashSet<int> hashSet = new HashSet<int>();

        void DFS()
        {
            if (cur.Count == nums.Length)
            {
                res.Add(new List<int>(cur));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!hashSet.Add(i)) continue;

                cur.Add(nums[i]);

                DFS();

                cur.RemoveAt(cur.Count - 1);
                hashSet.Remove(i);
            }
        }

        DFS();
        return res;
    }
}
