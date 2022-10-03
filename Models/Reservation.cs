using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Booking
{
    public class Reservation
    {
        [ForeignKey("room")]
        public int roomId { get; set; }
        public Room room { get; set; }

        [Key]
        public int id { get; set; }
        public string cpf { get; set; }
        public string guestName { get; set; }
        public int guestNo { get; set; }
        public double totalPrice => priceCalc();
        public DateTime dateIn { get; set; }
        public DateTime dateOut { get; set; }

        public double Duration => getDuration();

        private double priceCalc()
        {
            return ((guestNo * 55 + room.roomRate * Duration));
        }

        private double getDuration()
        {
            return (dateOut - dateIn).TotalDays;
        }

    }
}