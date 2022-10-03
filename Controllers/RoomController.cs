using System.Collections.Generic;
using System.Linq;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class RoomController : ControllerBase
    {
        private readonly DataContext _context;
        public RoomController(DataContext context) =>
            _context = context;


        //registrar quarto
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegRoom regRoom)
        {
            var room = new Room
            {
                roomName = regRoom.roomName,
                roomType = regRoom.roomType
            };
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return Created("", room);
        }

        //listar quartos
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_context.Rooms.ToList());

        }

        // //buscar quarto
        // [HttpGet]
        // [Route("search/{id}")]
        // public IActionResult Search([FromRoute] string id)
        // {
        //     Room room = rooms.FirstOrDefault
        //     (
        //         u => u.id.Equals(id)
        //     );
        //     if (rooms == null)
        //         return NotFound();

        //     return Ok(room);
        // }

        //não será necessário alterar tipo de quarto
        //deletar quarto, comando apenas para consulta
        // [HttpDelete]
        // [Route("delete/{id}")]
        // public IActionResult Delete([FromRoute] string id)
        // {
        //     Room room = rooms.FirstOrDefault
        //     (
        //         u => u.id.Equals(id)
        //     );
        //     if (room == null)
        //         return NotFound();

        //     rooms.Remove(room);
        //     return Ok(room);
        // }

    }
}