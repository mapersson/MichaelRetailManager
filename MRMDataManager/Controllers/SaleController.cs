using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using MRMDataManager.Library.DataAccess;
using MRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        private readonly IConfiguration _config;

        public SaleController(IConfiguration config)
        {
            _config = config;
        }
        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel sale)
        {
            var data = new SaleData(_config);
            var cashierId = RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, cashierId);
            
        }

        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReport()
        {
            
            if (RequestContext.Principal.IsInRole("Admin"))
            {
                //Add administrator activties
            }
            
            SaleData data = new SaleData(_config);

            return data.GetSaleReport();
        }
       
    }
}