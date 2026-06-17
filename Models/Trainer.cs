namespace GymManagementSystem.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Specialization { get; set; }
    }
}