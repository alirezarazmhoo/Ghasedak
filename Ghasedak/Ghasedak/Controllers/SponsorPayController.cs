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

namespace Ghasedak.Controllers
{
    public class SponsorPayController : Controller
    {
        private readonly Context _context;
        private ISponsorPay _SponsorPay;
        private readonly IHostingEnvironment environment;

        public SponsorPayController(Context context, ISponsorPay SponsorPay, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _SponsorPay = SponsorPay;
        }
        // GET: Products
        public IActionResult Index(int page = 1, bool isSuccess = false)
        {
              int charityId = Convert.ToInt32(User.Identity.Name);

            var model = _SponsorPay.GetSponsorPay(charityId,page);
            if (isSuccess)
                ViewBag.success = "شما قادر به حذف نمی باشید ";
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SponsorPay = _context.SponsorPays.Include(x => x.Sponsor).FirstOrDefault(x => x.id == id);
            if (SponsorPay == null)
            {
                return NotFound();
            }
            return View(SponsorPay);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SponsorPay SponsorPay)
        {
            if (id != SponsorPay.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(SponsorPay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(SponsorPay);
        }

         [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var SponsorPay = _context.SponsorPays.FirstOrDefault(x => x.id == id);
                var Sponsor = _context.Sponsors.FirstOrDefault(x => x.id == SponsorPay.sponsorId);
                _context.SponsorPays.Remove(SponsorPay);
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
            IQueryable<SponsorPay> result = _context.SponsorPays.Include(x => x.Sponsor).OrderByDescending(x => x.id);


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
                row.CreateCell(0).SetCellValue("price");
                row.CreateCell(1).SetCellValue("recieverCode");
                row.CreateCell(2).SetCellValue("terminalCode");
                row.CreateCell(3).SetCellValue("deviceCode");
            

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
                    row.CreateCell(0).SetCellValue(item.price.ToString());
                    row.CreateCell(1).SetCellValue(item.recieverCode);
                    row.CreateCell(2).SetCellValue(item.terminalCode);
                    row.CreateCell(3).SetCellValue(item.deviceCode);
                    
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

            var SponsorPay = await _context.SponsorPays
                .FirstOrDefaultAsync(m => m.id == id);
            if (SponsorPay == null)
            {
                return NotFound();
            }

            return View(SponsorPay);
        }

        // POST: Sliders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        var SponsorPay = await _context.SponsorPays.FindAsync(id);



        //        _context.SponsorPays.Remove(SponsorPay);
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
                        var Income = await _context.SponsorPays.FindAsync(item);

                        _context.SponsorPays.Remove(Income);

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
                                var SponsorPay = new SponsorPay();
                                //if (_context.DischargeRoutes.Any(x => x.code == row.GetCell(0).ToString()))
                                //    continue;
                                //SponsorPay.lon = 0;
                                //SponsorPay.lat = 0;
                                //var price = row.GetCell(2).NumericCellValue;
                                //SponsorPay.price = Convert.ToInt64(price);
                                //var oprator = _context.Oprators.Where(p => p.code == row.GetCell(1).ToString()).FirstOrDefault();
                                //if (oprator == null)
                                //    continue;
                                //SponsorPay.opratorId = oprator.id;
                                //var status = row.GetCell(3).NumericCellValue;
                                //SponsorPay.status = (EnumStatus)status;
                                //SponsorPay.registerDate = PersianCalendarDate.PersianCalendarResult(DateTime.Now);
                                //var box = _context.Boxs.FirstOrDefault(x => x.number == row.GetCell(0).ToString());
                                //if (box == null)
                                //    continue;
                                //SponsorPay.boxId = box.id;
                                _context.SponsorPays.Add(SponsorPay);
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