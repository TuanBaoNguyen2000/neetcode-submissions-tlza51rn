public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        foreach (char t in tasks) {
            count[t - 'A']++;
        }

        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();
        foreach (int c in count) {
            if (c > 0) maxHeap.Enqueue(c, -c);
        }

        int time = 0;
        Queue<(int remaining, int readyTime)> cooldown = new();

        while (maxHeap.Count > 0 || cooldown.Count > 0) {

            while (cooldown.Count > 0 && cooldown.Peek().readyTime <= time) {
                var task = cooldown.Dequeue();
                maxHeap.Enqueue(task.remaining, -task.remaining);
            }

            if (maxHeap.Count > 0) {
                int remaining = maxHeap.Dequeue() - 1;

                if (remaining > 0) {
                    cooldown.Enqueue((remaining, time + n + 1));
                }
            }

            time++;
        }

        return time;
    }
}