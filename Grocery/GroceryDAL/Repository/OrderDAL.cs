using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryDAL
{
    public class OrderDAL : IOrderDAL
    {
        private readonly GroceryZoContext _context;

        public OrderDAL(GroceryZoContext context)
        {
            _context = context;
        }
        #region Save
        public OrderDTO Add(OrderDTO orderDTO)
        {
            try
            {
                Order order = new Order();
                CopyFrom(orderDTO, order);
                _context.Orders.Add(order);
                Save();
                CopyTo(orderDTO, order);
                return orderDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region GetAll
        public List<OrderDTO> GetAll()
        {
            try
            {
                List<Order> orders = _context.Orders.ToList();
                List<OrderDTO> orderDTOsList = new List<OrderDTO>();
                foreach (var order in orders)
                {
                    OrderDTO orderDTO = new OrderDTO();
                    CopyTo(orderDTO, order);
                    orderDTOsList.Add(orderDTO);
                }
                return orderDTOsList;
            }

            catch (Exception exception)
            {
                throw;
            }
        }

        #endregion
        #region Get By Id
        public OrderDTO GetById(int Id)
        {
            try
            {
                Order order = _context.Orders.Where(x => x.Id == Id).FirstOrDefault();
                if (order == null) return new OrderDTO();
                OrderDTO orderDTO = new OrderDTO();
                CopyTo(orderDTO, order);
                return orderDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Update
        public OrderDTO Update(OrderDTO orderDTO)
        {
            try
            {
                Order order = new Order();
                CopyFrom(orderDTO, order);
                _context.Orders.Update(order);
                CopyTo(orderDTO, order);
                return orderDTO;

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
                Order order = _context.Orders.FirstOrDefault(x => x.Id == Id);
                _context.Orders.Remove(order);
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
        OrderDTO CopyTo(OrderDTO destination, Order source)
        {
            if (source != null)
            {
                destination.Id = source.Id;
                destination.CustomerId = source.CustomerId;
                destination.OrderNo = source.OrderNo;
                destination.Total = source.Total;
                destination.OrderDate = source.OrderDate;
                destination.Status = source.Status;
            }
            return destination;

        }
        Order CopyFrom(OrderDTO source, Order destination)
        {
            destination.Id = source.Id;
            destination.CustomerId = source.CustomerId;
            destination.OrderNo = source.OrderNo;
            destination.Total = source.Total;
            destination.OrderDate = source.OrderDate;
            destination.Status = source.Status;
            return destination;
        }
        #endregion
    }
}
