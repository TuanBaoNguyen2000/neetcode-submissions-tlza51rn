public class Twitter {

    private Dictionary<int, User> users;
    private int time;

    public Twitter() {
        users = new Dictionary<int, User>();
        time = 0;
    }
    
    public void PostTweet(int userId, int tweetId) {
        if (!users.ContainsKey(userId))
            users[userId] = new User(userId);

        users[userId].posts.Add(new Post(tweetId, time++, userId));
    }
    
    public List<int> GetNewsFeed(int userId) {
        List<int> result = new List<int>();
        if (!users.ContainsKey(userId)) return result;

        var user = users[userId];

        // max heap theo timestamp
        var maxHeap = new PriorityQueue<(Post post, int index), int>();

        // helper: add tweet mới nhất của 1 user vào heap
        void AddUserToHeap(int uid) {
            if (!users.ContainsKey(uid)) return;

            var u = users[uid];
            int lastIndex = u.posts.Count - 1;

            if (lastIndex >= 0) {
                var post = u.posts[lastIndex];
                maxHeap.Enqueue((post, lastIndex), -post.timestamp);
            }
        }

        // add tất cả user liên quan
        foreach (int followeeId in user.followees) {
            AddUserToHeap(followeeId);
        }

        // lấy tối đa 10 tweet mới nhất
        while (maxHeap.Count > 0 && result.Count < 10) {
            var (post, index) = maxHeap.Dequeue();
            result.Add(post.tweetId);

            // lấy tweet trước đó của cùng user
            if (index - 1 >= 0) {
                int uid = post.userId;
                var prevPost = users[uid].posts[index - 1];
                maxHeap.Enqueue((prevPost, index - 1), -prevPost.timestamp);
            }
        }

        return result;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (!users.ContainsKey(followerId))
            users[followerId] = new User(followerId);

        if (!users.ContainsKey(followeeId))
            users[followeeId] = new User(followeeId);

        users[followerId].followees.Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if (!users.ContainsKey(followerId)) return;
        if (followerId == followeeId) return; // không tự unfollow

        users[followerId].followees.Remove(followeeId);
    }
}

public class User {
    public int userId;
    public List<Post> posts;
    public HashSet<int> followees;

    public User(int userId) {
        this.userId = userId;
        posts = new List<Post>();
        followees = new HashSet<int>();
        followees.Add(userId); // self-follow
    }
}

public class Post {
    public int tweetId;
    public int timestamp;
    public int userId;

    public Post(int tweetId, int timestamp, int userId) {
        this.tweetId = tweetId;
        this.timestamp = timestamp;
        this.userId = userId;
    }
}