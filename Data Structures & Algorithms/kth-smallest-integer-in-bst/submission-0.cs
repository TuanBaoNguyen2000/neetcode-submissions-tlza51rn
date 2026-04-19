/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;

        while (cur != null || stack.Count > 0)
        {
            while(cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }

            cur = stack.Pop();
            k--;
            if (k == 0)
                return cur.val;
            cur = cur.right;
        }
        return -1;
    }
}
