using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MRMDataManager.Library.DataAccess;
using MRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly IConfiguration _config;

        public SaleController(IConfiguration config)
        {
            _config = config;
        }
        [Authorize(Roles = "Cashier")]
        [HttpPost]
        public void Post(SaleModel sale)
        {
            var data = new SaleData(_config);
            var cashierId = User.FindFirst(ClaimTypes.NameIdentifier).ToString(); //RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, cashierId);

        }

        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        [HttpGet]
        public List<SaleReportModel> GetSalesReport()
        {
            
            if (User.IsInRole("Admin"))
            {
                //Add administrator activties
            }

            SaleData data = new SaleData(_config);

            return data.GetSaleReport();
        }
    }
}
