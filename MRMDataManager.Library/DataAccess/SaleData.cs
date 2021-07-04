using Microsoft.Extensions.Configuration;
using MRMDataManager.Library.Internal.DataAccess;
using MRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRMDataManager.Library.DataAccess
{
    public class SaleData : ISaleData
    {
        private readonly IProductData _productData;
        private readonly ISqlDataAccess _sql;

        public SaleData(IProductData productData, ISqlDataAccess sql)
        {
            _productData = productData;
            _sql = sql;
        }

        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            //TODO: Make this SOLID/DRY/Better
            //Start filling in the models we will save to the database
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            var taxRate = ConfigHelper.GetTaxRate() / 100;

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,

                };

                var productInfo = _productData.GetProductById(item.ProductId);

                if (productInfo == null)
                {
                    throw new Exception($"The product Id of {item.ProductId} could not be found in the database.");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }

            //Fill in the available information
            // Create the Sale model
            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            // Save the sale model
            
            try
            {
                _sql.StartTransaction("MRMData");
                _sql.SaveDataInTransaction("dbo.spSale_Insert", sale);

                // Get the ID from the sale model
                sale.Id = _sql.LoadDataInTransaction<int, dynamic>("spSale_Lookup", new { CashierId = sale.CashierId, SaleDate = sale.SaleDate }).FirstOrDefault();

                // Finish filling the sale detail model
                foreach (var item in details)
                {
                    item.SaleId = sale.Id;
                    // Save the sale detail models. 
                    _sql.SaveDataInTransaction("dbo.spSaleDetail_Insert", item);
                }

                _sql.CommitTransaction();

            }
            catch
            {

                _sql.RollBackTransaction();
                throw;
            }
            
        }

        public List<SaleReportModel> GetSaleReport()
        {
            
            var output = _sql.LoadData<SaleReportModel, dynamic>("dbo.spSale_SaleReport", new { }, "MRMData");
            return output;
        }
    }
}
