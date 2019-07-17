using System;
using NodaTime;

namespace AttendanceTracker.Domain
{
    public class ClassRegisterEntry
    {
        public Guid Id { get; }
        public Guid PersonId { get; }
        public Guid ClassId { get; }
        public LocalDateTime AttendedAtTime { get; }

        public ClassRegisterEntry(Guid id, Guid personId, Guid classId, LocalDateTime attendedAtTime)
        {
            Id = id;
            PersonId = personId;
            ClassId = classId;
            AttendedAtTime = attendedAtTime;
        }
    }
}