﻿using MRMDataManager.Library.Internal.DataAccess;
using MRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll",new { }, "MRMData");

            return output;
        }
    }
}