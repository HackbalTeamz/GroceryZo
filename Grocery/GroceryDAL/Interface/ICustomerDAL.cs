using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDAL
{
	public interface ICustomerDAL
    {
        CustomerDTO Add(CustomerDTO customerDTO);
        bool Delete(int Id);
        CustomerDTO Update(CustomerDTO customerDTO);
        CustomerDTO GetById(int Id);
        List<CustomerDTO> GetAll();
    }
}

