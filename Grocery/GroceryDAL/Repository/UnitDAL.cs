using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryDAL
{
    public class UnitDAL : IUnitDAL
    {
        private readonly GroceryZoContext _context;

        public UnitDAL(GroceryZoContext context)
        {
            _context = context;
        }
        #region Save
        public UnitDTO Add(UnitDTO unitDTO)
        {
            try
            {
                Unit unit = new Unit();
                CopyFrom(unitDTO, unit);
                _context.Units.Add(unit);
                Save();
                CopyTo(unitDTO, unit);
                return unitDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region GetAll
        public List<UnitDTO> GetAll()
        {
            try
            {
                List<Unit> units = _context.Units.Where(x => x.Flag == true).ToList();
                List<UnitDTO> unitDTOsList = new List<UnitDTO>();
                foreach (var unit in units)
                {
                    UnitDTO unitDTO = new UnitDTO();
                    CopyTo(unitDTO, unit);
                    unitDTOsList.Add(unitDTO);
                }
                return unitDTOsList;
            }

            catch (Exception exception)
            {
                throw;
            }
        }

        #endregion
        #region Get By Id
        public UnitDTO GetById(int Id)
        {
            try
            {
                Unit unit = _context.Units.Where(x => x.Id == Id && x.Flag == true).FirstOrDefault();
                if (unit == null) return new UnitDTO();
                UnitDTO unitDTO = new UnitDTO();
                CopyTo(unitDTO, unit);
                return unitDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Update
        public UnitDTO Update(UnitDTO unitDTO)
        {
            try
            {
                Unit unit = new Unit();
                CopyFrom(unitDTO, unit);
                _context.Units.Update(unit);
                CopyTo(unitDTO, unit);
                return unitDTO;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Delete
        public bool Delete(int Id)
        {
            bool IsSuccess = false;
            try
            {
                Unit unit = _context.Units.FirstOrDefault(x => x.Id == Id);
                _context.Units.Remove(unit);
                IsSuccess = true;
            }
            catch (Exception ex)
            {
                throw;
                IsSuccess = false;
            }
            return IsSuccess;
        }
        #endregion

        #region Generic Function
        public void Save()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (Exception exception)
            {
                throw;
            }
        }

        #endregion

        #region CopyFunctions
        UnitDTO CopyTo(UnitDTO destination, Unit source)
        {
            if (source != null)
            {
                destination.Id = source.Id;
                destination.Name = source.Name;
                destination.IsBase = source.IsBase;
                destination.Flag = source.Flag;
                destination.UnitId = source.UnitId;
            }
            return destination;

        }
        Unit CopyFrom(UnitDTO source, Unit destination)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.IsBase = source.IsBase;
            destination.Flag = source.Flag;
            destination.UnitId = source.UnitId;
            return destination;
        }
        #endregion
    }
}
