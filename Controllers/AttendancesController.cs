using GymManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        static List<Attendance> attendanceList = new List<Attendance>()
        {
            new Attendance
            {
                Id = 1,
                MemberName = "Rahul",
                Date = DateTime.Now,
                Status = -1
            },

            new Attendance
            {
                Id = 2,
                MemberName = "Sneha",
                Date = DateTime.Now,
                Status = -1
            }
        };

        public IActionResult Index()
        {
            return View(attendanceList);
        }

        public IActionResult MarkPresent(int id)
        {
            var member = attendanceList.FirstOrDefault(x => x.Id == id);

            if (member != null)
            {
                member.Status = 1;
            }

            return RedirectToAction("Index");
        }

        public IActionResult MarkAbsent(int id)
        {
            var member = attendanceList.FirstOrDefault(x => x.Id == id);

            if (member != null)
            {
                member.Status = 0;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Attendance attendance)
        {
            attendance.Id = attendanceList.Count + 1;

            attendance.Date = DateTime.Now;

            attendance.Status = -1;

            attendanceList.Add(attendance);

            return RedirectToAction("Index");
        }
        public IActionResult GenerateQR(string memberName)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData =
                qrGenerator.CreateQrCode(
                memberName,
                QRCodeGenerator.ECCLevel.Q);

            PngByteQRCode qrCode =
                new PngByteQRCode(qrCodeData);

            byte[] qrCodeImage =
                qrCode.GetGraphic(20);

            return File(qrCodeImage, "image/png");
        }
    }
}
    