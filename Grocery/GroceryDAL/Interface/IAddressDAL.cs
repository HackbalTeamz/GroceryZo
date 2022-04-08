using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDAL
{
    public interface IAddressDAL
    {
        AddressDTO Add(AddressDTO addressDTO);
        bool Delete(int Id);
        AddressDTO Update(AddressDTO addressDTO);
        AddressDTO GetById(int Id);
        List<AddressDTO> GetAll();
    }
}
