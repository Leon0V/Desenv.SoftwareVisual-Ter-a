using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class RoomController : ControllerBase
    {
        public static List<Room> rooms = new List<Room>();


        //registrar quarto
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] Room room)
        {
            rooms.Add(room);
            return Created("", room);
        }

        //listar quartos
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(rooms);
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