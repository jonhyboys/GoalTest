using System;
using System.Threading.Tasks;
using API.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors(policyName: "FE")]
    public class Product : Controller
    {
        IProductService _service;
        IApiResult _result;

        public Product(IProductService service, IApiResult result)
        {
            _service = service;
            _result = result;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            try
            {
                _result.Data = (new JsonResult(await _service.GetAllProducts())).Value;
                _result.Error = 0;

                return new JsonResult(_result);
            }
            catch (Exception ex)
            {
                _result.Error = 1;
                _result.Message = ex.Message;
                return StatusCode(500, new JsonResult(_result));
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromQuery] Entities.Product product)
        {
            try
            {
                _result.Data = new JsonResult(_service.AddProduct(product)).Value;
                _result.Error = 0;
                return new JsonResult(_result);
            }
            catch (Exception ex)
            {
                _result.Error = 1;
                _result.Message = ex.Message;
                return StatusCode(500, new JsonResult(_result));
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                if (_service.DeleteProduct(id) > 0)
                {
                    _result.Error = 0;
                    _result.Data = id;
                }
                else
                {
                    _result.Error = 1;
                    _result.Message = "No se encontró el producto en la base de datos.";
                }
                return new JsonResult(_result);
            }
            catch (Exception ex)
            {
                _result.Error = 1;
                _result.Message = ex.Message;
                return StatusCode(500, await Task.FromResult(new JsonResult(_result)));
            }
        }

        public void ReviewExpiration()
        {

        }

        public void NotifyProductDeletion() { }
    }
}
