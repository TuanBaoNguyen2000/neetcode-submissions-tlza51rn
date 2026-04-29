public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {

        Array.Sort(nums);
        List<List<int>> res = new List<List<int>>();
        List<int> cur = new List<int>();

        void DFS(int total, int start)
        {
            if (total == target)
            {
                res.Add(new List<int>(cur));
                return;
            }

            for (int i = start; i < nums.Length; i++) 
            {
                int num = nums[i];

                if (total + num > target) break;

                cur.Add(num);

                DFS(total + num, i);

                cur.RemoveAt(cur.Count - 1);
            }
        }

        DFS(0, 0);
        return res;
    }
}