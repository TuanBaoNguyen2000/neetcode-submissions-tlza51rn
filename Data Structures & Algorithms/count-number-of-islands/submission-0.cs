public class Solution {

    int[][] directions = new int[][]
    {
        new int[] {0, 1},
        new int[] {1, 0},
        new int[] {0, -1},
        new int[] {-1, 0},
    };

    public int NumIslands(char[][] grid) {

        if (grid == null || grid.Length == 0) return 0;

        int count = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '0') continue;

                count++;
                DFS(r, c);
            }
        }

        return count;

        void DFS(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
                return;

            if (grid[row][col] == '0') return;

            grid[row][col] = '0';

            foreach (var d in directions)
            {
                DFS(row + d[0], col + d[1]);
            }
        }
    }
}