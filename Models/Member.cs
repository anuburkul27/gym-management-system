namespace GymManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Phone { get; set; }

        public required string MembershipType { get; set; }
    }
}