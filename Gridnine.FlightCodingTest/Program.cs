using System;
using System.Linq;

namespace Gridnine.FlightCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            var flights = flightBuilder.GetFlights();

            Console.WriteLine("======================================\n" + 
                              "All flights:");
            foreach (var flight in flights)
            {
                Console.WriteLine(FlightOutput.FlightToString(flight));
            }

            Console.WriteLine("======================================\n" +
                              "Flights with departure date up to the current time are excluded:");
            foreach (var flight in flights.Except(flights.FlightsDepartingInThePast()))
            {
                Console.WriteLine(FlightOutput.FlightToString(flight));
            }

            Console.WriteLine("======================================\n" +
                             "Flights with an arrival date earlier than the departure date are excluded:");
            foreach (var flight in flights.Except(flights.FlightsThatDepartsBeforeItArrives()))
            {
                Console.WriteLine(FlightOutput.FlightToString(flight));
            }

            Console.WriteLine("======================================\n" +
                             "Flights with more than two hours ground time are excluded:");
            foreach (var flight in flights.Except(flights.FlightsWithMoreThanTwoHoursGroundTime()))
            {
                Console.WriteLine(FlightOutput.FlightToString(flight));
            }
        }
    }
}
