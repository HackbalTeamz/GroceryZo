using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryDAL
{
    public class CustomerDAL : ICustomerDAL
    {
        private readonly GroceryZoContext _context;

        public CustomerDAL(GroceryZoContext context)
        {
            _context = context;
        }
        #region Save
        public CustomerDTO Add(CustomerDTO customerDTO)
        {
            try
            {
                Customer customer = new Customer();
                CopyFrom(customerDTO, customer);
                _context.Customers.Add(customer);
                Save();
                CopyTo(customerDTO, customer);
                return customerDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region GetAll
        public List<CustomerDTO> GetAll()
        {
            try
            {
                List<Customer> customers = _context.Customers.ToList();
                List<CustomerDTO> customerDTOsList = new List<CustomerDTO>();
                foreach (var customer in customers)
                {
                    CustomerDTO customerDTO = new CustomerDTO();
                    CopyTo(customerDTO, customer);
                    customerDTOsList.Add(customerDTO);
                }
                return customerDTOsList;
            }

            catch (Exception exception)
            {
                throw;
            }
        }

        #endregion
        #region Get By Id
        public CustomerDTO GetById(int Id)
        {
            try
            {
                Customer customer = _context.Customers.Where(x => x.Id == Id).FirstOrDefault();
                if (customer == null) return new CustomerDTO();
                CustomerDTO customerDTO = new CustomerDTO();
                CopyTo(customerDTO, customer);
                return customerDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Update
        public CustomerDTO Update(CustomerDTO customerDTO)
        {
            try
            {
                Customer customer = new Customer();
                CopyFrom(customerDTO, customer);
                _context.Customers.Update(customer);
                CopyTo(customerDTO, customer);
                return customerDTO;

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
                Customer customer = _context.Customers.FirstOrDefault(x => x.Id == Id);
                _context.Customers.Remove(customer);
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
        CustomerDTO CopyTo(CustomerDTO destination, Customer source)
        {
            if (source != null)
            {
                destination.Id = source.Id;
                destination.Name = source.Name;
                destination.Mobile = source.Mobile;
            }
            return destination;

        }
        Customer CopyFrom(CustomerDTO source, Customer destination)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Mobile = source.Mobile;
            return destination;
        }
        #endregion
    }
}
