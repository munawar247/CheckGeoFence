using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckGeoFence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<GeoFence> polygon = new List<GeoFence>
        {
            new GeoFence(37.7749, -122.4194), // San Francisco, CA
            new GeoFence(34.0522, -118.2437), // Los Angeles, CA
            new GeoFence(40.7128, -74.0060),  // New York, NY
            new GeoFence(41.8781, -87.6298)   // Chicago, IL
        };

            // Test point
            GeoFence testPoint1 = new GeoFence(37.3394, -121.8950); // San Jose, CA
            GeoFence testPoint2 = new GeoFence(38.8951, -77.0364);  // Washington, D.C.

            bool isInsidePolygon1 = GeoFence.Check(polygon, testPoint1);
            bool isInsidePolygon2 = GeoFence.Check(polygon, testPoint2);

            Console.WriteLine($"Is testPoint1 inside the polygon: {isInsidePolygon1}"); // Should be true (inside)
            Console.WriteLine($"Is testPoint2 inside the polygon: {isInsidePolygon2}"); // Should be false (outside)
            Console.ReadLine();
        }
        
    }

}
