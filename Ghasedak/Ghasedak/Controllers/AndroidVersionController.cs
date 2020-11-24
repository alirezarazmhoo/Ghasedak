using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Ghasedak.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using SmsIrRestfulNetCore;

namespace Ghasedak.Controllers
{
    [Authorize]

    public class AndroidVersionController : Controller
    {
        private readonly Context _context;
        private readonly IHostingEnvironment environment;

        public AndroidVersionController(Context context, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(bool isSuccess = false)
        {
            var model = _context.AndroidVersions.FirstOrDefault();
            AndroidVersionViewModel AndroidVersionViewModel = new AndroidVersionViewModel();
            if (model != null)
            {
                AndroidVersionViewModel.appAndroidUrl = model.appAndroidUrl;
                AndroidVersionViewModel.currVersion = model.currVersion;
                AndroidVersionViewModel.id = model.id;
                AndroidVersionViewModel.isMandatory = model.isMandatory;
            }
            if (isSuccess)
                ViewBag.success = "ورژن شما با موفقیت ثبت شد اگر مایل هستید نسخه جدید آپلود نمایید.";
            return View(AndroidVersionViewModel);
        }
        [HttpPost("UploadFiles")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(AndroidVersionViewModel page)
        {
            ModelState.Remove("id");
            if (ModelState.IsValid)
            {
                if (page.id == 0)
                {
                    var AndroidVersion = new AndroidVersion();
                    String FileExt = Path.GetExtension(page.files.FileName).ToUpper();
                    if (FileExt == ".APK")
                    {
                        var name = page.files.FileName;
                        var filePath = Path.Combine(environment.WebRootPath, "AndroidApp/", name);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            page.files.CopyTo(stream);
                        }
                        AndroidVersion.appAndroidUrl = "wwwroot/AndroidApp/" + name;
                        AndroidVersion.currVersion = page.currVersion;
                        AndroidVersion.isMandatory = page.isMandatory;
                        _context.AndroidVersions.Add(AndroidVersion);
                        if (page.isMandatory)
                        {
                            Random random = new Random();

                            foreach (var item in _context.Charitys)
                            {
                                item.androidCode = random.Next(100000, 999999).ToString();
                                item.isActive = false;
                                SmsIrRestfulNetCore.Token tokenInstance = new SmsIrRestfulNetCore.Token();
                                var token = tokenInstance.GetToken("ea72b92b8fbd183eccd6c33c", "Ghasedak!!");
                                var ultraFastSend = new UltraFastSend()
                                {
                                    Mobile = Convert.ToInt64(item.mobile),
                                    TemplateId = 37047,
                                    ParameterArray = new List<UltraFastParameters>()
                                  {
                                   new UltraFastParameters()
                                     {
                                       Parameter = "activeCode" , ParameterValue = item.androidCode

                                         }
                                     }.ToArray()

                                };
                                UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(token, ultraFastSend);
                            }
                        }
                    }
                    else
                    {
                        return Json(new { Data = "Error" });

                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { @isSuccess = true });

                }
                else
                {
                    try
                    {
                        var AndroidVersion = _context.AndroidVersions.Find(page.id);
                        string deletePath = environment.WebRootPath + AndroidVersion.appAndroidUrl;
                        if (System.IO.File.Exists(deletePath))
                        {
                            System.IO.File.Delete(deletePath);
                        }
                        String FileExt = Path.GetExtension(page.files.FileName).ToUpper();
                        if (FileExt == ".APK")
                        {
                            var name = page.files.FileName;
                            var filePath = Path.Combine(environment.WebRootPath, "AndroidApp/", name);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                page.files.CopyTo(stream);
                            }
                            AndroidVersion.appAndroidUrl = "wwwroot/AndroidApp/" + name; ;
                            AndroidVersion.currVersion = page.currVersion;
                            AndroidVersion.isMandatory = page.isMandatory;
                            _context.AndroidVersions.Update(AndroidVersion);
                            if (page.isMandatory)
                            {
                                Random random = new Random();
                                foreach (var item in _context.Charitys)
                                {
                                    item.androidCode = random.Next(100000, 999999).ToString();
                                    item.isActive = false;
                                    SmsIrRestfulNetCore.Token tokenInstance = new SmsIrRestfulNetCore.Token();
                                    var token = tokenInstance.GetToken("ea72b92b8fbd183eccd6c33c", "Ghasedak!!");
                                    var ultraFastSend = new UltraFastSend()
                                    {
                                        Mobile = Convert.ToInt64(item.mobile),
                                        TemplateId = 37047,
                                        ParameterArray = new List<UltraFastParameters>()
                                  {
                                   new UltraFastParameters()
                                     {
                                       Parameter = "activeCode" , ParameterValue = item.androidCode

                                         }
                                     }.ToArray()

                                    };
                                    UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(token, ultraFastSend);
                                }
                            }
                        }
                        else
                        {
                            return Json(new { Data = "Error" });

                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", new { @isSuccess = true });

                    }
                    catch (DbUpdateConcurrencyException)
                    {

                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index));


        }
    }
}