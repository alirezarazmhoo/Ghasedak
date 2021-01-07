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
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]

    public class FinancialServiceTypeController : Controller
    {
        private IFinancialServiceType _FinancialServiceType;
        private readonly Context _context;
        private IHostingEnvironment _hostingEnvironment;

        public FinancialServiceTypeController(IFinancialServiceType FinancialServiceType, Context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _FinancialServiceType = FinancialServiceType;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index(int page = 1, string filtertitle = "", bool isSuccess = false)
        {
              int charityId = Convert.ToInt32(User.Identity.Name);

            var model = _FinancialServiceType.GetFinancialServiceType(charityId,page, filtertitle);
            if (isSuccess)
                ViewBag.success = "شما قادر به حذف نمی باشید چون کمک نقدی برای این رکورد ثبت شده است";
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> FinancialServiceTypeInfo(int ItemId)
        {
            try
            {
                var FinancialServiceType = await _context.FinancialServiceTypes.FindAsync(ItemId);

                if (FinancialServiceType == null)
                {
                    return Json(new { success = false, responseText = "Requset Faild !" });
                }
                List<EditViewModels> edit = new List<EditViewModels>();
                edit.Add(new EditViewModels() { key = "title", value = FinancialServiceType.title });
                edit.Add(new EditViewModels() { key = "charityId", value = FinancialServiceType.charityId.ToString() });
                edit.Add(new EditViewModels() { key = "FinancialServiceTypeId", value = FinancialServiceType.id.ToString() });


                return Json(new { success = true, listItem = edit.ToList() });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "Requset Faild !" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(int? id, FinancialServiceType FinancialServiceType)
        {
            try
            {
                ModelState.Remove("id");
                ModelState.Remove("charityId");
                if (ModelState.IsValid)
                {
                    int charityId = Convert.ToInt32(User.Identity.Name);
                    FinancialServiceType.charityId = charityId;
                    if (id == null)
                    {
                       

                        _context.FinancialServiceTypes.Add(FinancialServiceType);
                    }
                    else
                    {
                        
                        _context.FinancialServiceTypes.Update(FinancialServiceType);
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
        public IActionResult Create(FinancialServiceType FinancialServiceType)
        {
            if (!ModelState.IsValid)
            {
                return View(FinancialServiceType);
            }
            else
            {
                _context.FinancialServiceTypes.Add(FinancialServiceType);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        private bool FinancialServiceTypeExists(int id)
        {
            return _context.FinancialServiceTypes.Any(e => e.id == id);
        }



        public async Task<IActionResult> GetFinancialServiceType(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var FinancialServiceType = await _context.FinancialServiceTypes.FindAsync(id);
            if (FinancialServiceType == null)
            {
                return NotFound();
            }
            return Json(FinancialServiceType);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.FinancialServiceTypes.FindAsync(id);


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
        public async Task<IActionResult> Edit(int id, FinancialServiceType FinancialServiceType)
        {
            if (id != FinancialServiceType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(FinancialServiceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(FinancialServiceType);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.FinancialServiceTypes
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
                var FinancialServiceType = _context.FinancialServiceTypes.FirstOrDefault(x => x.id == id);
                _context.FinancialServiceTypes.Remove(FinancialServiceType);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Index));
                return Json(new { success = true, responseText = "عملیات با موفقیت انجام شد !" });


            }
            catch (Exception ex)
            {
                //return RedirectToAction("Index", new { @isSuccess = true });
                return Json(new { success = false, responseText = "شما قادر به حذف نمی باشید چون تاج گل برای این رکورد ثبت شده است !" });

            }
        }
        
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
                        var FinancialServiceType = await _context.FinancialServiceTypes.FindAsync(item);

                        _context.FinancialServiceTypes.Remove(FinancialServiceType);

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


        public async Task<IActionResult> ExportToExcel(string filtertitle = "")
        {
            IQueryable<FinancialServiceType> result = _context.FinancialServiceTypes.OrderByDescending(x => x.id);

            if (!string.IsNullOrEmpty(filtertitle))
            {
                result = result.Where(x => x.title.Contains(filtertitle));
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
                row.CreateCell(0).SetCellValue("title");
                
                int count = 1;
                foreach (var item in result)
                {
                    row = excelSheet.CreateRow(count);
                    //row.CreateCell(0).SetCellValue(count);
                    row.CreateCell(0).SetCellValue(item.title);
                    
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
                                var FinancialServiceType = new FinancialServiceType();
                                if (_context.FinancialServiceTypes.Any(x => x.title == row.GetCell(0).ToString()))
                                    continue;
                                FinancialServiceType.title = row.GetCell(0).ToString();
                                FinancialServiceType.charityId =  Convert.ToInt32(User.Identity.Name);
;
                                _context.FinancialServiceTypes.Add(FinancialServiceType);
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