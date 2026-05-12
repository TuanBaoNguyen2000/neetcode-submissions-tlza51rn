public class Solution
{
    public bool ValidTree(int n, int[][] edges)
    {
        if (n == 0) return false;
        if (edges.Length != n - 1) return false;

        var graph = BuildGraph(n, edges);
        var visited = new HashSet<int>();

        return IsAcyclic(0, -1, graph, visited) && visited.Count == n;
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

    private bool IsAcyclic(int node, int parent, List<List<int>> graph, HashSet<int> visited)
    {
        if (!visited.Add(node))
            return false;

        foreach (int neighbor in graph[node])
        {
            if (neighbor == parent)
                continue;

            if (!IsAcyclic(neighbor, node, graph, visited))
                return false;
        }

        return true;
    }
}