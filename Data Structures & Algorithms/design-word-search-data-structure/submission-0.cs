public class WordDictionary {

    TrieNode root;

    public WordDictionary() {
        root = new TrieNode();
    }
    
    public void AddWord(string word) {
        TrieNode cur = root;
        foreach(char c in word) {
            if (cur.children[c - 'a'] == null)
                cur.children[c - 'a'] = new TrieNode();
            cur = cur.children[c - 'a'];
        }
        cur.endOfWord = true;
    }
    
    public bool Search(string word) {
        return DFS(word, 0, root);
    }

    private bool DFS(string word, int i, TrieNode node)
    {
        if (node == null) return false;

        if (i == word.Length)
            return node.endOfWord;

        char c = word[i];

        if (c == '.')
        {
            foreach (var child in node.children)
            {
                if (DFS(word, i + 1, child))
                    return true;
            }
            return false;
        }

        return DFS(word, i + 1, node.children[c - 'a']);
    }
}

public class TrieNode {
    public TrieNode[] children = new TrieNode[26];
    public bool endOfWord = false;
}