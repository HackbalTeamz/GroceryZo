using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryDAL
{
    public class ProductDAL : IProductDAL
    {
        private readonly GroceryZoContext _context;

        public ProductDAL(GroceryZoContext context)
        {
            _context = context;
        }
        #region Save
        public ProductDTO Add(ProductDTO productDTO)
        {
            try
            {
                Product product = new Product();
                CopyFrom(productDTO, product);
                _context.Products.Add(product);
                Save();
                CopyTo(productDTO, product);
                return productDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region GetAll
        public List<ProductDTO> GetAll()
        {
            try
            {
                List<Product> products = _context.Products.Where(x => x.Flag == true).ToList();
                List<ProductDTO> productDTOsList = new List<ProductDTO>();
                foreach (var product in products)
                {
                    ProductDTO productDTO = new ProductDTO();
                    CopyTo(productDTO, product);
                    productDTOsList.Add(productDTO);
                }
                return productDTOsList;
            }

            catch (Exception exception)
            {
                throw;
            }
        }

        #endregion
        #region Get By Id
        public ProductDTO GetById(int Id)
        {
            try
            {
                Product product = _context.Products.Where(x => x.Id == Id && x.Flag == true).FirstOrDefault();
                if (product == null) return new ProductDTO();
                ProductDTO productDTO = new ProductDTO();
                CopyTo(productDTO, product);
                return productDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Update
        public ProductDTO Update(ProductDTO productDTO)
        {
            try
            {
                Product product = new Product();
                CopyFrom(productDTO, product);
                _context.Products.Update(product);
                CopyTo(productDTO, product);
                return productDTO;

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
                Product product = _context.Products.FirstOrDefault(x => x.Id == Id);
                _context.Products.Remove(product);
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
        ProductDTO CopyTo(ProductDTO destination, Product source)
        {
            if (source != null)
            {
                destination.Id = source.Id;
                destination.Flag = source.Flag;
                destination.CategoryId = source.CategoryId;
                destination.Name = source.Name;
                destination.ProductDesc = source.ProductDesc;
                destination.UnitPrice = source.UnitPrice;
                destination.UnitId = source.UnitId;
                destination.UnitIncrement = source.UnitIncrement;

            }
            return destination;

        }
        Product CopyFrom(ProductDTO source, Product destination)
        {
            destination.Id = source.Id;
            destination.Flag = source.Flag;
            destination.CategoryId = source.CategoryId;
            destination.Name = source.Name;
            destination.ProductDesc = source.ProductDesc;
            destination.UnitPrice = source.UnitPrice;
            destination.UnitId = source.UnitId;
            destination.UnitIncrement = source.UnitIncrement;
            return destination;
        }
        #endregion
    }
}


