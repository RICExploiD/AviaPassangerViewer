using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AviaPassangerViewer.Models
{
    internal sealed class Person
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Patronomic { get; set; }
        public Person(string name, string family, string patronomic = null)
        {
            Name = name;
            Family = family;
            Patronomic = patronomic;

            PersonDataValidation();
        }
        private void PersonDataValidation()
        {
            var protocol = new Regex(@"^[a-zA-Z]+$");

            if (string.IsNullOrEmpty(Name) || !protocol.IsMatch(Name)
                || string.IsNullOrEmpty(Family) || !protocol.IsMatch(Family)
                || Patronomic is not null ? string.IsNullOrEmpty(Family) || !protocol.IsMatch(Family) : true)
                throw new ValidationException("Name, family or patronimic is not valid.");
        }
    }
}
