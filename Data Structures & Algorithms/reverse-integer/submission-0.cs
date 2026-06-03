public class Solution {
    public int Reverse(int x) {
        int res = 0;
        while (x != 0)
        {
            int digit = x % 10;
            x = x / 10;

            if (res > int.MaxValue / 10 || (res == int.MaxValue / 10 && digit > int.MaxValue % 10))
                return 0;

            if (res < int.MinValue / 10 || (res == int.MinValue / 10 && digit < int.MinValue % 10))
                return 0;

            res = res * 10 + digit;
        }

        return res;
    }
}
