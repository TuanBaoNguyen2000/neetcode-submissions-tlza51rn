public class Solution {
    public int ClimbStairs(int n) {     
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        int DFS(int steps)
        {
            if (steps > n) return 0;
            if (steps == n) return 1;

            if (!map.ContainsKey(steps))
                map[steps] = DFS(steps + 1) + DFS(steps + 2);

            return map[steps];
        }

        return DFS(0);
    }

}
