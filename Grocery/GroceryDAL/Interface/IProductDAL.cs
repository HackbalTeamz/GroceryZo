using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDAL
{
    public interface IProductDAL
    {
        ProductDTO Add(ProductDTO productDTO);
        bool Delete(int Id);
        ProductDTO Update(ProductDTO productDTO);
        ProductDTO GetById(int Id);
        List<ProductDTO> GetAll();
    }
}
