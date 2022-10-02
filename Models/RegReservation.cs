using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class regReservation
    {
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string guestName { get; set; }
        public int id { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        [StringLength(11, MinimumLength = 11,
        ErrorMessage = "O campo CPF deve conter 11 caracteres!"
        )]
        public string cpf { get; set; }
        [Range(1, 4, ErrorMessage = "O Hotel aceita apenas de 1 a 4 hóspedes por quarto.")]
        public int guestNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dateIn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dateOut { get; set; }
        [Range(1, 3, ErrorMessage = "O Código do quarto necessita estar entre {1} e {2}.")]
        public Room room { get; set; }
    }
}