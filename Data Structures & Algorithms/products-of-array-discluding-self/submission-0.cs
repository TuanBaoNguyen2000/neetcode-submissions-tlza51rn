public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] preProduct = new int[nums.Length];
        int[] sufProduct = new int[nums.Length];
        
        preProduct[0] = nums[0];
        sufProduct[nums.Length - 1] = nums[nums.Length - 1];
        for(int i = 1; i < nums.Length; i++)
        {
            int j = nums.Length - i - 1;
            preProduct[i] = preProduct[i - 1] * nums[i];
            sufProduct[j] = sufProduct[j + 1] * nums[j];
        }

        int[] res = new int[nums.Length]; 
        res[0] = sufProduct[1];
        res[nums.Length - 1] = preProduct[nums.Length - 2];
        for(int i = 1; i < nums.Length - 1; i++)
        {
            int pre = i - 1;
            int suf = i + 1;
            res[i] = sufProduct[suf] * preProduct[pre];
        }

        return res;
    }
}
