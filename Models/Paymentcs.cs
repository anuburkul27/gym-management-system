using System;

namespace GymManagementSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public required string MemberName { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}