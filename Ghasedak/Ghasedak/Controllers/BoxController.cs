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
using PagedList.Core;

namespace Ghasedak.Controllers
{
    public class BoxController : Controller
    {
        private IBox _Box;
        private readonly Context _context;
        private IHostingEnvironment _hostingEnvironment;

        public BoxController(IBox Box, Context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _Box = Box;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index(int page = 1, string filternumber = "", bool isSuccess = false)
        {
            var model = _Box.GetBox(page, filternumber);
            if (isSuccess)
                ViewBag.success = "شما قادر به حذف نمی باشید چون درآمد برای این رکورد ثبت شده است";
            return View(model);
        }
        public IActionResult Create()
        {
            //ViewData["DischargeRouteId"] = new SelectList(_context.DischargeRoutes, "id", "code:address", "");
            ViewData["DischargeRouteId"] = _context.DischargeRoutes.ToList();


            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Create(Box box)
        {
            //ViewData["DischargeRouteId"] = new SelectList(_context.DischargeRoutes, "id", "code", "");
            ViewData["DischargeRouteId"] = _context.DischargeRoutes.ToList();

            if (!ModelState.IsValid)
            {
                return View(box);
            }
            else
            {
                int productId = _Box.AddBoxFromAdmin(box);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Boxs.FindAsync(id);

            //ViewData["DischargeRouteId"] = new SelectList(_context.DischargeRoutes, "id", "code", box.dischargeRouteId);
            ViewData["DischargeRouteId"] = _context.DischargeRoutes.ToList();



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
        public async Task<IActionResult> Edit(int id, Box box)
        {
            if (id != box.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(box);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DischargeRouteId"] = new SelectList(_context.DischargeRoutes, "id", "code", box.dischargeRouteId);
            ViewData["DischargeRouteId"] = _context.DischargeRoutes.ToList();


            return View(box);
        }



        public async Task<IActionResult> GetBox(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var Box = await _context.Boxs.FindAsync(id);
            if (Box == null)
            {
                return NotFound();
            }
            return Json(Box);

        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Box = await _context.Boxs
                .FirstOrDefaultAsync(m => m.id == id);
            if (Box == null)
            {
                return NotFound();
            }

            return View(Box);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Box = await _context.Boxs.FindAsync(id);



                _context.Boxs.Remove(Box);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { @isSuccess = true });

            }
            return RedirectToAction(nameof(Index));
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
                        var Box = await _context.Boxs.FindAsync(item);

                        _context.Boxs.Remove(Box);

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




        public async Task<IActionResult> ExportToExcel(string filternumber = "")
        {
            IQueryable<Box> result = _context.Boxs.Include(x => x.dischargeRoute).OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(filternumber))
            {
                result = result.Where(x => x.number.Contains(filternumber));
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
                row.CreateCell(0).SetCellValue("PathCode");
                row.CreateCell(1).SetCellValue("Address");
                row.CreateCell(2).SetCellValue("Mobile");
                row.CreateCell(3).SetCellValue("Name");

                row.CreateCell(4).SetCellValue("Number");
                //row.CreateCell(5).SetCellValue("تاریخ واگذاری");
                int count = 1;
                foreach (var item in result)
                {
                    row = excelSheet.CreateRow(count);
                    //row.CreateCell(0).SetCellValue(count);
                    row.CreateCell(0).SetCellValue(item.dischargeRoute.code);
                    row.CreateCell(1).SetCellValue(item.address);
                    row.CreateCell(2).SetCellValue(item.mobile);

                    row.CreateCell(3).SetCellValue(item.fullName);
                    row.CreateCell(4).SetCellValue(item.number);
                    //row.CreateCell(5).SetCellValue(item.assignmentDate);
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
                                var box = new Box();
                                var dischargeRoute = _context.DischargeRoutes.FirstOrDefault(x => x.code == row.GetCell(1).ToString());
                                if (dischargeRoute == null)
                                    continue;
                                box.dischargeRouteId = dischargeRoute.id;
                                box.address = row.GetCell(2).ToString();
                                box.mobile = row.GetCell(3).ToString();
                                box.lon = 0;
                                box.lat = 0;
                                box.fullName = row.GetCell(4).ToString();
                                box.number = row.GetCell(5).ToString();
                                box.assignmentDate = PersianCalendarDate.PersianCalendarResult(DateTime.Now);
                                _context.Boxs.Add(box);
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