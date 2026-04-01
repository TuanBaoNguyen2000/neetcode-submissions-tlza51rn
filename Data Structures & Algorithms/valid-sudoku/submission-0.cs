public class Solution {
    public bool IsValidSudoku(char[][] board) {
        int rows = board.Length;
        int matrixLength = rows / 3;
        HashSet<char>[] rowSets = new HashSet<char>[rows];
        HashSet<char>[] colSets = new HashSet<char>[rows];
        HashSet<char>[,] subBoxes = new HashSet<char>[3, 3];

        for(int row = 0; row < rows; row++)
        {
            int cols = board[row].Length;
            if (cols != rows)
                return false;

            for(int col = 0; col < cols; col++)
            {
                char c = board[row][col];
                if (c == '.') 
                    continue;

                int subBoxRow = row / 3;
                int subBoxCol = col / 3;

                if (rowSets[row] == null) rowSets[row] = new HashSet<char>();
                if (colSets[col] == null) colSets[col] = new HashSet<char>();
                if (subBoxes[subBoxRow, subBoxCol] == null) 
                    subBoxes[subBoxRow, subBoxCol] = new HashSet<char>();

                if (!rowSets[row].Add(c)) return false;
                if (!colSets[col].Add(c)) return false;
                if (!subBoxes[subBoxRow, subBoxCol].Add(c)) return false;
            }
        }

        return true;
    }
}
