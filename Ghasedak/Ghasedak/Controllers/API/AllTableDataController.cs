using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Ghasedak.Utility;
using Ghasedak.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllTableDataController : ControllerBase
    {
        private readonly Context _context;

        private IDeceasedName _DeceasedName;
        private readonly IHostingEnvironment environment;

        public AllTableDataController(Context context, IDeceasedName DeceasedName, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _DeceasedName = DeceasedName;

        }

        [HttpGet]
        [Route("GetAll")]
        public object GetAll()
        {
            var AllTableData = _context.AllTableDatas.Where(x=>x.isCall==false).ToList();
            var oldData = AllTableData;
            foreach (var item in AllTableData)
            {
                item.isCall = true;
            }
            _context.SaveChanges();
            return oldData;
        }
        

    }
}