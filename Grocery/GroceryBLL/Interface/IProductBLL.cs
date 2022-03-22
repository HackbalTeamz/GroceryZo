using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryBLL
{
    public interface IProductBLL
    {
        ProductDTO GetById(int Id);
        ProductDTO Add(ProductDTO pincodeDTO);
        bool Delete(int Id);
        ProductDTO Update(ProductDTO pincodeDTO);
        List<ProductDTO> GetAll();
    }
}
