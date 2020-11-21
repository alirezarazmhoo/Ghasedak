using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Models.ViewModel;
using Ghasedak.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PagedList.Core;

namespace Ghasedak.Controllers
{
    public class UserActivityController : Controller
    {
        private IUserActivity _UserActivity;
        private readonly Context _context;
        private IHostingEnvironment _hostingEnvironment;

        public UserActivityController(IUserActivity UserActivity, Context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _UserActivity = UserActivity;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
              int charityId = Convert.ToInt32(User.Identity.Name);

            var model = _UserActivity.GetUserActivity(charityId,page);
            
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Create(UserActivity UserActivity)
        {
            if (!ModelState.IsValid)
            {
                return View(UserActivity);
            }
            else
            {
                _context.UserActivities.Add(UserActivity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        private bool UserActivityExists(int id)
        {
            return _context.UserActivities.Any(e => e.id == id);
        }



        public async Task<IActionResult> GetUserActivity(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var UserActivity = await _context.UserActivities.FindAsync(id);
            if (UserActivity == null)
            {
                return NotFound();
            }
            return Json(UserActivity);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.UserActivities.Include(x=>x.oprator).FirstOrDefaultAsync(x=>x.id==id);


            if (box == null)
            {
                return NotFound();
            }
            return View(box);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserActivity UserActivity)
        {
            if (id != UserActivity.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(UserActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(UserActivity);
        }

      
       
    }
}