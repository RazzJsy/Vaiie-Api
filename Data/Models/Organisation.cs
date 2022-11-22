namespace Data.Models
{
    public class Organisation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public List<Director> Directors { get; set; }
        public List<Shareholder> Shareholders { get; set; }
    }
}
