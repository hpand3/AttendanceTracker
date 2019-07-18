using System;
using AttendanceTracker.Contract;
using AttendanceTracker.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RegisterPersonCommand registerPersonCommand)
        {
            var newPerson = new Person(Guid.NewGuid(), registerPersonCommand.FirstName, registerPersonCommand.LastName, registerPersonCommand.DateOfBirth);
            return Ok(newPerson);
        }
    }
}