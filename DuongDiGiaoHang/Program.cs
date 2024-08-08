using System;
using System.Collections.Generic;

public class Location
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {
        // Định nghĩa các địa điểm
        List<Location> locations = new List<Location>
        {
            new Location { Name = "A", Latitude = 14.0, Longitude = 24.0 },
            new Location { Name = "B", Latitude = 18.0, Longitude = 26.0 },
            new Location { Name = "C", Latitude = 10.0, Longitude = 22.0 },
            new Location { Name = "D", Latitude = 12.0, Longitude = 20.0 }
        };

        // Định nghĩa ma trận khoảng cách
        double[,] distanceMatrix = new double[,]
        {
            { 0, 4.5, 4.5, 4 },
            { 4.5, 0, 6.4, 6.4 },
            { 4.5, 6.4, 0, 2.8 },
            { 4, 6.4, 2.8, 0 }
        };

        // Tìm đường đi tối ưu
        double minDistance = double.MaxValue;
        List<string> optimalRoute = new List<string>();
        FindOptimalRoute(locations, distanceMatrix, new List<string>(), 0, ref minDistance, ref optimalRoute);

        // In kết quả
        Console.WriteLine("Tuyen duong toi uu:");
        foreach (string location in optimalRoute)
        {
            Console.Write(location + " -> ");
        }
        Console.WriteLine("Tong khoang cach: " + minDistance);
    }

    static void FindOptimalRoute(List<Location> locations, double[,] distanceMatrix, List<string> currentRoute, int currentIndex, ref double minDistance, ref List<string> optimalRoute)
    {
        if (currentRoute.Count == locations.Count)
        {
            double totalDistance = 0;
            for (int i = 0; i < currentRoute.Count - 1; i++)
            {
                int fromIndex = Array.IndexOf(locations.ConvertAll(l => l.Name).ToArray(), currentRoute[i]);
                int toIndex = Array.IndexOf(locations.ConvertAll(l => l.Name).ToArray(), currentRoute[i + 1]);
                totalDistance += distanceMatrix[fromIndex, toIndex];
            }
            if (totalDistance < minDistance)
            {
                minDistance = totalDistance;
                optimalRoute = new List<string>(currentRoute);
            }
            return;
        }

        for (int i = 0; i < locations.Count; i++)
        {
            if (!currentRoute.Contains(locations[i].Name))
            {
                currentRoute.Add(locations[i].Name);
                FindOptimalRoute(locations, distanceMatrix, currentRoute, i, ref minDistance, ref optimalRoute);
                currentRoute.RemoveAt(currentRoute.Count - 1);
            }
        }
    }
}