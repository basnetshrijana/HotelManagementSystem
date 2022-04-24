using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int RoomId{get;set;}

        [Required]
        public int CustomerId{get;set;}
        [Required]
        public string CustomerName{get;set;}

        public DateTime CreatedDateTime{get;set;}=DateTime.Now;
        
        
    }
}