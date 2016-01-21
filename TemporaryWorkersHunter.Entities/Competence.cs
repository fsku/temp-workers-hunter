using System.ComponentModel.DataAnnotations;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Entities
{
    public class Competence : Entity<int>
    {
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
