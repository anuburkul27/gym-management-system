using System;

namespace GymManagementSystem.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public required string MemberName { get; set; }

        public DateTime Date { get; set; }

        public int Status { get; set; }
    }
}