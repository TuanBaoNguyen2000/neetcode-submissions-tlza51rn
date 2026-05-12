public class Solution
{
    public int CountComponents(int n, int[][] edges)
    {
        if (n == 0) return 0;

        var graph = BuildGraph(n, edges);
        var visited = new HashSet<int>();
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            if (visited.Contains(i)) continue;

            DFS(i, graph, visited);
            count++;
        }

        return count;
    }

    private void DFS(int node, List<List<int>> graph, HashSet<int> visited)
    {
        if (!visited.Add(node)) return;

        foreach (int neighbor in graph[node])
        {
            DFS(neighbor, graph, visited);
        }
    }

    private List<List<int>> BuildGraph(int n, int[][] edges)
    {
        var graph = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            graph.Add(new List<int>());
        }

        foreach (var edge in edges)
        {
            int a = edge[0];
            int b = edge[1];

            graph[a].Add(b);
            graph[b].Add(a);
        }

        return graph;
    }
}