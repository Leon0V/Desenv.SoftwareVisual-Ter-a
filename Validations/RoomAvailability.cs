using System.ComponentModel.DataAnnotations;
using System.Linq;
using Booking.Models;
using Booking.Controllers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Booking.Validations
{
    public class RoomAvailability : ValidationAttribute
    {
        public static List<Room> rooms = new List<Room>();
        public RoomAvailability(int id)
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int id = (int)value;

            DataContext context =
            (DataContext)validationContext.GetService(typeof(DataContext));

            Room room = rooms.FirstOrDefault
            (
                u => u.id.Equals(id)
            );
            if (room == null)
                return ValidationResult.Success;

            return new ValidationResult("O Quarto já está reservado!");
        }
    }
}