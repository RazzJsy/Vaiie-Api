namespace Data.Models
{
    public class Director
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public Person Person { get; set; }
        public Address Address { get; set; }
        public bool IsBlacklisted { get; set; }
    }
}
