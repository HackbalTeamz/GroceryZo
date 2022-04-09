using GroceryBOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryDAL
{
    public class ProductCategoryDAL:IProductCategoryDAL
    {
        private readonly GroceryZoContext _context;

        public ProductCategoryDAL(GroceryZoContext context)
        {
            _context = context;
        }
        #region Save
        public ProductCategoryDTO Add(ProductCategoryDTO ModelDTO)
        {
            try
            {
                ProductCategory Model = new ProductCategory();
                CopyFrom(ModelDTO, Model);
                _context.ProductCategories.Add(Model);
                Save();
                CopyTo(ModelDTO, Model);
                return ModelDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region GetAll
        public List<ProductCategoryDTO> GetAll()
        {
            try
            {
                List<ProductCategory> Models = _context.ProductCategories.Where(x => x.Flag == true).ToList();
                List<ProductCategoryDTO> ModelDTOsList = new List<ProductCategoryDTO>();
                foreach (var Model in Models)
                {
                    ProductCategoryDTO ModelDTO = new ProductCategoryDTO();
                    CopyTo(ModelDTO, Model);
                    ModelDTOsList.Add(ModelDTO);
                }
                return ModelDTOsList;
            }

            catch (Exception exception)
            {
                throw;
            }
        }

        #endregion
        #region Get By Id
        public ProductCategoryDTO GetById(int Id)
        {
            try
            {
                ProductCategory productCategory = _context.ProductCategories.Where(x => x.Id == Id && x.Flag == true).FirstOrDefault();
                if (productCategory == null) return new ProductCategoryDTO();
                ProductCategoryDTO productCategoryDTO = new ProductCategoryDTO();
                CopyTo(productCategoryDTO, productCategory);
                return productCategoryDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Update
        public ProductCategoryDTO Update(ProductCategoryDTO ModelDTO)
        {
            try
            {
                ProductCategory Model = new ProductCategory();
                CopyFrom(ModelDTO, Model);
                _context.ProductCategories.Update(Model);
                Save();
                CopyTo(ModelDTO, Model);
                return ModelDTO;

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
                Pincode pincode = _context.Pincodes.FirstOrDefault(x => x.Id == Id);
                _context.Pincodes.Remove(pincode);
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

        ProductCategoryDTO CopyTo(ProductCategoryDTO destination, ProductCategory source)
        {
            if (source != null)
            {
                destination.Id = source.Id;
                destination.Flag = source.Flag;
                destination.CategoryName = source.CategoryName;
                destination.Image = source.Image;
            }
            return destination;

        }
        ProductCategory CopyFrom(ProductCategoryDTO source, ProductCategory destination)
        {
            destination.Id = source.Id;
            destination.Flag = source.Flag;
            destination.CategoryName = source.CategoryName;
            destination.Image = source.Image;
            return destination;
        }
    }
}
