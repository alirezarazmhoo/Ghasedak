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
using System.Data.SqlClient;

namespace Ghasedak.Controllers
{
    public class OpratorController : Controller
    {
        private readonly Context _context;
        private IOprator _Oprator;
        private IHostingEnvironment _hostingEnvironment;

        //private readonly OpratorManager<Oprator> _OpratorManager;
        public OpratorController(Context context, IOprator Oprator, IHostingEnvironment hostingEnvironment)
        //,OpratorManager<Oprator> OpratorManager)
        {
            //_OpratorManager = OpratorManager;
            _context = context;
            _Oprator = Oprator;
            _hostingEnvironment = hostingEnvironment;
        }
        //       [HttpGet]
        //public async Task<int> GetCurrentOpratorId()
        //{
        //	Oprator usr = await GetCurrentOpratorAsync();
        //	return usr.id;
        //}

        //   private Task<Oprator> GetCurrentOpratorAsync() => _OpratorManager.GetOpratorAsync(HttpContext.Oprator);
        public IActionResult Index(int page = 1, string filtercellphone = "", bool isSuccess = false)
        {
              int charityId = Convert.ToInt32(User.Identity.Name);

            var model = _Oprator.GetOprators(charityId,page, filtercellphone);
            if (isSuccess)
                ViewBag.success = "شما قادر به حذف نمی باشید چون درآمد برای این رکورد ثبت شده است";
            return View(model);
        }
        //[Route("Oprator/Login")]

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> OpratorInfo(int ItemId)
        {
            try
            {
                var Oprator = await _context.Oprators.FindAsync(ItemId);

                if (Oprator == null)
                {
                    return Json(new { success = false, responseText = "Requset Faild !" });
                }
                List<EditViewModels> edit = new List<EditViewModels>();
                edit.Add(new EditViewModels() { key = "code", value = Oprator.code });
                edit.Add(new EditViewModels() { key = "OpratorId", value = Oprator.id.ToString() });
                edit.Add(new EditViewModels() { key = "userName", value = Oprator.userName });
                edit.Add(new EditViewModels() { key = "mobile", value = Oprator.mobile });
                edit.Add(new EditViewModels() { key = "passwordShow", value = Oprator.passwordShow });
                edit.Add(new EditViewModels() { key = "password", value = Oprator.password });
                edit.Add(new EditViewModels() { key = "fullName", value = Oprator.fullName });
                edit.Add(new EditViewModels() { key = "token", value = Oprator.token });
                edit.Add(new EditViewModels() { key = "isActive", value = Oprator.isActive.ToString() });

                return Json(new { success = true, listItem = edit.ToList() });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(int? id, Oprator Oprator)
        {
            try
            {
                ModelState.Remove("id");

                Oprator.charityId = Convert.ToInt32(User.Identity.Name);
                if (ModelState.IsValid)
                {
                    Oprator.password = BCrypt.Net.BCrypt.HashPassword(Oprator.passwordShow, BCrypt.Net.BCrypt.GenerateSalt());

                    if (id == null)
                    {
                        Oprator.token = Guid.NewGuid().ToString().Replace('-', '0');

                        if (_context.Oprators.Any(x => x.userName == Oprator.userName))
                        {
                            return Json(new { success = false, responseText = "نام کاربری تکراری است !" });
                        }
                        _context.Oprators.Add(Oprator);
                    }
                    else
                    {
                        if (_context.Oprators.Any(x => x.userName == Oprator.userName && x.id != id))
                        {
                            return Json(new { success = false, responseText = "نام کاربری تکراری است !" });
                        }
                        _context.Oprators.Update(Oprator);
                    }
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, responseText = "موفقیت آمیز !" });
                }
                else
                {
                    return Json(new { success = false, responseText = "مقادیر وارد شده نامعتبر است !" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "خطا در انجام عملیات !" });
            }
        }

        [HttpPost]
        public IActionResult InActive(int id)
        {
            try
            {
                var Oprator = _context.Oprators.IgnoreQueryFilters().FirstOrDefault(x => x.id == id);
                //if (Oprator.isActive == true)
                //    Oprator.isActive = false;
                //else
                //    Oprator.isActive = true;

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

            var Oprator = await _context.Oprators
                .FirstOrDefaultAsync(m => m.id == id);
            if (Oprator == null)
            {
                return NotFound();
            }

            return View(Oprator);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var Oprator = _context.Oprators.FirstOrDefault(x => x.id == id);
                _context.Oprators.Remove(Oprator);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Index));
                return Json(new { success = true, responseText = "عملیات با موفقیت انجام شد !" });


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



        public async Task<IActionResult> ExportToExcel(string filterOpratorName = "")
        {
            IQueryable<Oprator> result = _context.Oprators.OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filterOpratorName))
            {
                result = result.Where(x => x.userName.Contains(filterOpratorName));
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