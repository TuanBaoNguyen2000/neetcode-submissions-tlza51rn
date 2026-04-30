public class Solution {

    int[][] directions = new int[][]
    {
        new int[] {0, 1},
        new int[] {1, 0},
        new int[] {0, -1},
        new int[] {-1, 0},
    };

    public bool Exist(char[][] board, string word) {
        int rows = board.Length;
        int cols = board[0].Length;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (board[r][c] == word[0] && DFS(r, c, 0))
                    return true;
            }
        }

        return false;

        bool DFS(int row, int col, int idx)
        {
            // Match last char
            if (idx == word.Length - 1)
                return board[row][col] == word[idx];

            // If don't match -> false
            if (board[row][col] != word[idx])
                return false;

            // Mark visited (in-place)
            char temp = board[row][col];
            board[row][col] = '#';

            foreach (var d in directions)
            {
                int nr = row + d[0];
                int nc = col + d[1];

                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                    continue;

                if (DFS(nr, nc, idx + 1))
                {
                    board[row][col] = temp; // rollback
                    return true;
                }
            }

            // rollback
            board[row][col] = temp;
            return false;
        }
    }
}