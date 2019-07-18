using System.ComponentModel.DataAnnotations;
using NodaTime;

namespace AttendanceTracker.Contract
{
    public class RegisterPersonCommand
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public LocalDate DateOfBirth { get; set; }
    }
}