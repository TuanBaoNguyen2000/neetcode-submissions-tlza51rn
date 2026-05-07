public class Solution {

    int[][] directions = new int[][]
    {
        new int[] {0, 1},
        new int[] {1, 0},
        new int[] {0, -1},
        new int[] {-1, 0},
    };

    public int MaxAreaOfIsland(int[][] grid) {
        if (grid == null || grid.Length == 0) return 0;

        int rows = grid.Length;
        int cols = grid[0].Length;
        int maxArea = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 0) continue;

                maxArea = Math.Max(maxArea, DFS(r, c));
            }
        }

        return maxArea;
        
        int DFS(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
                return 0;

            if (grid[row][col] == 0)
                return 0;

            grid[row][col] = 0;
            
            int area = 1;

            foreach (var d in directions)
            {
                int nr = row + d[0];
                int nc = col + d[1];

                area += DFS(nr, nc);
            }

            return area;
        }
    }

}
