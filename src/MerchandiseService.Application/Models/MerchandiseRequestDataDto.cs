using System;

namespace MerchandiseService.Application.Models
{
    public class MerchandiseRequestDataDto
    {
        public string Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string Type { get; set; }

        public DateTimeOffset? GaveOutAt { get; set; }
    }
}
