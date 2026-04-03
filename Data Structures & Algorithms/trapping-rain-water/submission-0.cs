public class Solution {
    public int Trap(int[] height) {
        if (height == null || height.Length == 0)
            return 0;
        
        int l = 0;
        int r = height.Length - 1;
        int maxL = height[l];
        int maxR = height[r];
        int res = 0;

        while (l < r)
        {
            if (maxL <= maxR)
            {
                if (height[l] < maxL) res += maxL - height[l];
                l++;
                maxL = Math.Max(maxL, height[l]);
            }
            else
            {
                if (height[r] < maxR) res += maxR - height[r];
                r--;
                maxR = Math.Max(maxR, height[r]);
            }

        }

        return res;
    }
}
