using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryDAL
{
    public class AddressDAL : IAddressDAL
    {
        private readonly GroceryZoContext _context;

        public AddressDAL(GroceryZoContext context)
        {
            _context = context;
        }
        #region Save
        public AddressDTO Add(AddressDTO addressDTO)
        {
            try
            {
                Address address = new Address();
                CopyFrom(addressDTO, address);
                _context.Addresses.Add(address);
                Save();
                CopyTo(addressDTO, address);
                return addressDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region GetAll
        public List<AddressDTO> GetAll()
        {
            try
            {
                List<Address> addresses = _context.Addresses.ToList();
                List<AddressDTO> addressDTOsList = new List<AddressDTO>();
                foreach (var address in addresses)
                {
                    AddressDTO addressDTO = new AddressDTO();
                    CopyTo(addressDTO, address);
                    addressDTOsList.Add(addressDTO);
                }
                return addressDTOsList;
            }

            catch (Exception exception)
            {
                throw;
            }
        }

        #endregion
        #region Get By Id
        public AddressDTO GetById(int Id)
        {
            try
            {
                Address address = _context.Addresses.Where(x => x.Id == Id ).FirstOrDefault();
                if (address == null) return new AddressDTO();
                AddressDTO addressDTO = new AddressDTO();
                CopyTo(addressDTO, address);
                return addressDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Update
        public AddressDTO Update(AddressDTO addressDTO)
        {
            try
            {
                Address address = new Address();
                CopyFrom(addressDTO, address);
                _context.Addresses.Update(address);
                CopyTo(addressDTO, address);
                return addressDTO;

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
                Address address = _context.Addresses.FirstOrDefault(x => x.Id == Id);
                _context.Addresses.Remove(address);
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
        AddressDTO CopyTo(AddressDTO destination, Address source)
        {
            if (source != null)
            {
                destination.Id = source.Id;
                destination.CustomerId = source.CustomerId;
                destination.Address1 = source.Address1;
                destination.Landmark = source.Landmark;
                destination.Pincodeid = source.Pincodeid;
            }
            return destination;

        }
        Address CopyFrom(AddressDTO source, Address destination)
        {
            destination.Id = source.Id;
            destination.CustomerId = source.CustomerId;
            destination.Address1 = source.Address1;
            destination.Landmark = source.Landmark;
            destination.Pincodeid = source.Pincodeid;
            return destination;
        }
        #endregion
    }
}
