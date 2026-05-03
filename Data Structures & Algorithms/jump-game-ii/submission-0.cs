public class Solution {
    public int Jump(int[] nums) {
        if (nums.Length <= 1) return 0;

        int jumps = 0;
        int currentJumpEnd = 0;
        int farthest = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);

            if (i == currentJumpEnd) {
                jumps++; 
                currentJumpEnd = farthest; 
            }

            if (currentJumpEnd >= nums.Length - 1) break;
        }

        return jumps;
    }
}
