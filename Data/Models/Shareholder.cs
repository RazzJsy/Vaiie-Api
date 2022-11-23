namespace Data.Models
{
    public class Shareholder
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public bool IsCompany { get; set; }
        public List<Director> Directors { get; set; }
    }

}
