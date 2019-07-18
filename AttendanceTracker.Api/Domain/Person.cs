using System;
using System.Collections.Generic;
using NodaTime;

namespace AttendanceTracker.Domain
{
    public class Person
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public LocalDate DateOfBirth { get; }
        public List<ClassRegisterEntry> ClassRegisterEntries { get; }

        public Person(Guid id, string firstName, string lastName, LocalDate dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            ClassRegisterEntries = new List<ClassRegisterEntry>();
        }

        public void Attend(Class @class, LocalDateTime now)
        {
            ClassRegisterEntries.Add(new ClassRegisterEntry(Guid.NewGuid(), Id, @class.Id, now));
        }
    }
}