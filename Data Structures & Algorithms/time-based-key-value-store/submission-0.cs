public class TimeMap {

    Dictionary<string, List<(string value, int timestamp)>> map;

    public TimeMap() {
        map = new Dictionary<string, List<(string value, int timestamp)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if (map.ContainsKey(key))
            map[key].Add(new (value, timestamp));
        else
            map[key] = new List<(string value, int timestamp)>() {new (value, timestamp)};
    }
    
    public string Get(string key, int timestamp) {
        if (map.ContainsKey(key))
        {
            int n = map[key].Count;
            int l = 0;
            int r = n - 1;
            int res = -1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                if (map[key][m].timestamp <= timestamp)
                {
                    res = m;
                    l = m + 1;
                }
                else
                    r = m - 1;
            }

            if (res >= 0)
                return map[key][res].value;
            else
                return "";

        }
        else
            return "";
    }
}
