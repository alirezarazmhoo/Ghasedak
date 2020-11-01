using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace Ghasedak.Controllers
{
    [Authorize]

    public class SettingController : Controller
    {
        private readonly Context _context;

        public SettingController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _context.Settings.FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Setting setting)
        {
            ModelState.Remove("id");
            if (ModelState.IsValid)
            {
                if (setting.id == 0)
                {
                    if (setting.logo != null)
                    {
                        string logoPath = "";
                        var name = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(setting.logo.FileName);
                        logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", name);
                        using (var stream = new FileStream(logoPath, FileMode.Create))
                        {
                            setting.logo.CopyTo(stream);
                        }
                        setting.logoName = "/images/" + name;
                    }
                    _context.Add(setting);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    try
                    {
                        var _setting = _context.Settings.FirstOrDefault();
                        if (setting.logo != null)
                        {
                            if (_setting.logoName != null)
                            {
                                string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", _setting.logoName);
                                if (System.IO.File.Exists(deletePath))
                                {
                                    System.IO.File.Delete(deletePath);
                                }
                            }
                            string logoPath = "";
                            var name = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(setting.logo.FileName);
                            logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", name);
                            using (var stream = new FileStream(logoPath, FileMode.Create))
                            {
                                setting.logo.CopyTo(stream);
                            }
                            _setting.logoName = "/images/" + name;

                        }
                        _setting.sherkatName = setting.sherkatName;
                        
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index));


        }
    }
}