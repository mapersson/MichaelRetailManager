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
    [Authorize(Roles = "Cashier")]
    public class ProductController : ApiController
    {
        private readonly IConfiguration _config;

        public ProductController(IConfiguration config)
        {
            _config = config;
        }
        public List<ProductModel> Get()
        {

            ProductData data = new ProductData(_config);

            return data.GetProducts();
        }
    }
}
