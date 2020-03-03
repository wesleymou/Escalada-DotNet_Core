namespace Escalada.Models
{
    public class Agreement
    {
        public int Id { get; set; }
        public Provider Provider { get; set; }
        public Event Event { get; set; }
    }
}
