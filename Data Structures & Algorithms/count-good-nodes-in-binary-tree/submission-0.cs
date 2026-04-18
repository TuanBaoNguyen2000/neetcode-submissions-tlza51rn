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
    public int GoodNodes(TreeNode root) {
        if (root == null) return 0;
        return DFS(root, root.val);
    }

    private int DFS(TreeNode node, int curMax)
    {
        if (node == null) return 0;

        int count = 0;
        if (node.val >= curMax) 
        {
            curMax = node.val;
            count = 1;
        }

        count += DFS(node.left, curMax);
        count += DFS(node.right, curMax);

        return count;
    }
}
