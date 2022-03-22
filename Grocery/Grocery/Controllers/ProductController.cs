using GroceryBLL;
using GroceryBOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Grocery.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IProductBLL _productBLL;
        public ProductController(IProductBLL productBLL)
        {
            _productBLL = productBLL;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProductDTO> pincodeDtoList = new();
            try
            {
                pincodeDtoList= _productBLL.GetAll();
            }
            catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIResponce { Status = "Error", Message = exception.Message, data = pincodeDtoList, StatusCode = StatusCodes.Status400BadRequest });
            }
            return Ok(new APIResponce { Status = "Success", Message = "Data Fetched Successfully", data = pincodeDtoList, StatusCode = StatusCodes.Status200OK });
        }

        [HttpGet]
        public IActionResult GetByID(int Id)
        {
            ProductDTO pincodeDTO = new();
            try
            {
                pincodeDTO= _productBLL.GetById(Id);
            }
            catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIResponce { Status = "Error", Message = exception.Message, data = pincodeDTO, StatusCode = StatusCodes.Status400BadRequest });
            }
            return Ok(new APIResponce { Status = "Success", Message = "Data Fetched Successfully", data = pincodeDTO, StatusCode = StatusCodes.Status200OK });
        }

        [HttpPost]
        public IActionResult UpdateById(ProductDTO pincode)
        {
            ProductDTO pincodeDTO = new ProductDTO();
            try
            {
                pincodeDTO = _productBLL.Update(pincode);
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
                IsSuccess = _productBLL.Delete(Id);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIResponce { Status = "Error", Message = exception.Message, data = IsSuccess, StatusCode = StatusCodes.Status400BadRequest });
            }
            return Ok(new APIResponce { Status = "Success", Message = "Data Fetched Successfully", data = IsSuccess, StatusCode = StatusCodes.Status200OK });
        }
        [HttpPost]
        public IActionResult SaveProduct(ProductDTO pincodeDTO)
        {
            ProductDTO pincode = new();
            try
            {
                pincode = _productBLL.Add(pincodeDTO);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIResponce { Status = "Error", Message = exception.Message, data = pincode, StatusCode = StatusCodes.Status400BadRequest });
            }
            return Ok(new APIResponce { Status = "Success", Message = "Data Inserted Successfully", data = pincode, StatusCode = StatusCodes.Status200OK });
        }

    }
}
