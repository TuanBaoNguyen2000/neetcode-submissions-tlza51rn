public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var cars = new (int pos, double time)[position.Length];

        for(int i = 0; i < position.Length; i++){
            cars[i] = (position[i], (double)(target - position[i]) / speed[i]);
        }

        Array.Sort(cars, (a, b) => b.pos.CompareTo(a.pos));
        
        int fleets = 0;
        double prevTime = 0;

        foreach(var car in cars)
        {
            if (car.time > prevTime)
            {
                fleets++;
                prevTime = car.time;
            }
        }

        return fleets;
    }
}
