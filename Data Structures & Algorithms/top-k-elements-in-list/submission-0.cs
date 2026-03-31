public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> count = new Dictionary<int, int>();

        foreach(int n in nums)
            if(count.ContainsKey(n))
                count[n]++;
            else
                count[n] = 1;
        
        var heap = new PriorityQueue<int, int>();
        foreach(var kvp in count)
        {
            heap.Enqueue(kvp.Key, kvp.Value);
            if (heap.Count > k)
                heap.Dequeue();
        }

        var res = new int[k];
        for(int i = 0; i < k; i++)
            res[i] = heap.Dequeue();

        return res;
    }
}
