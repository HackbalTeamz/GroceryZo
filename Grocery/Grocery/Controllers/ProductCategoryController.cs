﻿using GroceryBLL;
using GroceryBOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Grocery.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductCategoryController : BaseApiController
    {
        private readonly IProductCategoryBLL _productCategoryBLL;
        public ProductCategoryController(IProductCategoryBLL productCategoryBLL)
        {
            _productCategoryBLL = productCategoryBLL;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProductCategoryDTO> pincodeDtoList = new();
            try
            {
                pincodeDtoList = _productCategoryBLL.GetAll();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIResponce { Status = "Error", Message = exception.Message, data = pincodeDtoList, StatusCode = StatusCodes.Status400BadRequest });
            }
            return Ok(new APIResponce { Status = "Success", Message = "Data Fetched Successfully", data = pincodeDtoList, StatusCode = StatusCodes.Status200OK });
        }

        [HttpGet]
        public IActionResult GetByID(int Id)
        {
            ProductCategoryDTO productCategoryDTO = new();
            try
            {
                productCategoryDTO = _productCategoryBLL.GetById(Id);
            }
            catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIResponce { Status = "Error", Message = exception.Message, data = productCategoryDTO, StatusCode = StatusCodes.Status400BadRequest });
            }
            return Ok(new APIResponce { Status = "Success", Message = "Data Fetched Successfully", data = productCategoryDTO, StatusCode = StatusCodes.Status200OK });
        }
        [HttpPost]
        public IActionResult UpdateById(ProductCategoryDTO pincode)
        {
            ProductCategoryDTO pincodeDTO = new ProductCategoryDTO();
            try
            {
                pincodeDTO = _productCategoryBLL.Update(pincode);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIResponce { Status = "Error", Message = exception.Message, data = pincodeDTO, StatusCode = StatusCodes.Status400BadRequest });
            }
            return Ok(new APIResponce { Status = "Success", Message = "Data Fetched Successfully", data = pincodeDTO, StatusCode = StatusCodes.Status200OK });
        }
        [HttpDelete]
        public IActionResult DeleteById(int Id)
        {
            bool IsSuccess = false;
            try
            {
                IsSuccess = _productCategoryBLL.Delete(Id);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIResponce { Status = "Error", Message = exception.Message, data = IsSuccess, StatusCode = StatusCodes.Status400BadRequest });
            }
            return Ok(new APIResponce { Status = "Success", Message = "Data Fetched Successfully", data = IsSuccess, StatusCode = StatusCodes.Status200OK });
        }

        [HttpPost]
        public IActionResult SaveProductCategory(ProductCategoryDTO productCategoryDTO)
        {
            ProductCategoryDTO pincode = new();
            try
            {
                pincode = _productCategoryBLL.Add(productCategoryDTO);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIResponce { Status = "Error", Message = exception.Message, data = pincode, StatusCode = StatusCodes.Status400BadRequest });
            }
            return Ok(new APIResponce { Status = "Success", Message = "Data Inserted Successfully", data = pincode, StatusCode = StatusCodes.Status200OK });
        }


    }
}
