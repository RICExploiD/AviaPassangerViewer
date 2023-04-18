using System;
using System.ComponentModel.DataAnnotations;

namespace AviaPassangerViewer.Models
{
    internal sealed class Flight
    {
        public DateTime Time { get; }
        public int Number { get; }
        public Flight(DateTime time, int number)
        {
            Time = time;
            Number = number;

            ValidateFlightData();
        }
        public void ValidateFlightData()
        {
            if (Time.Equals(default) || Number < 0) 
                throw new ValidationException("Time or number not valid.");
        }
    }
}
