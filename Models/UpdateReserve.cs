using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class UpdateReserve
    {
        public int roomType { get; set; }
        private int id { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        [StringLength(11, MinimumLength = 11,
        ErrorMessage = "O campo CPF deve conter 11 caracteres!"
        )]
        public string cpf { get; set; }
        public int guestNo { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string guestName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dateIn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dateOut { get; set; }
    }
}