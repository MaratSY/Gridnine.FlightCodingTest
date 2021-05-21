using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest
{
   
    public static class Filter
    {
        public static IList<Flight> FlightsDepartingInThePast(this IList<Flight> flights)
        {
            return flights.SelectMany(f => f.Segments, (f, s) => new { flight = f, segment = s })
                          .Where(fs => fs.segment.ArrivalDate < fs.segment.DepartureDate)
                          .Select(fs => fs.flight)
                          .ToList();
        }

        public static IList<Flight> FlightsThatDepartsBeforeItArrives(this IList<Flight> flights)
        {
            return flights.SelectMany(f => f.Segments, (f, s) => new { flight = f, segment = s })
                          .Where(fs => fs.segment.ArrivalDate < fs.segment.DepartureDate)
                          .Select(fs => fs.flight)
                          .ToList();
        }
        public static IList<Flight> FlightsWithMoreThanTwoHoursGroundTime(this IList<Flight> flights)
        {
            double groundTime = 2;

            IList<Flight> result = new List<Flight>();

            var flightsWithMoreThanOneSegment = flights.Where(f => f.Segments.Count > 1).ToList();


            for (int i = 0; i < flightsWithMoreThanOneSegment.Count; i++)
            {
                TimeSpan totalGroundTime = TimeSpan.Zero;
                for (int j = 0; j < flightsWithMoreThanOneSegment[i].Segments.Count - 1; j++)
                {
                    DateTime arrivalFirstSeg = flightsWithMoreThanOneSegment[i].Segments[j].ArrivalDate;
                    DateTime departureSecondSeg = flightsWithMoreThanOneSegment[i].Segments[j + 1].DepartureDate;
                    totalGroundTime = totalGroundTime.Add(departureSecondSeg.Subtract(arrivalFirstSeg));
                }
                if (totalGroundTime.TotalHours > groundTime)
                {
                    result.Add(flightsWithMoreThanOneSegment[i]);
                }
            }

            return result;
        }
    }
  

}
