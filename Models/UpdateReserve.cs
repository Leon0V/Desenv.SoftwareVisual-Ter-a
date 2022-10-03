using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class UpdateReserve
    {
        public int roomType { get; set; }
        public int guestNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dateIn { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dateOut { get; set; }

    }
}