namespace GymManagementSystem.Models
{
    public class BMI
    {
        public required string MemberName { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public double BMIValue { get; set; }

        public required string Category { get; set; }

        public required string WorkoutPlan { get; set; }

        public required string DietPlan { get; set; }
    }
}