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
    public class DischargeRouteController : Controller
    {
        private IDischargeRoute _DischargeRoute;
        private readonly Context _context;
        private IHostingEnvironment _hostingEnvironment;

        public DischargeRouteController(IDischargeRoute DischargeRoute, Context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _DischargeRoute = DischargeRoute;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index(int page = 1, string filtercode = "", bool isSuccess = false)
        {
            int charityId = Convert.ToInt32(User.Identity.Name);

            var model = _DischargeRoute.GetDischargeRoute(charityId, page, filtercode);
            if (isSuccess)
                ViewBag.success = "شما قادر به حذف نمی باشید چون صندوق یا درآمد برای این رکورد ثبت شده است";
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> DischargeRouteInfo(int ItemId)
        {
            try
            {
                var dischargeRoute = await _context.DischargeRoutes.FindAsync(ItemId);
                var oprator = await _context.Oprators.FirstOrDefaultAsync(x => x.id == dischargeRoute.opratorId);

                if (dischargeRoute == null)
                {
                    return Json(new { success = false, responseText = "Requset Faild !" });
                }
                List<EditViewModels> edit = new List<EditViewModels>();
                edit.Add(new EditViewModels() { key = "code", value = dischargeRoute.code });
                edit.Add(new EditViewModels() { key = "address", value = dischargeRoute.address });
                edit.Add(new EditViewModels() { key = "charityId", value = dischargeRoute.charityId.ToString() });
                edit.Add(new EditViewModels() { key = "day", value = dischargeRoute.day.ToString() });
                edit.Add(new EditViewModels() { key = "DischargeRouteId", value = dischargeRoute.id.ToString() });
                edit.Add(new EditViewModels() { key = "guidDischargeRoute", value = dischargeRoute.guidDischargeRoute.ToString() });

                if (oprator != null)
                {
                    edit.Add(new EditViewModels() { key = "codeOprator", value = oprator.code });
                    edit.Add(new EditViewModels() { key = "mobileOprator", value = oprator.mobile });
                    edit.Add(new EditViewModels() { key = "fullnameOprator", value = oprator.fullName });
                    edit.Add(new EditViewModels() { key = "opratorId", value = oprator.id.ToString() });
                }
                else
                    edit.Add(new EditViewModels() { key = "codeOprator", value = "" });


                return Json(new { success = true, listItem = edit.ToList() });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(int? id, DischargeRoute dischargeRoute)
        {
            try
            {
                ModelState.Remove("id");
                ModelState.Remove("charityId");
                ModelState.Remove("guidDischargeRoute");
                if (ModelState.IsValid)
                {
                    int charityId = Convert.ToInt32(User.Identity.Name);
                    dischargeRoute.charityId = charityId;
                    if (id == null)
                    {
                        if (_context.DischargeRoutes.Any(x => x.code == dischargeRoute.code && x.charityId == charityId))
                        {
                            return Json(new { success = false, responseText = "کد مسیر تکراری است !" });

                        }
                        dischargeRoute.guidDischargeRoute = Guid.NewGuid();
                        _context.DischargeRoutes.Add(dischargeRoute);
                    }
                    else
                    {
                        if (_context.DischargeRoutes.Any(x => x.code == dischargeRoute.code && x.charityId == charityId && x.id != id))
                        {
                            return Json(new { success = false, responseText = "کد مسیر تکراری است !" });

                        }
                        _context.DischargeRoutes.Update(dischargeRoute);
                    }
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, responseText = "عملیات با موفقیت انجام شد !" });
                }
                else
                {
                    return Json(new { success = false, responseText = "لطفا تمام موارد را وارد نمایید !" });
                }

            }
            catch (Exception)
            {

                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Create(DischargeRoute DischargeRoute)
        {
            if (!ModelState.IsValid)
            {
                return View(DischargeRoute);
            }
            else
            {
                _context.DischargeRoutes.Add(DischargeRoute);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        private bool DischargeRouteExists(int id)
        {
            return _context.DischargeRoutes.Any(e => e.id == id);
        }



        public async Task<IActionResult> GetDischargeRoute(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var DischargeRoute = await _context.DischargeRoutes.FindAsync(id);
            if (DischargeRoute == null)
            {
                return NotFound();
            }
            return Json(DischargeRoute);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.DischargeRoutes.FindAsync(id);


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
        public async Task<IActionResult> Edit(int id, DischargeRoute DischargeRoute)
        {
            if (id != DischargeRoute.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(DischargeRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(DischargeRoute);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.DischargeRoutes
                .FirstOrDefaultAsync(m => m.id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var DischargeRoute = _context.DischargeRoutes.FirstOrDefault(x => x.id == id);
                _context.DischargeRoutes.Remove(DischargeRoute);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Index));
                return Json(new { success = true, responseText = "عملیات با موفقیت انجام شد !" });


            }
            catch (Exception ex)
            {
                //return RedirectToAction("Index", new { @isSuccess = true });
                return Json(new { success = false, responseText = "شما قادر به حذف نمی باشید چون صندوق یا درآمد برای این رکورد ثبت شده است !" });

            }
        }
        // POST: Sliders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        var DischargeRoute = await _context.DischargeRoutes.FindAsync(id);



        //        _context.DischargeRoutes.Remove(DischargeRoute);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("Index", new { @isSuccess = true });

        //    }
        //    return RedirectToAction(nameof(Index));
        //}
        [HttpPost, ActionName("DeleteAll")]

        public async Task<IActionResult> DeleteAll(int[] ids)
        {

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    //string[] values =  ids.Split(',');
                    foreach (var item in ids)
                    {
                        var DischargeRoute = await _context.DischargeRoutes.FindAsync(item);

                        _context.DischargeRoutes.Remove(DischargeRoute);

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


        public async Task<IActionResult> ExportToExcel(string filtercode = "")
        {
            IQueryable<DischargeRoute> result = _context.DischargeRoutes.OrderByDescending(x => x.id);

            if (!string.IsNullOrEmpty(filtercode))
            {
                result = result.Where(x => x.code.Contains(filtercode));
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
                excelSheet.IsRightToLeft = true;

                //row.CreateCell(0).SetCellValue("ردیف");
                row.CreateCell(0).SetCellValue("Code");
                row.CreateCell(1).SetCellValue("Address");
                row.CreateCell(2).SetCellValue("DischargeDate");
                int count = 1;
                foreach (var item in result)
                {
                    row = excelSheet.CreateRow(count);
                    //row.CreateCell(0).SetCellValue(count);
                    row.CreateCell(0).SetCellValue(item.code);
                    row.CreateCell(1).SetCellValue(item.address);
                    row.CreateCell(2).SetCellValue(item.day.ToString());
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
        public ActionResult OnPostImport()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    using (var trans = _context.Database.BeginTransaction())
                    {
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                        {
                            try
                            {
                                IRow row = sheet.GetRow(i);
                                if (row == null) continue;
                                if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                                var dischargeRoute = new DischargeRoute();
                                if (_context.DischargeRoutes.Any(x => x.code == row.GetCell(0).ToString()))
                                    continue;
                                dischargeRoute.code = row.GetCell(0).ToString();
                                dischargeRoute.address = row.GetCell(1).ToString();
                                var day = row.GetCell(2).NumericCellValue;
                                dischargeRoute.day = Convert.ToInt32(day);
                                _context.DischargeRoutes.Add(dischargeRoute);
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                            }
                        }
                        _context.SaveChanges();
                        trans.Commit();
                    }
                }
            }
            return this.Content("Success");
        }
    }
}