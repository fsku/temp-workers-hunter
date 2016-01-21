namespace TemporaryWorkersHunter.Entities
{
    public class Roles
    {
        public int Rowid { get; set; }
        public int IdUser { get; set; }
        public int IdMenu { get; set; }
        public bool Status { get; set; }
    }
}