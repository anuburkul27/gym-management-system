using Microsoft.AspNetCore.Mvc;
using GymManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymManagementSystem.Controllers
{
    public class PaymentsController : Controller
    {
        public static List<Payment> payments = new List<Payment>()
        {
            new Payment
            {
                Id = 1,
                MemberName = "Rahul",
                Amount = 2000,
                PaymentDate = DateTime.Now
            }
        };

        // Payment History
        public IActionResult Index()
        {
            return View(payments);
        }

        // Open Add Payment Page
        public IActionResult Create()
        {
            return View();
        }

        // Save Payment
        [HttpPost]
        public IActionResult Create(Payment payment)
        {
            payment.Id = payments.Count + 1;

            payments.Add(payment);

            return RedirectToAction("Index");
        }

        // Delete Payment
        public IActionResult Delete(int id)
        {
            var payment = payments.FirstOrDefault(x => x.Id == id);

            if (payment != null)
            {
                payments.Remove(payment);
            }

            return RedirectToAction("Index");
        }

        // Open Edit Page
        public IActionResult Edit(int id)
        {
            var payment = payments.FirstOrDefault(x => x.Id == id);

            if (payment == null)
            {
                return RedirectToAction("Index");
            }

            return View(payment);
        }

        // Update Payment
        [HttpPost]
        public IActionResult Edit(Payment payment)
        {
            var data = payments.FirstOrDefault(x => x.Id == payment.Id);

            if (data != null)
            {
                data.MemberName = payment.MemberName;
                data.Amount = payment.Amount;

                // DO NOT update PaymentDate
                // Original payment date remains fixed
            }

            return RedirectToAction("Index");
        }
    }
}