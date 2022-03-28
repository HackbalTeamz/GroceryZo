using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDAL
{
    public interface IOrderDAL
    {
        OrderDTO Add(OrderDTO orderDTO);
        bool Delete(int Id);
        OrderDTO Update(OrderDTO orderDTO);
        OrderDTO GetById(int Id);
        List<OrderDTO> GetAll();
    }
}
