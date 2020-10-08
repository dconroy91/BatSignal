using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneBatSignal.Data;
using CapstoneBatSignal.Models;
using Microsoft.AspNetCore.Identity;

namespace CapstoneBatSignal.Controllers
{
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RequestsController(ApplicationDbContext context,
                                  UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Requests
        public async Task<IActionResult> Index(string batSheet)
        {
            if (batSheet == "TutoringIsTrue")
            {                                                                                      /*where goes here where istutoring condition true*/
                var applicationDbContext = _context.Requests.Include(r => r.InstructorUser).Include(r => r.StudentUser)
                    .Where(r => r.IsTutoring == true
                                && r.IsConfirmed == false);
               //put view data here
                //leave thsi part outside of condtional
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.Requests.Include(r => r.InstructorUser).Include(r => r.StudentUser)
                        .Where(r => r.IsTutoring == false
                                 && r.IsConfirmed == false);
                return View(await applicationDbContext.ToListAsync());
            }

            

            
            //else return same thing
        }
        
            
            //send a little piece of data to signal to let it know you want bat sheet or tutor request

            //asp- route - value [(sends little piece of data to ontroller from a tag to test conditional)

            //first thing - breakpoint line 31, string of batsignal or tutoring, make sure its two different pieces of data.

            //look up  .where - depednint on batsheet param, FormatFilterAttribute out just turoring or batsheet



        

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requests = await _context.Requests
                .Include(r => r.InstructorUser)
                .Include(r => r.StudentUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requests == null)
            {
                return NotFound();
            }

            return View(requests);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            
            ViewData["InstructorUserId"] = new SelectList(_context.User, "Id", "Id");
            ViewData["StudentUserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentUserId,InstructorUserId,Description,DateCreated,DateFinished,IsConfirmed,IsTutoring")] Requests requests)
        {
            ModelState.Remove("requests.InstructorUserId");
            ModelState.Remove("requests.StudentUserId");
            ModelState.Remove("requests.UserId");
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                requests.StudentUserId = user.Id;
                _context.Add(requests);
                await _context.SaveChangesAsync();
                if (requests.IsTutoring == true)
                {
                    return RedirectToAction("Index", new { batSheet = "TutoringIsTrue" });
                }
                return RedirectToAction(nameof(Index));
                /*going to have to redirect if batSignal = true*/
            }

            ViewData["InstructorUserId"] = new SelectList(_context.User, "Id", "Id", requests.InstructorUserId);
            ViewData["StudentUserId"] = new SelectList(_context.User, "Id", "Id", requests.StudentUserId);
            return View(requests);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requests = await _context.Requests.FindAsync(id);
            if (requests == null)
            {
                return NotFound();
            }
            ViewData["InstructorUserId"] = new SelectList(_context.User, "Id", "Id", requests.InstructorUserId);
            ViewData["StudentUserId"] = new SelectList(_context.User, "Id", "Id", requests.StudentUserId);
            return View(requests);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentUserId,InstructorUserId,Description,DateCreated,DateFinished,IsConfirmed,IsTutoring")] Requests requests)
        {
            if (id != requests.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestsExists(requests.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorUserId"] = new SelectList(_context.User, "Id", "Id", requests.InstructorUserId);
            ViewData["StudentUserId"] = new SelectList(_context.User, "Id", "Id", requests.StudentUserId);
            return View(requests);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requests = await _context.Requests
                .Include(r => r.InstructorUser)
                .Include(r => r.StudentUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            //if (requests == null)
            //{
            //    return NotFound();
            //}
            //try
            //{
            //    _context.Requests.Remove(requests);
            //    await _context.SaveChangesAsync();
            //}
            //catch (Exception) when (requests.IsConfirmed == false)
            //{
                requests.IsConfirmed = true;
                _context.Update(requests);
                await _context.SaveChangesAsync();
            if (requests.IsTutoring == true)
            {
                return RedirectToAction("Index", new { batSheet = "TutoringIsTrue" });
            }
            return RedirectToAction(nameof(Index));

            return RedirectToAction(nameof(Index));
        }
        
    //        return View(requests);
    //}

    //POST: Requests/Delete/5
    [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requests = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(requests);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestsExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
