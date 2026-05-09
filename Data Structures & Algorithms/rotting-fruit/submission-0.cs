public class Solution {
    public int OrangesRotting(int[][] grid) {
        if (grid == null || grid.Length == 0)
            return -1;

        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<int[]> queue = new Queue<int[]>();
        int freshFruits = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 1) freshFruits++;
                if (grid[r][c] == 2) queue.Enqueue(new int[] {r, c});
            }
        }

        int elapsedMins = 0;

        while (queue.Count > 0 && freshFruits > 0)
        {
            elapsedMins++;

            int count = queue.Count;

            for (int i = 0; i < count; i++)
            {
                int[] cell = queue.Dequeue();
                int r = cell[0];
                int c = cell[1];

                Rotting(r + 1, c);
                Rotting(r - 1, c);
                Rotting(r, c + 1);
                Rotting(r, c - 1);
            }
        }

        return freshFruits <= 0 ? elapsedMins : -1;

        void Rotting(int r, int c)
        {
            if (r < 0 || r >= rows || c < 0 || c >= cols)
                return;

            if (grid[r][c] != 1)
                return;

            queue.Enqueue(new int[] {r, c});
            grid[r][c] = 2;
            freshFruits--;
        }
    }
}
