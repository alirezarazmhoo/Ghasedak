using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Ghasedak.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Ghasedak.ViewModel;

namespace Ghasedak.Controllers
{
    public class FlowerCrownController : Controller
    {
        private readonly Context _context;
        private IFlowerCrown _FlowerCrown;
        private readonly IHostingEnvironment environment;

        public FlowerCrownController(Context context, IFlowerCrown FlowerCrown, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _FlowerCrown = FlowerCrown;
        }
        // GET: Products
        public IActionResult Index(int page = 1, bool isSuccess = false)
        {
            int charityId = Convert.ToInt32(User.Identity.Name);

            var model = _FlowerCrown.GetFlowerCrown(charityId, page);
            if (isSuccess)
                ViewBag.success = "شما قادر به حذف نمی باشید ";
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FlowerCrownAdminViewModel FlowerCrownAdminViewModel = _FlowerCrown.GetDataForAdmin(id);
            if (FlowerCrownAdminViewModel == null)
            {
                return NotFound();
            }
            return View(FlowerCrownAdminViewModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FlowerCrown FlowerCrown)
        {
            if (id != FlowerCrown.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(FlowerCrown);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(FlowerCrown);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var FlowerCrown = _context.FlowerCrowns.FirstOrDefault(x => x.id == id);
                _context.FlowerCrowns.Remove(FlowerCrown);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Index));
                return Json(new { success = true, responseText = "عملیات با موفقیت انجام شد !" });


            }
            catch (Exception ex)
            {
                //return RedirectToAction("Index", new { @isSuccess = true });
                return Json(new { success = false, responseText = "خطا در حذف رکورد !" });

            }
        }


        public async Task<IActionResult> ExportToExcel()
        {
            IQueryable<FlowerCrown> result = _context.FlowerCrowns.Include(x => x.FlowerCrownType).OrderByDescending(x => x.id);


            string sWebRootFolder = environment.WebRootPath;
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
                //row.CreateCell(1).SetCellValue("Name");
                //row.CreateCell(2).SetCellValue("Mobile");
                //row.CreateCell(3).SetCellValue("Code");
                //row.CreateCell(4).SetCellValue("Address");
                //row.CreateCell(0).SetCellValue("CashCode");
                //row.CreateCell(1).SetCellValue("OfficerCode");
                //row.CreateCell(2).SetCellValue("Price");
                //row.CreateCell(3).SetCellValue("StatusIncome");

                int count = 1;
                foreach (var item in result)
                {
                    row = excelSheet.CreateRow(count);
                    //row.CreateCell(0).SetCellValue(count);
                    //row.CreateCell(1).SetCellValue(item.box.fullName);
                    //row.CreateCell(1).SetCellValue(item.user.code);
                    //row.CreateCell(2).SetCellValue(item.box.mobile);
                    //row.CreateCell(3).SetCellValue(item.box.number);
                    //row.CreateCell(4).SetCellValue(item.box.address);
                    //row.CreateCell(0).SetCellValue(count);
                    //row.CreateCell(0).SetCellValue(item.);
                    //row.CreateCell(1).SetCellValue(item.oprator.code);
                    //row.CreateCell(2).SetCellValue(Convert.ToInt64(item.price));
                    //row.CreateCell(3).SetCellValue(((int)item.status).ToString());
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var FlowerCrown = await _context.FlowerCrowns
                .FirstOrDefaultAsync(m => m.id == id);
            if (FlowerCrown == null)
            {
                return NotFound();
            }

            return View(FlowerCrown);
        }

        // POST: Sliders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        var FlowerCrown = await _context.FlowerCrowns.FindAsync(id);



        //        _context.FlowerCrowns.Remove(FlowerCrown);
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
                    foreach (var item in ids)
                    {
                        var Income = await _context.FlowerCrowns.FindAsync(item);

                        _context.FlowerCrowns.Remove(Income);

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

        public ActionResult OnPostImport()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = environment.WebRootPath;
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
                                var FlowerCrown = new FlowerCrown();
                                //if (_context.DischargeRoutes.Any(x => x.code == row.GetCell(0).ToString()))
                                //    continue;
                                //FlowerCrown.lon = 0;
                                //FlowerCrown.lat = 0;
                                //var price = row.GetCell(2).NumericCellValue;
                                //FlowerCrown.price = Convert.ToInt64(price);
                                //var oprator = _context.Oprators.Where(p => p.code == row.GetCell(1).ToString()).FirstOrDefault();
                                //if (oprator == null)
                                //    continue;
                                //FlowerCrown.opratorId = oprator.id;
                                //var status = row.GetCell(3).NumericCellValue;
                                //FlowerCrown.status = (EnumStatus)status;
                                //FlowerCrown.registerDate = PersianCalendarDate.PersianCalendarResult(DateTime.Now);
                                //var box = _context.Boxs.FirstOrDefault(x => x.number == row.GetCell(0).ToString());
                                //if (box == null)
                                //    continue;
                                //FlowerCrown.boxId = box.id;
                                _context.FlowerCrowns.Add(FlowerCrown);
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