public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        int[] indegree = new int[numCourses];
        List<List<int>> adj = new List<List<int>>();

        for (int i = 0; i < numCourses; i++)
        {
            adj.Add(new List<int>());
        }

        foreach (var pre in prerequisites)
        {
            indegree[pre[0]]++;
            adj[pre[1]].Add(pre[0]);
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0) queue.Enqueue(i);
        }

        int finish = 0;
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            finish++;
            foreach (int nei in adj[node])
            {
                indegree[nei]--;
                if (indegree[nei] == 0)
                    queue.Enqueue(nei);
            }
        }

        return finish == numCourses;
    }
}
