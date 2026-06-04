public class Solution {
    public int UniquePaths(int m, int n) {
        int[] row = new int[n];
        Array.Fill(row, 1);

        for (int i = 0; i < m - 1; i++)
        {
            int[] newRow = new int[n];
            Array.Fill(newRow, 1);
            for (int j = n - 2; j >= 0; j--)
            {
                newRow[j] = newRow[j + 1] + row[j];
            }
            row = newRow;
        }

        return row[0];
    }
}
