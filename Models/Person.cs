using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

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

            var NameIsValid = protocol.IsMatch(Name);
            var FamilyIsValid = protocol.IsMatch(Family);
            var PatronomicIsValid = Patronomic is null || protocol.IsMatch(Patronomic);

            if (NameIsValid || FamilyIsValid || PatronomicIsValid) return;
                
            throw new ValidationException("Name, family or patronimic is not valid.");
        }
    }
}
