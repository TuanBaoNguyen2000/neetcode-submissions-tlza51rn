public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (hand == null) return false;
        if (hand.Length % groupSize != 0) return false;

        var count = new Dictionary<int, int>();
        foreach (var num in hand) {
            count[num] = count.GetValueOrDefault(num, 0) + 1;
        }
        
        Array.Sort(hand);
        foreach (var num in hand)
        {
            if (count[num] == 0) continue;

            for (int i = 0; i < groupSize; i++)
            {
                int need = num + i;

                if (!count.ContainsKey(need) || count[need] == 0)
                    return false;

                count[need]--;
            }
        }

        return true;
    }
}
