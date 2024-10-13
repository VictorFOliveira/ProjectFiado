using ProjectFiado.Models;
using ProjectFiado.Models.DTOs;

namespace ProjectFiado.Mapper
{
    public class StockMApper
    {
        public StockModel RequestStockToStockModel(RequestStockDTO requestStockDTO)
        {
            if(requestStockDTO == null)
            {
                throw new Exception("Nulo");
            }

            return new StockModel
            {
                ProductId = requestStockDTO.ProductId,
                Quantity = requestStockDTO.Quantity,
                Validate = requestStockDTO.Validate,
            };
        }

        public ResponseStockDTO StockModelToResponse(StockModel stockModel)
        {

            if (stockModel == null)
            {
                throw new Exception("nulo");
            }

            return new ResponseStockDTO
            {
                ProductId = stockModel.ProductId,
                Quantity = stockModel.Quantity,
                Validate = stockModel.Validate,
            };
        }
    }
}
