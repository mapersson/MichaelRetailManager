﻿using MRMDataManager.Library.Models;
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
        // GET api/values
        public void Post(SaleModel sale)
        {
            Console.WriteLine();
        }
       
    }
}