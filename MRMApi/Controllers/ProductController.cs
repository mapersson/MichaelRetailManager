using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MRMDataManager.Library.DataAccess;
using MRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Cashier")]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IProductData _productData;

        public ProductController(IProductData productData)
        {
            _productData = productData;
        }
        [HttpGet]
        public List<ProductModel> Get()
        {

            return _productData.GetProducts();
        }
    }
}
