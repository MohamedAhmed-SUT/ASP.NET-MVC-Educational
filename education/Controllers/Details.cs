using Education.Models;
using Education.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using education.Models;

namespace Education.Controllers
{
    [Authorize(Roles = clsRoles.roleUser)]
    public class DetailsController : Controller
    {
        private readonly AppDbContext _context;

        public DetailsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DetailsByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                        .ThenInclude(c => c.Department)
                .FirstOrDefaultAsync(s => s.Email == email);

            if (student == null)
            {
                return RedirectToAction("StudentNotFound");
            }

            return View("~/Views/Students/StudentDetails.cshtml", student);
        }

        public IActionResult StudentNotFound()
        {
            return View("~/Views/Students/StudentNotFound.cshtml");
        }
    }
}
