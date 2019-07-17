using System;

namespace AttendanceTracker.Domain
{
    public class Class
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Details { get; }

        public Class(Guid id, string name, string details)
        {
            Id = id;
            Name = name;
            Details = details;
        }
    }
}