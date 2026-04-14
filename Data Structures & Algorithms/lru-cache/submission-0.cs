public class LRUCache {

    public class Node 
    {
        public int key;
        public int val;
        public Node next;
        public Node prev;

        public Node(int key , int val)
        {
            this.key = key;
            this.val = val;
            next = null;
            prev = null;
        }
    }

    Dictionary<int, Node> map;
    Node head;
    Node tail;
    int capacity;

    public LRUCache(int capacity) {
        map = new Dictionary<int, Node>();
        head = new Node(0, 0);
        tail = new Node (0, 0);
        head.next = tail;
        tail.prev = head;
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        if (!map.ContainsKey(key))
            return -1;

        MoveToHead(map[key]);
        return map[key].val;
    }
    
    public void Put(int key, int value) {
        if (map.ContainsKey(key))
        {
            map[key].val = value;
            MoveToHead(map[key]);
        }
        else
        {
            if (map.Count >= capacity)
            {
                map.Remove(tail.prev.key);
                RemoveNode(tail.prev);
            }

            Node newNode = new Node(key, value);
            map[key] = newNode;
            AddToHead(newNode);
        }
    }

    void MoveToHead(Node node)
    {
        RemoveNode(node);
        AddToHead(node);
    }

    void AddToHead(Node node)
    {
        node.next = head.next;
        head.next.prev = node;
        head.next = node;
        node.prev = head;
    }

    void RemoveNode(Node node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }
}
