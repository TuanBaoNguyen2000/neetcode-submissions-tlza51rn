public class Solution 
{
    public int[] FindOrder(int numCourses, int[][] prerequisites) 
    {
        int[] indegree = new int[numCourses];
        List<List<int>> graph = new();

        for (int i = 0; i < numCourses; i++)
        {
            graph.Add(new List<int>());
        }

        foreach (var pre in prerequisites)
        {
            int course = pre[0];
            int prereq = pre[1];

            graph[prereq].Add(course);
            indegree[course]++;
        }

        Queue<int> queue = new();

        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        int[] order = new int[numCourses];
        int index = 0;

        while (queue.Count > 0)
        {
            int course = queue.Dequeue();

            order[index] = course;
            index++;

            foreach (int nextCourse in graph[course])
            {
                indegree[nextCourse]--;

                if (indegree[nextCourse] == 0)
                {
                    queue.Enqueue(nextCourse);
                }
            }
        }

        return index == numCourses
            ? order
            : Array.Empty<int>();
    }
}