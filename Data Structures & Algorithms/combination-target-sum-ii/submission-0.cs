public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates, (a, b) => a.CompareTo(b));
        List<List<int>> res = new List<List<int>>();
        List<int> cur = new List<int>();

        void DFS(int remain, int startIdx)
        {
            if (remain == 0)
            {
                res.Add(new List<int>(cur));
                return;
            }

            for (int i = startIdx; i < candidates.Length; i++)
            {
                int candidate = candidates[i];

                if (i > startIdx && candidate == candidates[i - 1]) continue;

                if (remain - candidate < 0) break;

                cur.Add(candidate);

                DFS(remain - candidate, i + 1);

                cur.RemoveAt(cur.Count - 1);
            }
        }

        DFS(target, 0);
        return res;
    }
}
