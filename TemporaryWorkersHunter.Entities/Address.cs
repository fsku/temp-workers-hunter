using System.ComponentModel.DataAnnotations;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Entities
{
    public class Address : Entity<int>
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public int ApartmentNumber { get; set; }
        public string ZipCode { get; set; }

        //TODO City Country
    }
}