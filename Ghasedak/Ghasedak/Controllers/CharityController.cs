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

namespace Ghasedak.Controllers
{
    public class CharityController : Controller
    {
        private readonly Context _context;
        private ICharity _Charity;
        private IHostingEnvironment _hostingEnvironment;

        public CharityController(Context context, ICharity Charity, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _Charity = Charity;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(int page = 1, string filtercode = "", bool isSuccess = false)
        {
            var model = _Charity.GetCharity(page, filtercode);
            if (isSuccess)
                ViewBag.success = "شما قادر به حذف نمی باشید چون درآمد برای این رکورد ثبت شده است";
            return View(model);
        }
        //[Route("Charity/Login")]

        public ActionResult Login()
        {
            return View();
        }




        [HttpPost]
        public async Task<JsonResult> CharityInfo(int ItemId)
        {
            try
            {
                var Charity = await _context.Charitys.FindAsync(ItemId);

                if (Charity == null)
                {
                    return Json(new { success = false, responseText = "درخواست با خطا مواجه شده است  !" });
                }


                List<EditViewModels> edit = new List<EditViewModels>();
                edit.Add(new EditViewModels() { key = "code", value = Charity.code });
                edit.Add(new EditViewModels() { key = "CharityId", value = Charity.id.ToString() });
                edit.Add(new EditViewModels() { key = "userName", value = Charity.userName });
                edit.Add(new EditViewModels() { key = "password", value = Charity.password });
                edit.Add(new EditViewModels() { key = "passwordShow", value = Charity.passwordShow });
                edit.Add(new EditViewModels() { key = "title", value = Charity.title });
                edit.Add(new EditViewModels() { key = "address", value = Charity.address });
                edit.Add(new EditViewModels() { key = "mobile", value = Charity.mobile });
                edit.Add(new EditViewModels() { key = "description", value = Charity.description });
                edit.Add(new EditViewModels() { key = "isActive", value = Charity.isActive.ToString() });
                edit.Add(new EditViewModels() { key = "isAccessBox", value = Charity.isAccessBox.ToString() });
                edit.Add(new EditViewModels() { key = "isAccessSponsor", value = Charity.isAccessSponsor.ToString() });
                edit.Add(new EditViewModels() { key = "isAccessFinancialAid", value = Charity.isAccessFinancialAid.ToString() });
                edit.Add(new EditViewModels() { key = "isAccessFlowerCrown", value = Charity.isAccessFlowerCrown.ToString() });
                return Json(new { success = true, listItem = edit.ToList() });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "درخواست با خطا مواجه شده است !" });
            }
        }
        #region Logout
        
        [HttpPost, ActionName("DeleteAll")]

        public async Task<IActionResult> DeleteAll(int[] ids)
        {

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in ids)
                    {
                        if (_context.BoxIncomes.Any(x => x.charityId == item))
                        {
                            trans.Rollback();
                            return Json("Fail");
                        }
                        else
                        {
                            var Charity = await _context.Charitys.FindAsync(item);
                            _context.Charitys.Remove(Charity);
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
            var Charity = await _context.Charitys.FindAsync(id);
            if (Charity == null)
            {
                return NotFound();
            }
            return View(Charity);
        }





        [HttpPost]
        public async Task<IActionResult> Register(int? id, Charity Charity)
        {
            try
            {
                ModelState.Remove("id");
                ModelState.Remove("isActive");
                ModelState.Remove("isAccessBox");
                ModelState.Remove("isAccessSponsor");
                ModelState.Remove("isAccessFinancialAid");
                ModelState.Remove("isAccessFlowerCrown");
                if (ModelState.IsValid)
                {
                    Charity.password = BCrypt.Net.BCrypt.HashPassword(Charity.passwordShow, BCrypt.Net.BCrypt.GenerateSalt());
                        if (id == null)
                        {
                            if (_context.Charitys.Any(x => x.userName == Charity.userName) || _context.Users.Any(x => x.userName == Charity.userName))
                            {
                                return Json(new { success = false, responseText = "نام کاربری تکراری است !" });

                            }
                            if (_context.Charitys.Any(x => x.code == Charity.code))
                            {
                                return Json(new { success = false, responseText = "کد خیریه تکراری است !" });

                            }
                            _context.Charitys.Add(Charity);
                        }
                        else
                        {
                         if (_context.Charitys.Any(x => x.userName == Charity.userName && x.id!=id)||_context.Users.Any(x => x.userName == Charity.userName))
                            {
                                return Json(new { success = false, responseText = "نام کاربری تکراری است !" });

                            }
                         if (_context.Charitys.Any(x => x.code == Charity.code && x.id!=id))
                            {
                                return Json(new { success = false, responseText = "کد خیریه تکراری است !" });

                            }
                            _context.Charitys.Update(Charity);
                        }
                        await _context.SaveChangesAsync();
                        return Json(new { success = true, responseText = "عملیات با موفقیت انجام شد !" });
                    
                }
                else
                {
                    return Json(new { success = false, responseText = "خطا در انجام عملیات !" });
                }

            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Charity = await _context.Charitys
                .FirstOrDefaultAsync(m => m.id == id);
            if (Charity == null)
            {
                return NotFound();
            }

            return View(Charity);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var Charity = _context.Charitys.FirstOrDefault(x => x.id == id);
                _context.Charitys.Remove(Charity);
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


        public async Task<IActionResult> ExportToExcel(string filterCode = "")
        {
            IQueryable<Charity> result = _context.Charitys.IgnoreQueryFilters().OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filterCode))
            {
                result = result.Where(x => x.code.Contains(filterCode));
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
                    row.CreateCell(2).SetCellValue(item.password);
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