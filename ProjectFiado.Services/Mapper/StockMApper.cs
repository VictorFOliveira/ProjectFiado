using ProjectFiado.Domain.Models;
using ProjectFiado.Domain.Models.DTOs.StockDTOS;

namespace ProjectFiado.Mapper
{
    public class StockMapper
    {

        public ResponseStockDTO StockModelToResponse(StockModel stockModel)
        {

            if (stockModel == null)
            {
                return null;
            }

            return new ResponseStockDTO
            {
                Id = stockModel.Id,
                ProductId = stockModel.ProductID,
                Quantity = stockModel.Quantity,
                Validate = stockModel.Validate,
            };
        }

        public StockModel RequestStockToModel(RequestStockDTO requestStock)
        {
            if (requestStock == null)
            {
                return null;
            }

            return new StockModel
            {
                ProductID = requestStock.ProductId,
                Quantity = requestStock.Quantity,
                Validate = requestStock.Validate,

            };
        }
    }
}
