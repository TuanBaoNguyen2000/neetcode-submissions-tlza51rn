/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        if (intervals == null || intervals.Count <= 1)
            return true;

        intervals.Sort((a, b) => a.start.CompareTo(b.start));

        int prevEnd = intervals[0].end;

        for (int i = 1; i < intervals.Count; i++) {
            if (intervals[i].start < prevEnd)
                return false;

            prevEnd = intervals[i].end;
        }

        return true;
    }
}
