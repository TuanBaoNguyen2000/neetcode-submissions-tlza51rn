public class Solution {
    public bool CheckValidString(string s) {
        int minOpen = 0;
        int maxOpen = 0;

        foreach (var c in s)
        {
            if (c == '(')
            {
                minOpen++;
                maxOpen++;
            }
            else if (c == ')')
            {
                minOpen--;
                maxOpen--;
            }
            else
            {
                minOpen--;
                maxOpen++;
            }

            if (maxOpen < 0)
                return false;

            if (minOpen < 0)
                minOpen = 0;
        }

        return minOpen == 0;
    }
}
