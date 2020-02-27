using Escalada_DotNet_Core.Models;

namespace Escalada_DotNet_Core.Models
{
    public class SubscriptionProvider
    {
        public int id { get; set; }
        public Provider providerId { get; set; }
        public Event eventId;
    }
}