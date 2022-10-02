using System.Collections.Generic;
using System.Linq;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class ReservationController : ControllerBase
    {
        // private readonly DataContext _context;
        // public ReservationController(DataContext context) =>
        //     _context = context;

            
        private static List<Reservation> reservations = new List<Reservation>();

        //registrar reserva
        [HttpPost]
        [Route("regReserve")]
        public IActionResult RegReserve([FromBody] regReservation regReservation)
        {

            var room = RoomController.rooms.FirstOrDefault
            (
                u => u.roomType.Equals(regReservation.room)
            );

            if (room == null)
                return NotFound();

            var reservation = new Reservation();
            reservation.room = regReservation.room;
            reservation.dateIn = regReservation.dateIn;
            reservation.dateOut = regReservation.dateOut;
            reservation.cpf = regReservation.cpf;
            reservation.guestNo = regReservation.guestNo;
            reservation.guestName = regReservation.guestName;
            reservations.Add(reservation);

            return Created("", reservation);

        }

        //listar reservas
        [HttpGet]
        [Route("listReserves")]
        public IActionResult ListReserves()
        {
            return Ok(reservations);
        }

        //alterar reserva
        [HttpPut]
        [Route("updateReserve/{cpf}")]
        public IActionResult UpdateReserve([FromRoute] string cpf, [FromBody] UpdateReserve updateReserve)
        {
            Reservation reservation = reservations.FirstOrDefault
            (
                u => u.cpf.Equals(cpf)
            );
            if (reservation == null)
                return NotFound();

            reservation.roomType = updateReserve.roomType;
            reservation.cpf = updateReserve.cpf;
            reservation.guestName = updateReserve.guestName;
            reservation.guestNo = updateReserve.guestNo;
            reservation.dateIn = updateReserve.dateIn;
            reservation.dateOut = updateReserve.dateOut;
            reservations.RemoveAll(u => u.cpf.Equals(cpf));
            reservations.Add(reservation);
            return Ok(reservation);
        }

        //cancelar reserva
        [HttpDelete]
        [Route("cancelReserve/{cpf}")]
        public IActionResult CancelReserve([FromRoute] string cpf)
        {
            Reservation reservation = reservations.FirstOrDefault
            (
                u => u.cpf.Equals(cpf)
            );
            if (reservation == null)
                return NotFound();

            reservations.Remove(reservation);
            return Ok(reservation);
        }
    }
}