public class Solution {
    public int MaxArea(int[] heights) {
        int maxS = 0;
        int i = 0;
        int j = heights.Length - 1;
        while (i < j)
        {
            int s = (j - i) * Math.Min(heights[i], heights[j]);
            if (s > maxS) maxS = s;
            if (heights[i] > heights[j])
                j--;
            else
                i++;
        }

        return maxS;
    }
}
