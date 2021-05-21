using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest
{
    public static class FlightOutput
    {
        /// <summary>
        /// Returns a string that represents a curent object
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public static string FlightToString (Flight flight)
        {
            string result = "";
            for (int i = 0; i < flight.Segments.Count; i++)
            {
                result += $"Departure: {flight.Segments[i].DepartureDate}\n" +
                          $"Arrival: {flight.Segments[i].ArrivalDate}\n";
            }
            return result;
        }
    }
}
