using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Booking
{
    public class Reservation
    {
        public int roomType { get; set; }
        public Room room { get; set; }
        private int id { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        [StringLength(11, MinimumLength = 11,
        ErrorMessage = "O campo CPF deve conter 11 caracteres!"
        )]
        public string cpf { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string guestName { get; set; }

        [Range(1, 4, ErrorMessage = "O Hotel aceita apenas de 1 a 4 hóspedes por quarto.")]
        public int guestNo { get; set; }
        public double totalPrice => priceCalc();

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dateIn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dateOut { get; set; }

        [Range(1, 30, ErrorMessage = "A duração da estadia deve estar entre {1} e {2} dias.")]
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