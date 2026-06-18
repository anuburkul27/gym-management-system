using Microsoft.AspNetCore.Mvc;
using GymManagementSystem.Models;

namespace GymManagementSystem.Controllers
{
    public class BMIController : Controller
    {
        // Open BMI Page
        public IActionResult Index()
        {
            return View();
        }

        // Calculate BMI
        [HttpPost]
        public IActionResult Index(BMI bmi)
        {
            bmi.BMIValue =
                bmi.Weight / (bmi.Height * bmi.Height);

            if (bmi.BMIValue < 18.5)
            {
                bmi.Category = "Underweight";

                bmi.WorkoutPlan =
                    "Strength Training, Pushups, Squats, Deadlifts, 4 Days Per Week";

                bmi.DietPlan =
                    "Milk, Banana, Eggs, Paneer, Rice, Chicken, Dry Fruits";
            }
            else if (bmi.BMIValue < 25)
            {
                bmi.Category = "Normal";

                bmi.WorkoutPlan =
                    "Cardio 20 Minutes + Strength Training 5 Days Per Week";

                bmi.DietPlan =
                    "Roti, Rice, Dal, Vegetables, Fruits, Eggs";
            }
            else
            {
                bmi.Category = "Overweight";

                bmi.WorkoutPlan =
                    "Running 30 Minutes, Cycling, Jump Rope, Fat Loss Exercises";

                bmi.DietPlan =
                    "Oats, Salad, Green Vegetables, Fruits, Sprouts, Low Oil Food";
            }

            return View(bmi);
        }
    }
}