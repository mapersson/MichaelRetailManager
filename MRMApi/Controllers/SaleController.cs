using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel sale)
        {
            var data = new SaleData();
            var cashierId = User.FindFirst(ClaimTypes.NameIdentifier).ToString(); //RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, cashierId);

        }

        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReport()
        {
            
            if (User.IsInRole("Admin"))
            {
                //Add administrator activties
            }

            SaleData data = new SaleData();

            return data.GetSaleReport();
        }
    }
}
