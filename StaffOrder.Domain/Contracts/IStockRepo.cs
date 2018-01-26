using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Domain.Contracts
{
    public interface IStockRepo
    {
        Stock GetStock(int itemNo);
    }
}
