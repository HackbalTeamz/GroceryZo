using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryDAL
{
    public class OrderItemDAL : IOrderItemDAL
    {
        private readonly GroceryZoContext _context;

        public OrderItemDAL(GroceryZoContext context)
        {
            _context = context;
        }
        #region Save
        public OrderItemDTO Add(OrderItemDTO orderitemDTO)
        {
            try
            {
                OrderItem orderitem = new OrderItem();
                CopyFrom(orderitemDTO, orderitem);
                _context.OrderItems.Add(orderitem);
                Save();
                CopyTo(orderitemDTO, orderitem);
                return orderitemDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region GetAll
        public List<OrderItemDTO> GetAll()
        {
            try
            {
                List<OrderItem> orderitems = _context.OrderItems.ToList();
                List<OrderItemDTO> orderitemDTOsList = new List<OrderItemDTO>();
                foreach (var orderitem in orderitems)
                {
                    OrderItemDTO orderitemDTO = new OrderItemDTO();
                    CopyTo(orderitemDTO, orderitem);
                    orderitemDTOsList.Add(orderitemDTO);
                }
                return orderitemDTOsList;
            }

            catch (Exception exception)
            {
                throw;
            }
        }

        #endregion
        #region Get By Id
        public OrderItemDTO GetById(int Id)
        {
            try
            {
                OrderItem orderitem = _context.OrderItems.Where(x => x.Id == Id ).FirstOrDefault();
                if (orderitem == null) return new OrderItemDTO();
                OrderItemDTO orderitemDTO = new OrderItemDTO();
                CopyTo(orderitemDTO, orderitem);
                return orderitemDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Update
        public OrderItemDTO Update(OrderItemDTO orderitemDTO)
        {
            try
            {
                OrderItem orderitem = new OrderItem();
                CopyFrom(orderitemDTO, orderitem);
                _context.OrderItems.Update(orderitem);
                CopyTo(orderitemDTO, orderitem);
                return orderitemDTO;

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
                OrderItem orderitem = _context.OrderItems.FirstOrDefault(x => x.Id == Id);
                _context.OrderItems.Remove(orderitem);
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
        OrderItemDTO CopyTo(OrderItemDTO destination, OrderItem source)
        {
            if (source != null)
            {
                destination.Id = source.Id;
                destination.OrderId = source.OrderId;
                destination.ProductId = source.ProductId;
                destination.Quantity = source.Quantity;
                destination.Total = source.Total;
            }
            return destination;

        }
        OrderItem CopyFrom(OrderItemDTO source, OrderItem destination)
        {
            destination.Id = source.Id;
            destination.OrderId = source.OrderId;
            destination.ProductId = source.ProductId;
            destination.Quantity = source.Quantity;
            destination.Total = source.Total;
            return destination;
        }
        #endregion
    }
}
