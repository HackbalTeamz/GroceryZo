using System;
using System.Collections.Generic;
using GroceryBOL;
using GroceryDAL;

namespace GroceryBLL
{
    public class ProductBLL : IProductBLL
    {
        private IProductDAL _productDAL;

        public ProductBLL(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public ProductDTO GetById(int Id)
        {
            try
            {
                return _productDAL.GetById(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ProductDTO Add(ProductDTO ModelDTO)
        {
            try
            {
                return _productDAL.Add(ModelDTO);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                return (_productDAL.Delete(Id));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ProductDTO> GetAll()
        {

            try
            {
                return _productDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public ProductDTO Update(ProductDTO ModelDTO)
        {
            try
            {
                return _productDAL.Update(ModelDTO);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
