/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head == null) return null;

        Dictionary<Node, Node> map = new Dictionary<Node, Node>();
        Node dummy = new Node(0);
        Node cur = head;
        Node prev = dummy;
        while (cur !=  null)
        {
            Node newNode = new Node(cur.val);
            prev.next = newNode;
            prev = newNode;
            map[cur] = newNode;
            cur = cur.next;
        }
        
        cur = head;
        while (cur != null)
        {
            Node copy = map[cur];
            copy.random = cur.random != null ? map[cur.random] : null;
            cur = cur.next;
        }

        return dummy.next;
    }
}
