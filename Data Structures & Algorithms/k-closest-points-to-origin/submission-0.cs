public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var maxHeap = new PriorityQueue<int[], int>(
            Comparer<int>.Create((a, b) => b - a)
        );

        foreach (var point in points) {
            int dist = point[0] * point[0] + point[1] * point[1];

            maxHeap.Enqueue(point, dist);

            if (maxHeap.Count > k)
                maxHeap.Dequeue(); // remove farthest
        }

        int[][] res = new int[k][];
        for (int i = 0; i < k; i++) {
            res[i] = maxHeap.Dequeue();
        }

        return res;
    }
}