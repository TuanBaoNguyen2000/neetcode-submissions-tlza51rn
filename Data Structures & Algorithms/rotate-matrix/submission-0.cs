public class Solution {
    public void Rotate(int[][] matrix) {
        int left = 0;
        int right = matrix.Length - 1;

        while (left < right)
        {
            for (int i = 0; i < right - left; i++)
            {
                int top = left;
                int bottom = right;

                // save TopLeft
                var topLeft = matrix[top][left + i];

                // put BottomLeft to TopLeft
                matrix[top][left + i] = matrix[bottom - i][left];

                // put BottomRight to BottomLeft
                matrix[bottom - i][left] = matrix[bottom][right - i];

                // put TopRight to BottomRight
                matrix[bottom][right - i] = matrix[top + i][right];

                // put TopLeft to TopRight
                matrix[top + i][right] = topLeft;
            }

            left += 1;
            right -= 1;
        }
    }
}
