public class Solution
{
    private static readonly int[][] directions = new int[][]
    {
        new int[] {0, 1},
        new int[] {1, 0},
        new int[] {0, -1},
        new int[] {-1, 0}
    };

    public List<List<int>> PacificAtlantic(int[][] heights)
    {
        if (heights == null || heights.Length == 0)
            return new List<List<int>>();

        int rows = heights.Length;
        int cols = heights[0].Length;

        bool[][] pacific = new bool[rows][];
        bool[][] atlantic = new bool[rows][];

        for (int r = 0; r < rows; r++)
        {
            pacific[r] = new bool[cols];
            atlantic[r] = new bool[cols];
        }

        Queue<int[]> pacificQueue = new Queue<int[]>();
        Queue<int[]> atlanticQueue = new Queue<int[]>();

        // Pacific borders
        for (int r = 0; r < rows; r++)
        {
            AddCell(r, 0, pacific, pacificQueue);
        }

        for (int c = 0; c < cols; c++)
        {
            AddCell(0, c, pacific, pacificQueue);
        }

        // Atlantic borders
        for (int r = 0; r < rows; r++)
        {
            AddCell(r, cols - 1, atlantic, atlanticQueue);
        }

        for (int c = 0; c < cols; c++)
        {
            AddCell(rows - 1, c, atlantic, atlanticQueue);
        }

        BFS(pacificQueue, pacific);
        BFS(atlanticQueue, atlantic);

        List<List<int>> result = new List<List<int>>();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (pacific[r][c] && atlantic[r][c])
                {
                    result.Add(new List<int> { r, c });
                }
            }
        }

        return result;

        void BFS(Queue<int[]> queue, bool[][] visited)
        {
            while (queue.Count > 0)
            {
                int[] cell = queue.Dequeue();

                int r = cell[0];
                int c = cell[1];

                foreach (var dir in directions)
                {
                    int nr = r + dir[0];
                    int nc = c + dir[1];

                    if (!IsValid(nr, nc))
                        continue;

                    if (visited[nr][nc])
                        continue;

                    if (heights[nr][nc] < heights[r][c])
                        continue;

                    visited[nr][nc] = true;
                    queue.Enqueue(new int[] { nr, nc });
                }
            }
        }

        void AddCell(int r, int c, bool[][] visited, Queue<int[]> queue)
        {
            if (visited[r][c])
                return;

            visited[r][c] = true;
            queue.Enqueue(new int[] { r, c });
        }

        bool IsValid(int r, int c)
        {
            return r >= 0 && r < rows && c >= 0 && c < cols;
        }
    }
}