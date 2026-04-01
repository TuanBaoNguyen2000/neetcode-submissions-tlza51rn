public class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums.Length == 0) return 0;

        var set = new HashSet<int>(nums);
        int max = 0;

        foreach (var num in set) {
            if (set.Contains(num - 1)) continue;

            int current = num;
            int length = 1;

            while (set.Contains(++current)) {
                length++;
            }

            max = Math.Max(max, length);
        }

        return max;
    }
}