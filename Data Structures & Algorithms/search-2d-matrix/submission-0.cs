public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int top = 0;
        int bottom = matrix.Length - 1;

        while (top <= bottom)
        {
            int midRow = top + (bottom - top) / 2;
            int length = matrix[midRow].Length;
            bool isInRow = target >= matrix[midRow][0] && target <= matrix[midRow][length - 1];
            if (isInRow)
            {
                int left = 0;
                int right = length - 1;
                while (left <= right)
                {
                    int midCol = left + (right - left) / 2;
                    if (target == matrix[midRow][midCol])
                        return true;

                    if (matrix[midRow][midCol] < target)
                        left = midCol + 1;
                    else
                        right = midCol - 1;
                }

                return false;
            }

            if(matrix[midRow][0] < target)
                top = midRow + 1;
            else
                bottom = midRow - 1;
        }

        return false;
    }
}
