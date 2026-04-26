public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length == 0) return [];

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var merged = new List<int[]>();
        int[] current = intervals[0];

        for (int i = 1; i < intervals.Length; i++) {
            if (intervals[i][0] <= current[1]) {
                current[1] = Math.Max(current[1], intervals[i][1]);
            } else {
                merged.Add(current);
                current = intervals[i];
            }
        }

        merged.Add(current);
        return merged.ToArray();
    }
}
