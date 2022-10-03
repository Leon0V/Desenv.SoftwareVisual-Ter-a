using System.Collections.Generic;
using System.Linq;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Controllers
{
    public class ReservationController : ControllerBase
    {
        private readonly DataContext _context;
        public ReservationController(DataContext context) =>
            _context = context;

        //registrar reserva
        [HttpPost]
        [Route("regReserve")]
        public IActionResult RegReserve([FromBody] regReservation regReservation)
        {
            var rooms = _context.Rooms.Where(x => x.roomType.Equals(regReservation.roomType)
            ).ToList();

            if (!rooms.Any())
                return BadRequest("Não existem quartos deste tipo cadastrados");

            Room room = null;

            foreach (var availableRoom in rooms)
            {

                // x.3.10.22 < 4.10.22 && x.4.10.22 <= 4.10.22

                // x.3.10.22 > 4.10.22 &&  x.4.10.22 >= 5.10.22
                // 4.10.22 >= x.4.10.22 || (x.3.10.22 < 4.10.22 &&  x.4.10.22 >= 5.10.22)

                if
                (
                _context.Reservations


                // .Where(x => x.dateIn < regReservation.dateIn && x.dateOut <= regReservation.dateIn)
                // .Where(x => regReservation.dateIn >= x.dateOut || (regReservation.dateIn < x.dateIn && x.dateIn >= regReservation.dateOut))
                .Where(x => (regReservation.dateIn >= x.dateOut) || (regReservation.dateIn < x.dateIn && regReservation.dateOut <= x.dateIn))

                .Where(x => x.roomId == availableRoom.id)
                .Any() || !_context.Reservations.Any(x => x.roomId == availableRoom.id)
                )
                {
                    room = availableRoom;
                };
            }

            if (room == null)
                return BadRequest("Não há quarto disponível");




            var reservation = new Reservation
            {
                room = room,
                dateIn = regReservation.dateIn,
                dateOut = regReservation.dateOut,
                cpf = regReservation.cpf,
                guestNo = regReservation.guestNo,
                guestName = regReservation.guestName
            };
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return Created("", reservation);

        }

        //listar reservas
        [HttpGet]
        [Route("listReserves")]
        public IActionResult ListReserves()
        {
            return Ok(_context.Reservations.Include(x => x.room).ToList());
        }

        //alterar reserva
        [HttpPut]
        [Route("updateReserve/{id}")]
        public IActionResult UpdateReserve([FromRoute] int id, [FromBody] UpdateReserve updateReserve)
        {

            var reservation = _context.Reservations.FirstOrDefault(u => u.id.Equals(id));
            if (reservation == null)
                return NotFound();

            Room room = reservation.room;

            if (updateReserve.dateIn != reservation.dateIn || updateReserve.dateOut != reservation.dateOut || updateReserve.roomType != reservation.room.roomType)
            {
                var rooms = _context.Rooms.Where(x => x.roomType.Equals(updateReserve.roomType)
                ).ToList();

                if (!rooms.Any())
                    return BadRequest("Não existem quartos deste tipo cadastrados");

                room = null;

                foreach (var availableRoom in rooms)
                {

                    // x.1.10.22 <= 3.10.22 && x.2.10.22 <= 3.10.22

                    // x.5.10.22 <= 3.10.22 &&  x.5.10.22 >= 4.10.22

                    if
                    (
                    !_context.Reservations
                    .Where(x => x.dateIn <= updateReserve.dateIn && x.dateOut <= updateReserve.dateIn)
                    .Where(x => x.dateIn >= updateReserve.dateIn && x.dateIn >= updateReserve.dateOut)
                    .Where(x => x.roomId == room.id)
                    .Where(x => x.id != reservation.id)
                    .Any()
                    ) continue;

                    room = availableRoom;

                    if (room != null)
                        break;
                }

                if (room == null)
                    return BadRequest("Não há quarto disponível");
            }

            reservation.room = room;
            reservation.guestNo = updateReserve.guestNo;
            reservation.dateIn = updateReserve.dateIn;
            reservation.dateOut = updateReserve.dateOut;
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            return Ok(reservation);
        }

        //cancelar reserva
        [HttpDelete]
        [Route("cancelReserve/{id}")]
        public IActionResult CancelReserve([FromRoute] int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(u => u.id.Equals(id));
            if (reservation == null)
                return NotFound();

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return Ok();
        }
    }
}