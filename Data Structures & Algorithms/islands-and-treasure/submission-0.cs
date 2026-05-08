public class Solution {
    public void islandsAndTreasure(int[][] grid) {

        if (grid == null || grid.Length == 0) return;

        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<int[]> queue = new Queue<int[]>();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 0) queue.Enqueue(new int[] { r, c});
            }
        }

        int dist = 0;
        while (queue.Count > 0)
        {
            dist++;
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                int[] cell = queue.Dequeue();
                int r = cell[0];
                int c = cell[1];

                AddIsland(r + 1, c);
                AddIsland(r - 1, c);
                AddIsland(r, c + 1);
                AddIsland(r, c - 1);
            }
        }

        void AddIsland(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
                return;

            if (grid[row][col] != int.MaxValue)
                return;
            
            grid[row][col] = dist;
            queue.Enqueue(new int[] { row, col});
        }       
    }
}
