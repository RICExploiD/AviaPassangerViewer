using System;

namespace AviaPassangerViewer.Models
{
    internal sealed class AviaPassanger
    {
        public Person Person { get; }
        public Flight Flight { get; }
        public AviaPassanger(Person person, Flight flight) 
        {
            Person = person;
            Flight = flight;

            ValidateAviaPassangerData();
        }
        public void ValidateAviaPassangerData()
        {
            if (Person is null || Flight is null)
                throw new NullReferenceException("Person or Flight object is null.");
        }
    }
}
