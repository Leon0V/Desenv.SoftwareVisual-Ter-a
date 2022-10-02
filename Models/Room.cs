using System.ComponentModel.DataAnnotations;

namespace Booking
{
    public class Room
    {
        public int id { get; set; }
        [Range(1, 3, ErrorMessage = "O Tipo do quarto necessita estar entre {1} e {2}.")]
        public int roomType { get; set; }
        public double roomRate => getRate();

        private double getRate()
        {
            if (roomType.Equals(1))
                return 130;
            else if (roomType.Equals(2))
                return 170;
            else
                return 200;
        }
    }
}