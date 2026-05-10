public class Solution
{
    private static readonly int[][] Directions =
    {
        new[] { 0, 1 },
        new[] { 1, 0 },
        new[] { 0, -1 },
        new[] { -1, 0 }
    };

    public void Solve(char[][] board)
    {
        if (board == null || board.Length == 0)
            return;

        int rows = board.Length;
        int cols = board[0].Length;

        Queue<(int r, int c)> queue = new();

        // Add all border 'O'
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                bool isBorder =
                    r == 0 ||
                    r == rows - 1 ||
                    c == 0 ||
                    c == cols - 1;

                if (!isBorder || board[r][c] != 'O')
                    continue;

                board[r][c] = '#';
                queue.Enqueue((r, c));
            }
        }

        // BFS from border cells
        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();

            foreach (var direction in Directions)
            {
                int nr = r + direction[0];
                int nc = c + direction[1];

                bool isOutOfBounds =
                    nr < 0 ||
                    nr >= rows ||
                    nc < 0 ||
                    nc >= cols;

                if (isOutOfBounds || board[nr][nc] != 'O')
                    continue;

                board[nr][nc] = '#';
                queue.Enqueue((nr, nc));
            }
        }

        // Build final result
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (board[r][c] == 'O')
                {
                    board[r][c] = 'X';
                }
                else if (board[r][c] == '#')
                {
                    board[r][c] = 'O';
                }
            }
        }
    }
}