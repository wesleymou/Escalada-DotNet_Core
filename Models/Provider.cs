using System.Collections.Generic;

namespace Escalada_DotNet_Core.Models
{
    public class Provider
    {
        public int id { get; set; }
        public ICollection<SubscriptionProvider> subscriptionProviderId { get; set; }
    }
}