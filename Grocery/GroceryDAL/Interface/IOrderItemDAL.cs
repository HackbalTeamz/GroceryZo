using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDAL
{
    public interface IOrderItemDAL
    {
        OrderItemDTO Add(OrderItemDTO orderitemDTO);
        bool Delete(int Id);
        OrderItemDTO Update(OrderItemDTO orderitemDTO);
        OrderItemDTO GetById(int Id);
        List<OrderItemDTO> GetAll();
    }
}
