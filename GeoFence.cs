using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckGeoFence
{
    public class GeoFence
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoFence(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static bool Check(List<GeoFence> polygon, GeoFence testPoint)
        {
            int intersectCount = 0;

            for (int i = 0; i < polygon.Count - 1; i++)
            {
                if (IsPointOnSegment(polygon[i], polygon[i + 1], testPoint))
                {
                    return true; // The point is on the boundary
                }

                if (testPoint.Latitude > Math.Min(polygon[i].Latitude, polygon[i + 1].Latitude) &&
                    testPoint.Latitude <= Math.Max(polygon[i].Latitude, polygon[i + 1].Latitude) &&
                    testPoint.Longitude <= Math.Max(polygon[i].Longitude, polygon[i + 1].Longitude) &&
                    polygon[i].Latitude != polygon[i + 1].Latitude)
                {
                    double xIntersection = (testPoint.Latitude - polygon[i].Latitude) * (polygon[i + 1].Longitude - polygon[i].Longitude) /
                                            (polygon[i + 1].Latitude - polygon[i].Latitude) + polygon[i].Longitude;

                    if (polygon[i].Longitude == polygon[i + 1].Longitude || testPoint.Longitude <= xIntersection)
                    {
                        intersectCount++;
                    }
                }
            }

            return intersectCount % 2 == 1;
        }

        private static bool IsPointOnSegment(GeoFence start, GeoFence end, GeoFence point)
        {
            if (point.Latitude <= Math.Max(start.Latitude, end.Latitude) &&
                point.Latitude >= Math.Min(start.Latitude, end.Latitude) &&
                point.Longitude <= Math.Max(start.Longitude, end.Longitude) &&
                point.Longitude >= Math.Min(start.Longitude, end.Longitude))
            {
                double d1 = (point.Latitude - start.Latitude) * (end.Longitude - start.Longitude) -
                            (point.Longitude - start.Longitude) * (end.Latitude - start.Latitude);

                if (d1 == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }

}
