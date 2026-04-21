public class Solution {
    public int LastStoneWeight(int[] stones) {
        if (stones == null || stones.Length == 0) return 0;

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach(var stone in stones) {
            minHeap.Enqueue(stone, -stone); // max heap
        }

        while (minHeap.Count > 1) {
            int stone1 = minHeap.Dequeue();
            int stone2 = minHeap.Dequeue();
            int stone = Math.Abs(stone1 - stone2);

            if (stone > 0) 
                minHeap.Enqueue(stone, -stone);
        }

        return minHeap.Count == 0 ? 0 : minHeap.Peek();
    }
}