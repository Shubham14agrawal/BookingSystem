using System;

namespace BookingService.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int InventoryItemId { get; set; }
        public string BookingReference { get; set; } = Guid.NewGuid().ToString();
        public DateTime BookingDateTime { get; set; }
        public bool IsCancelled { get; set; }
    }
}
