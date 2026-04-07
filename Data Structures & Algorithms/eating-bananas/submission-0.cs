public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int l = 1;
        int r = piles.Max();
        int res = r;

        while (l <= r)
        {
            int k = l + (r - l) / 2;

            long totalTime = 0;
            foreach(var p in piles){
                totalTime += (int)Math.Ceiling((double)p / k);
            }

            if (totalTime > h)
                l = k + 1;
            else
            {
                res = k;
                r = k - 1;
            }
        }

        return res;
    }
}
