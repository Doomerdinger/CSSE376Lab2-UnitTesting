using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		//TODO Task 7 items go here
        DateTime start = new DateTime(1, 1, 1);
        DateTime end = new DateTime(1, 1, 2);
        [Test()]
        public void TestThatFlightInitializes()
        {
            var flight = new Flight(start,end,1);
            Assert.IsNotNull(flight);
        }
        [Test()]
        public void TestEquals()
        {
            var flight = new Flight(start, end, 1);
            var flight2 = new Flight(start, end, 1);
             var flight3 = new Flight(start, end, 123);
            Assert.True(flight.Equals(flight2));
            Assert.False(flight.Equals(flight3));
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDay()
        {
            var flight = new Flight(start, new DateTime(1, 1, 2), 1);
            Assert.AreEqual(220, flight.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDay()
        {
            var flight = new Flight(start, new DateTime(1, 1, 3), 1);
            Assert.AreEqual(240, flight.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDays()
        {
            var flight = new Flight(start, new DateTime(1, 1, 11), 1);
            Assert.AreEqual(400, flight.getBasePrice());
        }
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDate()
        {
            new Flight(end,start,1);
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadLMiles()
        {
            new Flight(start,end, -1);
        }
	}
}