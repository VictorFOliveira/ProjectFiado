using ProjectFiado.Domain.Enum;

namespace ProjectFiado.Exceptions
{
    public class ProductExceptions : Exception
    {
        public ProductErrorCode ErrorCode { get; }

        public ProductExceptions(ProductErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
        public override string ToString()
        {
            return $"Product Error Code: {ErrorCode} - Message: {Message}";
        }
    }
}
