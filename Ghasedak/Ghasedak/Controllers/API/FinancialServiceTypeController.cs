using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Ghasedak.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ghasedak.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialServiceTypeController : ControllerBase
    {
        private readonly Context _context;

        private IFinancialServiceType _FinancialServiceType;
        private readonly IHostingEnvironment environment;

        public FinancialServiceTypeController(Context context, IFinancialServiceType FinancialServiceType, IHostingEnvironment environment)
        {
            this.environment = environment;
            _context = context;
            _FinancialServiceType = FinancialServiceType;

        }

        [HttpGet("{charityId}")]
        public object GetFinancialServiceType([FromRoute] int charityId)
        {
            var data = _FinancialServiceType.GetFinancialServiceType(charityId);
            return data;
        }
       

    }
}