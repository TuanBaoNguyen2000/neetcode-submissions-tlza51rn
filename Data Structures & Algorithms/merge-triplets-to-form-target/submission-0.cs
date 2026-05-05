public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        
        bool hasA = false;
        bool hasB = false;
        bool hasC = false;

        foreach (var t in triplets)
        {
            if (t[0] > target[0] || t[1] > target[1] || t[2] > target[2])
                continue;

            if (t[0] == target[0]) hasA = true;
            if (t[1] == target[1]) hasB = true;
            if (t[2] == target[2]) hasC = true;
        }

        return hasA && hasB && hasC;
    }
}