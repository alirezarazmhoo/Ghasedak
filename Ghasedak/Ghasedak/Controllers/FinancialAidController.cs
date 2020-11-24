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
    public class FinancialAidController : Controller
    {
        private readonly Context _context;
        private IFinancialAid _FinancialAid;
        private readonly IHostingEnvironment environment;

        public FinancialAidController(Context context, IFinancialAid FinancialAid, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _FinancialAid = FinancialAid;
        }
        // GET: Products
        public IActionResult Index(int page = 1, string filtername = "", bool isSuccess = false)
        {
            int charityId = Convert.ToInt32(User.Identity.Name);

            var model = _FinancialAid.GetFinancialAidFromAdmin(charityId, page,filtername);
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
            FinancialAidAdminViewModel FinancialAidAdminViewModel = _FinancialAid.GetDataForAdmin(id);
            if (FinancialAidAdminViewModel == null)
            {
                return NotFound();
            }
            return View(FinancialAidAdminViewModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FinancialAid FinancialAid)
        {
            if (id != FinancialAid.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(FinancialAid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(FinancialAid);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var FinancialAid = _context.FinancialAids.FirstOrDefault(x => x.id == id);
                _context.FinancialAids.Remove(FinancialAid);
                _context.SaveChanges();
                return Json(new { success = true, responseText = "عملیات با موفقیت انجام شد !" });


            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "خطا در حذف رکورد !" });

            }
        }


        public async Task<IActionResult> ExportToExcel()
        {
            IQueryable<FinancialAid> result = _context.FinancialAids.Include(x => x.FinancialServiceType).OrderByDescending(x => x.id);


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
                

                int count = 1;
                foreach (var item in result)
                {
                    row = excelSheet.CreateRow(count);
                    
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

            var FinancialAid = await _context.FinancialAids
                .FirstOrDefaultAsync(m => m.id == id);
            if (FinancialAid == null)
            {
                return NotFound();
            }

            return View(FinancialAid);
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
                        var Income = await _context.FinancialAids.FindAsync(item);

                        _context.FinancialAids.Remove(Income);

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
                                var FinancialAid = new FinancialAid();
                                _context.FinancialAids.Add(FinancialAid);
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