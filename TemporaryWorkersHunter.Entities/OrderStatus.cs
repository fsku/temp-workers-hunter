using System.ComponentModel.DataAnnotations;

namespace TemporaryWorkersHunter.Entities
{
    public enum OrderStatus
    {
        
        Registered,
        Rejected,
        [Display(Name = "In Preparation")]
        InPreparation,
        Fulfilled,
        Archival
    }
}