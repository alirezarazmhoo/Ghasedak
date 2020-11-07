using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ghasedak.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ghasedak.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Ghasedak.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Ghasedak.Controllers
{
    public class UserController : Controller
    {
        private readonly Context _context;
        private IUser _user;
        private IHostingEnvironment _hostingEnvironment;

        //private readonly UserManager<User> _userManager;
        public UserController(Context context, IUser user, IHostingEnvironment hostingEnvironment)
        //,UserManager<User> userManager)
        {
            //_userManager = userManager;
            _context = context;
            _user = user;
            _hostingEnvironment = hostingEnvironment;
        }
        //       [HttpGet]
        //public async Task<int> GetCurrentUserId()
        //{
        //	User usr = await GetCurrentUserAsync();
        //	return usr.id;
        //}

        //   private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public IActionResult Index(int page = 1, string filtercellphone = "", bool isSuccess = false)
        {
            var model = _user.GetUsers(page, filtercellphone);
            if (isSuccess)
                ViewBag.success = "شما قادر به حذف نمی باشید چون درآمد برای این رکورد ثبت شده است";
            return View(model);
        }
        //[Route("User/Login")]

        public ActionResult Login()
        {
            return View();
        }
        //[Route("get-captcha-image")]
        //public IActionResult GetCaptchaImage()
        //{
        //    int width = 100;
        //    int height = 36;
        //    var captchaCode = Captcha.GenerateCaptchaCode();
        //    var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
        //    HttpContext.Session.SetString("CaptchaCode", result.CaptchaCode);
        //    Stream s = new MemoryStream(result.CaptchaByteData);
        //    return new FileStreamResult(s, "image/png");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginUserAdmin user)
        {
            //if (!Captcha.ValidateCaptchaCode(user.Captcha, HttpContext))
            //{
            //    ModelState.Clear();
            //    ModelState.AddModelError("", "کپچا صحیح نمی باشد");
            //    return View("Login");
            //}
            if (string.IsNullOrEmpty(user.password) || string.IsNullOrEmpty(user.userName))
            {
                ModelState.Clear();
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                return View("Login");
            }
            var u = _context.Users.Include(x => x.role).Where(p => p.userName == user.userName && p.role.RoleNameEn == "Admin").FirstOrDefault();
            var charity = _context.Charitys.Where(p => p.userName == user.userName).FirstOrDefault();
            if (u == null && charity == null)
            {
                ModelState.Clear();
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                return View("Login");
            }
            if (u != null && charity == null)
            {
                if (!BCrypt.Net.BCrypt.Verify(user.password, u.password))
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                    return View("Login");
                }
                else
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.userName.ToString()),
                        new Claim(ClaimTypes.Name,user.userName),
                        new Claim(ClaimTypes.Role,"Admin")
                        
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = user.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    return Redirect("/Home/Index");
                }
            }
            if (u == null && charity != null)
            {
                if (!BCrypt.Net.BCrypt.Verify(user.password, charity.password))
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                    return View("Login");
                }
                else
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,charity.id.ToString()),
                        new Claim(ClaimTypes.Name,charity.id.ToString()),
                        new Claim(ClaimTypes.Role,"Charity")
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = user.RememberMe
                        
                        
                    };
                    HttpContext.SignInAsync(principal, properties);

                    return Redirect("/Home/IndexCharity");
                }


            }
            return View("Login");
        }


        

        public ActionResult SignInAsCharity(string userName,string password)
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var charity = _context.Charitys.Where(p => p.userName == userName).FirstOrDefault();
            if (charity == null)
            {
                ModelState.Clear();
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                return View("Login");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, charity.password))
            {
                ModelState.Clear();
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                return View("Login");
            }
            else
            {
                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,charity.id.ToString()),
                        new Claim(ClaimTypes.Name,charity.id.ToString()),
                        new Claim(ClaimTypes.Role,"Charity")

                    };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

                return Redirect("/Home/IndexCharity");
            }
        }

        [HttpPost]
        public async Task<JsonResult> UserInfo(int ItemId)
        {
            try
            {
                var user = await _context.Users.FindAsync(ItemId);

                if (user == null)
                {
                    return Json(new { success = false, responseText = "Requset Faild !" });
                }
                List<EditViewModels> edit = new List<EditViewModels>();
                edit.Add(new EditViewModels() { key = "code", value = user.code });
                edit.Add(new EditViewModels() { key = "UserId", value = user.id.ToString() });
                edit.Add(new EditViewModels() { key = "roleId", value = user.roleId.ToString() });
                edit.Add(new EditViewModels() { key = "passwordShow", value = user.passwordShow });
                edit.Add(new EditViewModels() { key = "password", value = user.password });
                edit.Add(new EditViewModels() { key = "fullName", value = user.fullName });
                edit.Add(new EditViewModels() { key = "userName", value = user.userName });
                edit.Add(new EditViewModels() { key = "token", value = user.token });

                return Json(new { success = true, listItem = edit.ToList() });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }
        #region Logout


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/User/Login");
        }
        [HttpPost, ActionName("DeleteAll")]

        public async Task<IActionResult> DeleteAll(int[] ids)
        {

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in ids)
                    {
                        if (_context.BoxIncomes.Any(x => x.userId == item))
                        {
                            trans.Rollback();
                            return Json("Fail");
                        }
                        else
                        {
                            var User = await _context.Users.FindAsync(item);
                            _context.Users.Remove(User);
                        }
                    }
                    _context.SaveChanges();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return Json("Fail");
                }
            }
            return Json("Success");

        }

        #endregion

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult AdminUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminUser(UserAdmin userAdmin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _context.Users.Include(x => x.role).FirstOrDefault(x => x.role.RoleNameEn == "Admin" && x.passwordShow == userAdmin.passwordShow);
                    if (user == null)
                    {
                        ModelState.AddModelError("passwordShow", "رمز عبور فعلی نا معتبر است");
                        return View();
                    }
                    else
                    {
                        user.passwordShow = userAdmin.newPasswordShow;
                        user.password = BCrypt.Net.BCrypt.HashPassword(userAdmin.newPasswordShow, BCrypt.Net.BCrypt.GenerateSalt());
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                ViewData["passwordChanged"] = "رمز عبور تغییر یافت";
                return View();
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(int? id, User user)
        {
            try
            {
                ModelState.Remove("id");
                ModelState.Remove("roleId");
                if (ModelState.IsValid)
                {
                    user.password = BCrypt.Net.BCrypt.HashPassword(user.passwordShow, BCrypt.Net.BCrypt.GenerateSalt());

                    if (id == null)
                    {
                        if (_context.Users.Any(x => x.userName == user.userName))
                        {
                            return Json(new { success = false, responseText = "نام کاربری تکراری است !" });

                        }
                        var role = _context.Roles.FirstOrDefault(x => x.RoleNameEn == "Member");
                        user.roleId = role.Id;
                        user.token = Guid.NewGuid().ToString().Replace("-", "");
                        _context.Users.Add(user);
                    }
                    else
                    {
                        if (_context.Users.Any(x => x.userName == user.userName && x.id != id))
                        {
                            return Json(new { success = false, responseText = "نام کاربری تکراری است !" });

                        }
                        _context.Users.Update(user);
                    }
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, responseText = "Operation Completed !" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Required Fields Are Empty !" });
                }

            }
            catch (Exception)
            {

                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }

        [HttpPost]
        public IActionResult InActive(int id)
        {
            try
            {
                var user = _context.Users.IgnoreQueryFilters().FirstOrDefault(x => x.id == id);
                //if (user.isActive == true)
                //    user.isActive = false;
                //else
                //    user.isActive = true;

                _context.SaveChanges();
                return Json("Done");
            }
            catch (Exception ex)
            {
                return Json("Fail");
            }
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.id == id);
                _context.Users.Remove(user);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Index));
                return Json(new { success = true, responseText = "Operation Completed !" });


            }
            catch (Exception ex)
            {
                //return RedirectToAction("Index", new { @isSuccess = true });
                return Json(new { success = false, responseText = "Requset Faild !" });

            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                user.password = BCrypt.Net.BCrypt.HashPassword(user.passwordShow, BCrypt.Net.BCrypt.GenerateSalt());
                var role = _context.Roles.FirstOrDefault(x => x.RoleNameEn == "Member");
                user.roleId = role.Id;
                user.token = Guid.NewGuid().ToString().Replace("-", "");
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> ExportToExcel(string filteruserName = "")
        {
            IQueryable<User> result = _context.Users.IgnoreQueryFilters().Where(x => x.role.RoleNameEn == "Member").OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filteruserName))
            {
                result = result.Where(x => x.userName.Contains(filteruserName));
            }
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"demo.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Demo");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("ردیف");
                row.CreateCell(1).SetCellValue("نام کاربری");
                row.CreateCell(2).SetCellValue("رمز عبور");
                row.CreateCell(3).SetCellValue("کد");
                int count = 1;
                foreach (var item in result)
                {
                    row = excelSheet.CreateRow(count);
                    row.CreateCell(0).SetCellValue(count);
                    row.CreateCell(1).SetCellValue(item.userName);
                    row.CreateCell(2).SetCellValue(item.passwordShow);
                    row.CreateCell(3).SetCellValue(item.code);
                    count++;
                }
                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);

        }
    }
}