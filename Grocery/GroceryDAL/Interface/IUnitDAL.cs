using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDAL
{
    public interface IUnitDAL
    {
        UnitDTO Add(UnitDTO unitDTO);
        bool Delete(int Id);
        UnitDTO Update(UnitDTO unitDTO);
        UnitDTO GetById(int Id);
        List<UnitDTO> GetAll();
    }
}
