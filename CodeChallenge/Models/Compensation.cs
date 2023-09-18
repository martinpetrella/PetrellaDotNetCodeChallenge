namespace CodeChallenge.Models
{
    public class Compensation
    {
        public int Id { get; set; }
        public Employee employee { get; set; }
        public string salary {  get; set; }
        public string effectiveDate { get; set; }
    }
}
