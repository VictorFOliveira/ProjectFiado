using ProjectFiado.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFiado.Exceptions
{
    public class StockExceptions : Exception
    {
        public ProductErrorCode ErrorCode { get; }

        public StockExceptions(ProductErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
        public override string ToString()
        {
            return $"Product Error Code: {ErrorCode} - Message: {Message}";
        }
    }
}
