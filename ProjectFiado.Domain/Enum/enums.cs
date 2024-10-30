using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFiado.Domain.Enum
{
    public enum Role
    {
        [Description("Dono")]
        Admin = 1,
        [Description("Empregado")]
        Sales = 2 
    }

    public enum Status
    {
        Ativate = 1,
        Deactivate = 2
    }

    public enum ProductErrorCode
    {
        ProductEmpty,
        ProductEmptyName,
        ProductEmptyPrice,
        ProductEmptyBrand,
        ProductEmptyDescription,
        ProductNotFound
    }

    public enum StockErrorCode
    {

    }

    public enum Sucess
    {
        Created,
        Error
    }
}
