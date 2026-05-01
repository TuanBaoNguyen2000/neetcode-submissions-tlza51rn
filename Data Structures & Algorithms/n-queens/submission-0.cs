public class Solution
{
    public List<List<string>> SolveNQueens(int n)
    {
        var result = new List<List<string>>();

        char[,] board = new char[n, n];
        bool[] cols = new bool[n];
        bool[] d1 = new bool[2 * n - 1]; // row - col + (n - 1)
        bool[] d2 = new bool[2 * n - 1]; // row + col

        // init board
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                board[i, j] = '.';
            }
        }

        DFS(0);
        return result;

        bool IsValid(int row, int col)
        {
            int id1 = row - col + (n - 1);
            int id2 = row + col;

            return !cols[col] && !d1[id1] && !d2[id2];
        }

        List<string> BuildBoard()
        {
            var res = new List<string>();

            for (int i = 0; i < n; i++)
            {
                char[] row = new char[n];
                for (int j = 0; j < n; j++)
                {
                    row[j] = board[i, j];
                }
                res.Add(new string(row));
            }

            return res;
        }

        void DFS(int row)
        {
            if (row == n)
            {
                result.Add(BuildBoard());
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (!IsValid(row, col)) continue;

                int id1 = row - col + (n - 1);
                int id2 = row + col;

                // place queen
                board[row, col] = 'Q';
                cols[col] = true;
                d1[id1] = true;
                d2[id2] = true;

                DFS(row + 1);

                // backtrack
                board[row, col] = '.';
                cols[col] = false;
                d1[id1] = false;
                d2[id2] = false;
            }
        }
    }
}